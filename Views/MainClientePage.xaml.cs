using NailBar_App.Models;
using NailBar_App.ViewModels;
using System.Diagnostics;
using System.Timers;



namespace NailBar_App.Views;

public partial class MainClientePage : ContentPage
{
    public static Cliente usuarioActual;
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

    private async void TapGesturePerfil(object sender, TappedEventArgs e)
    {
        await MauiPopup.PopupAction.DisplayPopup(new PerfilPage(usuarioActual));

    }

    private async void TapGestureAgendarCita(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Views.AgendarCitaClientePage(usuarioActual));
    }


    private async void TapGestureListado(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Views.ProximasCitasClientePage(usuarioActual));
    }


}