using NailBar_App.Models;
using System.Diagnostics;

namespace NailBar_App.Views;


public partial class MainAdminPage : ContentPage 
{
    private Usuario usuarioActual;
    private string idUser;
    public MainAdminPage(Usuario datosUsuario)
	{
		InitializeComponent();
        idUser = datosUsuario.Id;
        usuarioActual = datosUsuario;
        Debug.WriteLine("ID ADMINISTRADOR: "+usuarioActual.Id);
	}

    private async void TapGestureHistorial(object sender, TappedEventArgs e)
    {
        await DisplayAlert("titulo", "Dio click para ver historial", "Ok");
    }

    private async void TapGestureListado(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ProximasCitasPage(usuarioActual));
    }
}