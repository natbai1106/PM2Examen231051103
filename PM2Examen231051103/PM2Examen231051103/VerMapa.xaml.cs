using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace PM2Examen231051103
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerMapa : ContentPage
    {
        public VerMapa()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Pin ubicacion = new Pin();
            ubicacion.Label = corta.Text;
            ubicacion.Address = larga.Text;
            double latitudmapa = Convert.ToDouble(latitud.Text);
            double longitudmapa = Convert.ToDouble(longitud.Text);
            ubicacion.Position = new Position(latitudmapa, longitudmapa);
            ubicacion.Type = PinType.Place;
            mapas.Pins.Add(ubicacion);

            mapas.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitudmapa, longitudmapa),Distance.FromKilometers(1)));
        }
    }
}