using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using PM2Examen231051103.Modelos;
using Plugin.Geolocator;
using Xamarin.Essentials;

namespace PM2Examen231051103
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var locacion = CrossGeolocator.Current;
            if (locacion.IsGeolocationEnabled)
            {
                var gps = await Geolocation.GetLocationAsync();
                longitudActual.Text = Convert.ToString(gps.Longitude);
                latitudActual.Text = Convert.ToString(gps.Latitude);
            }
            else 
            {
                DisplayAlert("Mensaje","Debes activar la UBICACION","Ok");
            }
            
        }

            private void salvarUbicacion_Clicked(object sender, EventArgs e)
        {
            if (descripLarga.Text != null)
            {
                if (descripCorta.Text != null)
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
                            DisplayAlert("Mensaje", "La ubicación a sido guardada", "Ok");
                        else
                            DisplayAlert("Mensaje", "Hubo un ERROR", "Ok");
                    }

                    resultado = 0;
                    var direcciones2 = new Direcciones()
                    {
                        latitud = 15.5074578,
                        longitud = -88.0356182,
                        descriplarga = "Primera Calle San Pedro Sula",
                        descripcorta = "Estadio Morazan"
                    };

                    using (SQLiteConnection connection = new SQLiteConnection(App.UbicacionDB))
                    {
                        connection.CreateTable<Direcciones>();
                        resultado = connection.Insert(direcciones2);
                    }

                    resultado = 0;
                    var direcciones3 = new Direcciones()
                    {
                        latitud = 15.4701217,
                        longitud = -88.0089433,
                        descriplarga = "33 Calle San Pedro Sula",
                        descripcorta = "Estadio Olimpico"
                    };

                    using (SQLiteConnection connection = new SQLiteConnection(App.UbicacionDB))
                    {
                        connection.CreateTable<Direcciones>();
                        resultado = connection.Insert(direcciones3);
                    }
                }
                else
                {
                    DisplayAlert("Mensaje", "Debe ingresar una Descripción Corta", "Ok");
                }
            }
            else 
            {
                DisplayAlert("Mensaje","Debe ingresar una Descripción Larga","Ok");
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

        private void nuevaUbic_Clicked(object sender, EventArgs e)
        {
            longitudActual.Text = "";
            latitudActual.Text = "";
            descripLarga.Text = "";
            descripCorta.Text = "";
        }
    }
}
