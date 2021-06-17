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
            ubicacion.Label = "San Pedro Sula";
            ubicacion.Address = "Cerca Sede del Marathon";
            ubicacion.Position = new Position(15.495831, -88.001563);
            ubicacion.Type = PinType.Place;
            mapas.Pins.Add(ubicacion);

            var localizacion = await Geolocation.GetLastKnownLocationAsync();
            if (localizacion == null)
            {
                localizacion = await Geolocation.GetLocationAsync();
            }
            mapas.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(localizacion.Latitude, localizacion.Longitude),Distance.FromKilometers(1)));
        }
    }
}