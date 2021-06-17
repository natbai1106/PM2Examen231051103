using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using PM2Examen231051103.Modelos;

namespace PM2Examen231051103
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        

        private void salvarUbicacion_Clicked(object sender, EventArgs e)
        {
            Int32 resultado = 0;

            var direcciones = new Direcciones()
            {
                latitud = Convert.ToDouble(latitudActual.Text),
                longitud = Convert.ToDouble(longitudActual.Text),
                descriplarga = Convert.ToString(descripLarga.Text),
                descripcorta = Convert.ToString(descripCorta.Text)
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.UbicacionDB))
            {
                connection.CreateTable<Direcciones>();
                resultado = connection.Insert(direcciones);

                if (resultado > 0)
                    DisplayAlert("Aviso", "Adicionado", "Ok");
                else
                    DisplayAlert("Aviso", "Error", "Ok");
            }
        }
        private async void ubicacionSalvadas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicacionesGuardados());
        }

        private async void ubicacionesSalvadas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicacionesGuardados());
        }
    }
}
