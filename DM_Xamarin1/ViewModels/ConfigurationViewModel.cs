using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DM_Xamarin1.ViewModels
{
    public class ConfigurationViewModel : NotificationObject
    {
        private ObservableCollection<int> pomodoroDurations;
        private ObservableCollection<int> breakDurations;

        private int selectedPomodoroDuration;
        private int selectedBreakDuration;

        public ICommand SaveCommand { get; set; }
        public ObservableCollection<int> PomodoroDurations { get {return pomodoroDurations;} set {pomodoroDurations = value; OnPropertyChanged();} }

        public ObservableCollection<int> BreakDurations
        {
            get { return breakDurations; }
            set { 
                breakDurations = value;
                OnPropertyChanged();
            }
        }

        public int SelectedPomodoroDuration
        {
            get { return selectedPomodoroDuration; }
            set { 
                selectedPomodoroDuration = value;
                OnPropertyChanged();
            }
        }

        public int SelectedBreakDuration
        {
            get { return selectedBreakDuration; }
            set { 
                selectedBreakDuration = value;
                OnPropertyChanged();
            }
        }

        public ConfigurationViewModel()
        {
            LoadPomodoroDurations();
            LoadBreakDurations();
            LoadConfiguration();
            SaveCommand = new Command(SaveCommandExecute);
        }

        private void LoadBreakDurations()
        {
            PomodoroDurations = new ObservableCollection<int>();
            PomodoroDurations.Add(1);
            PomodoroDurations.Add(5);
            PomodoroDurations.Add(10);
            PomodoroDurations.Add(25);
        }

        private void LoadPomodoroDurations()
        {
            BreakDurations = new ObservableCollection<int>();
            BreakDurations.Add(1);
            BreakDurations.Add(5);
            BreakDurations.Add(10);
            BreakDurations.Add(25);
        }

        private async void SaveCommandExecute()
        {
            Application.Current.Properties[Literals.PomodoroDuration] = SelectedPomodoroDuration;
            Application.Current.Properties[Literals.BreakDuration] = SelectedBreakDuration;

            await Application.Current.SavePropertiesAsync();
        }

        private void LoadConfiguration()
        {
            if(Application.Current.Properties.ContainsKey(Literals.PomodoroDuration))
            {
                SelectedPomodoroDuration = (int)Application.Current.Properties[Literals.PomodoroDuration];
            }
            if(Application.Current.Properties.ContainsKey(Literals.BreakDuration))
            {
                SelectedBreakDuration = (int)Application.Current.Properties[Literals.BreakDuration];
            }
        }

    }
}
