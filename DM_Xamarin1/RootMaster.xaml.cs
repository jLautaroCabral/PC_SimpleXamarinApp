using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DM_Xamarin1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootMaster : ContentPage
    {
        public ListView ListView;

        public RootMaster()
        {
            InitializeComponent();

            BindingContext = new RootMasterViewModel();
            ListView = MenuItemsListView;
        }

        class RootMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<RootMasterMenuItem> MenuItems { get; set; }

            public RootMasterViewModel()
            {
                MenuItems = new ObservableCollection<RootMasterMenuItem>(new[]
                {
                    new RootMasterMenuItem { Id = 0, Title = "Page 1" },
                    new RootMasterMenuItem { Id = 1, Title = "Page 2" },
                    new RootMasterMenuItem { Id = 2, Title = "Page 3" },
                    new RootMasterMenuItem { Id = 3, Title = "Page 4" },
                    new RootMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}