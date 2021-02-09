using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace DM_Xamarin1.ViewModels
{
    class PomodoroViewModel : NotificationObject
    {
        private Timer timer;
        private int pomodoroDuration;
        private int breakDuration;        
        
        public ICommand StartOrPausedCommand { get; set; }
        private bool isRunning;
        public bool IsRunning
        {
            get { return isRunning; }
            set { 
                isRunning = value;
                OnPropertyChanged();
            }
        }
        private TimeSpan ellapsed;
        public TimeSpan Ellapsed
        {
            get { return ellapsed; }
            set { 
                ellapsed = value;
                OnPropertyChanged();
            }
        }

        private bool isInBreak;
        public bool IsInBreak
        {
            get { return isInBreak; }
            set { 
                isInBreak = value;
                OnPropertyChanged();
            }
        }

        public PomodoroViewModel()
        {
            InitializedTimer();
            LoadConfiguredValues();
            StartOrPausedCommand = new Command(StartOrPauseExecuted);
        }

        private void LoadConfiguredValues()
        {
            pomodoroDuration = (int)Application.Current.Properties[Literals.PomodoroDuration];
            breakDuration = (int)Application.Current.Properties[Literals.BreakDuration];
        }

        private void InitializedTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Ellapsed = Ellapsed.Add(TimeSpan.FromSeconds(1));

            if(IsRunning && Ellapsed.TotalSeconds == pomodoroDuration * 60)
            {
                IsRunning = false;
                IsInBreak = true;
                Ellapsed = TimeSpan.Zero;

                await SavePomodoroAsync();
            }
            if(IsInBreak && Ellapsed.TotalSeconds == breakDuration * 60)
            {
                IsRunning = true;
                IsInBreak = false;
                Ellapsed = TimeSpan.Zero;
            }
        }

        private async Task SavePomodoroAsync()
        {
            List<DateTime> history;
            if(Application.Current.Properties.ContainsKey(Literals.History))
            {
                var json = Application.Current.Properties[Literals.History].ToString();
                history = JsonConvert.DeserializeObject<List<DateTime>>(json);
            } else
            {
                history = new List<DateTime>();
            }

            history.Add(DateTime.Now);

            var serializableObject = JsonConvert.SerializeObject(history);
            Application.Current.Properties[Literals.History] = serializableObject;

            await Application.Current.SavePropertiesAsync();
        }

        private void StartTimer()
        {
            timer.Start();
            IsRunning = true;
        }

        private void StopTimer()
        {
            timer.Stop();
            IsRunning = false;
        }

        private void StartOrPauseExecuted()
        {
            if(IsRunning)
            {
                StopTimer();
            } else
            {
                StartTimer();
            }
        }
    }
}
