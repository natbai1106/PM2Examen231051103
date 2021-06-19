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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection connection = new SQLiteConnection(App.UbicacionDB);
            connection.CreateTable<Direcciones>();
            var listadirecciones = connection.Table<Direcciones>().ToList();
            ubicacionesGuardadas.ItemsSource = listadirecciones;
            connection.Close();
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
            DisplayAlert("Aviso", "Se ha seleccionado a la ubicación con Latitud " + latitud + " y Longitud " + latitud, "Ok");
        }

        private void eliminar_Clicked(object sender, EventArgs e)
        {
            string x = Convert.ToString(id);

            SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
            var listadirecciones = conexion.Query<Direcciones>($"Delete FROM Direcciones WHERE Id = '" + x + "' ");
            conexion.Close();

            DisplayAlert("Aviso", "Se ha eliminado a la ubicación con Latitud " + latitud + " y Longitud " + latitud, "Ok");
        }

        private async void vermapa_Clicked(object sender, EventArgs e)
        {
            var irmapa = new irMapa()
            {
                mapaId = id,
                mapalatitud = latitud,
                mapalongitud = longitud,
                mapadescriplarga = descrilarga,
                mapadescripcorta = descricorta
            };
            var vermapa = new VerMapa();
            vermapa.BindingContext = irmapa;
            await Navigation.PushAsync(vermapa);
        }
    }
}