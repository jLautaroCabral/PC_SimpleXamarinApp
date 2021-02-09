using DM_Xamarin1.ViewModels;
using DM_Xamarin1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DM_Xamarin1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Root : MasterDetailPage
    {
        public Root()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<RootViewModel>(this, "GoToConfiguration", (a) =>
            {
                Detail = new NavigationPage(new ConfigurationView());
                IsPresented = true;
            });
            MessagingCenter.Subscribe<RootViewModel>(this, "GoToHistory", (a) =>
            {
                Detail = new NavigationPage(new HistoryView());
                IsPresented = true;
            });
            MessagingCenter.Subscribe<RootViewModel>(this, "GoToPomodoro", (a) =>
            {
                Detail = new NavigationPage(new PomodoroView());
                IsPresented = true;
            });
        }
    }
}