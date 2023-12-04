using Firebase.Database;
using NailBar_App.Models;
using NailBar_App.ViewModels;
using System.Diagnostics;

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

        cargarCitaProxima();
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

    private async void cargarCitaProxima()
    {
        await Task.Run(() => ObtenerCitaProxima(contenedor1, contenedor2));
        contenedor1.IsVisible = true;
    }

    private async Task ObtenerCitaProxima(StackLayout cont1, StackLayout cont2)
    {
        DateTime dateNow = DateTime.Now.Date;
        
        Debug.WriteLine("FECHA ACTUAL: " + dateNow);
        ViewModelCitasPendientesCliente viewModel = new ViewModelCitasPendientesCliente(usuarioActual.Id, true);

        BindingContext = viewModel;
        Debug.WriteLine("TAMANIO EN DATAITEMS: " + viewModel.DataItems.Count);
        
        foreach (var item in viewModel.DataItems)
        {
            /*
            DateTime fecha;
            if (DateTime.TryParseExact(item.Fecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha))
            {
                Console.WriteLine("CONVERSION EXITOSA: "+fecha);
            }
            else
            {
                Console.WriteLine("Formato de fecha inválido");
            }*/
            Debug.WriteLine("FECHA DEL ITEM: "+item.Fecha);


        }

        //cont2.IsVisible = false;
        //cont1.IsVisible = true;
    }

}