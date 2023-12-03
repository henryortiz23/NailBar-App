using NailBar_App.Models;

namespace NailBar_App.Views;

public partial class MainClientePage : ContentPage
{
    private Cliente usuarioActual;
    private string idUser;
	public MainClientePage(Cliente datosUsuario)
	{
		InitializeComponent();
        idUser = datosUsuario.Id;
        usuarioActual = datosUsuario;
    }

    private async void TapGestureHistorial(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Views.CitasPreviasPage(usuarioActual));
    }

    //private async void TapGestureCitaProxima(object sender, TappedEventArgs e)
    //{
        //await DisplayAlert("titulo", "Dio click para ver listado", "Ok");
    //    await MauiPopup.PopupAction.DisplayPopup(new PopupPage());
    //}

    private async void TapGesturePerfil(object sender, TappedEventArgs e)
    {
        await MauiPopup.PopupAction.DisplayPopup(new PerfilPage());

    }

    private async void TapGestureAgendarCita(object sender, TappedEventArgs e)
    {

        await Navigation.PushAsync(new Views.AgendarCitaClientePage(usuarioActual));
    }

    
}