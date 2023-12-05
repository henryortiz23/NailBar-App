using Microsoft.Maui.Controls.Compatibility;
using NailBar_App.Models;
using NailBar_App.ViewModels;
using System.Diagnostics;

namespace NailBar_App.Views;

public partial class ProximasCitasClientePage : ContentPage
{
    private ViewModelCitasPendientesCliente _viewModel;
    private Cliente usuarioActual;
    public ProximasCitasClientePage(Cliente datosUsuario)
	{
		InitializeComponent();

        usuarioActual = datosUsuario;
        cargarDatos();
    }

    private async void cargarDatos()
    {
        await Task.Run(() => getDatos());
    }

    private async Task getDatos()
    {
        _viewModel = new ViewModelCitasPendientesCliente(usuarioActual.Id,true);
        BindingContext = _viewModel;
    }


    private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Cita selectedCita)
        {
            if (selectedCita != null)
            {
                bool resp = await DisplayAlert("Confirmar", "¿Desea eliminar esta cita?", "Sí", "No");

                if (resp)
                {
                    MarcarFinalizada(selectedCita);
                }
                
            }
        }
    }

    private async void MarcarFinalizada (Cita citaSeleccionada)
    {
        ViewModelCitasPendientesAdmin modelAdminP = new ViewModelCitasPendientesAdmin(usuarioActual.Id,false);
        ViewModelCitasPendientesCliente modelClienteP = new ViewModelCitasPendientesCliente(citaSeleccionada.IdCliente, false);
        await modelAdminP.DeleteData(citaSeleccionada.Id);
        await modelClienteP.DeleteData(citaSeleccionada.Id);
    }

    private async void Frame_Tapped(object sender, EventArgs e)
    {
        if (sender is Frame frame)
        {
            if (frame.BindingContext is Cita selectedItem)
            {
                list.SelectedItem = selectedItem;
            }
        }
    }

}