using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using PM2Examen231051103.Modelos;


namespace PM2Examen231051103
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicacionesGuardados : ContentPage
    {
        private int id;
        private double latitud;
        private double longitud;
        private string descrilarga;
        private string descricorta;
        public UbicacionesGuardados()
        {
            InitializeComponent();
        }

        private void ubicacionesGuardadas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var ubicGuardada = e.SelectedItem as Direcciones;
            if (ubicGuardada != null)
            {
                id = ubicGuardada.Id;
                latitud = ubicGuardada.latitud;
                longitud = ubicGuardada.longitud;
                descrilarga = ubicGuardada.descriplarga;
                descricorta = ubicGuardada.descripcorta;
            }
            DisplayAlert("Aviso", "Se ha seleccionado a " + latitud + " de la lista de direcciones", "Ok");
        }

        private void eliminar_Clicked(object sender, EventArgs e)
        {

        }

        private async void vermapa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerMapa());
        }
    }
}