using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DM_Xamarin1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        bool turnoJ1 = true;
        Button[] cuadrantes;
        List<Button> casillas = new List<Button>();

        public MainPage()
        {
            InitializeComponent();

            int cols = grid.ColumnDefinitions.Count;
            int rows = grid.RowDefinitions.Count;

            cuadrantes = new Button[cols * rows];
            
            for(int i = 0; i < cols; i++)
            {
                for(int k = 0; k < rows - 1; k++)
                {
                    Button labelModel = new Button();
                    labelModel.FontSize = 40;
                    labelModel.BackgroundColor = Color.FromHex("#fafafa");
                    labelModel.Clicked += GridTouch;

                    Grid.SetColumn(labelModel, i);
                    Grid.SetRow(labelModel, k);
                    grid.Children.Add(labelModel);
                    casillas.Add(labelModel);
                }
            }
        }
        
        public void GridTouch(object sender, EventArgs args)
        {
            Button currentBtn = sender as Button;
            currentBtn.Clicked -= GridTouch;
            currentBtn.Text = ToggleTouch();
        }

        public string ToggleTouch()
        {
            this.turnoJ1 = !this.turnoJ1;
            if (this.turnoJ1)
            {
                return "O";
            }
            return "X";
        }

        public void Limpiar(object sender, EventArgs args)
        {
            int cols = grid.ColumnDefinitions.Count;
            int rows = grid.RowDefinitions.Count;

            for (int i = 0; i < casillas.Count(); i++)
            {
                casillas[i].Text = "";
                casillas[i].Clicked += GridTouch;
            }
        }

        /*
        public void OnClick(object sender, EventArgs args)
        {
            if((Color)etiqueta.GetValue(Label.TextColorProperty) == Color.Blue)
            {
                etiqueta.TextColor = Color.Red;
            } else
            {
                etiqueta.TextColor = Color.Blue;
            }
        }
        */
    }
}
