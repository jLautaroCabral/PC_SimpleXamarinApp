using DM_Xamarin1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DM_Xamarin1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Root();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
