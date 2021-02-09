using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DM_Xamarin1.ViewModels
{
    public class RootViewModel : NotificationObject
    {

        private ObservableCollection<string> menuItems;

        public ObservableCollection<string> MenuItems
        {
            get { return menuItems; }
            set { menuItems = value; }
        }

        public RootViewModel()
        {
            MenuItems = new ObservableCollection<string>();
            MenuItems.Add("Pomodoro");
            MenuItems.Add("Historico");
            MenuItems.Add("Configuración");

            PropertyChanged += RootViewModel_PropertyChanged;
        }

        private void RootViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedMenuItem))
            {
                if(SelectedMenuItem == "Configuración")
                {
                    MessagingCenter.Send(this, "GoToConfiguration");
                }
                if (SelectedMenuItem == "Historico")
                {
                    MessagingCenter.Send(this, "GoToHistory");
                }
                if (SelectedMenuItem == "Pomodoro")
                {
                    MessagingCenter.Send(this, "GoToPomodoro");
                }
            }
        }

        private string selectedMenuItem;

        public string SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set { 
                selectedMenuItem = value; 
                OnPropertyChanged();
            }
        }
    }
}
