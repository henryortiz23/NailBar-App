using NailBar_App.Models;
using NailBar_App.ViewModels;

namespace NailBar_App.Views;

public partial class CitasPreviasPage : ContentPage
{
    private ViewModelCitasFinalizadasCliente _viewModel;
    private Cliente usuarioActual;
    public CitasPreviasPage(Cliente datosUsuario)
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
        _viewModel = new ViewModelCitasFinalizadasCliente(usuarioActual.Id,true);
        BindingContext = _viewModel;
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

    private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Cita selectedCita)
        {
            if (selectedCita != null)
            {
                bool resp;
                if (int.Parse(selectedCita.Calificacion) > 0)
                {
                    resp = await DisplayAlert("Confirmar", "¿Desea volver a calificar esta cita?", "Sí", "No");
                }
                else
                {
                    resp = await DisplayAlert("Confirmar", "¿Desea calificar esta cita?", "Sí", "No");
                }

                if (resp)
                {
                    Calificar(selectedCita);
                }

            }
        }
    }

    private async void Calificar(Cita citaSeleccionada)
    {
        await MauiPopup.PopupAction.DisplayPopup(new CalificarClientePage(usuarioActual, citaSeleccionada));
        //ViewModelCitasPendientesAdmin modelAdminP = new ViewModelCitasPendientesAdmin(usuarioActual.Id, false);
        //ViewModelCitasPendientesCliente modelClienteP = new ViewModelCitasPendientesCliente(citaSeleccionada.IdCliente, false);
        //ViewModelCitasFinalizadasAdmin modelAdminF = new ViewModelCitasFinalizadasAdmin(usuarioActual.Id,false);
        //ViewModelCitasFinalizadasCliente modelClienteF = new ViewModelCitasFinalizadasCliente(citaSeleccionada.IdCliente, false);
        //await modelAdminP.DeleteData(citaSeleccionada.Id);
        //await modelClienteP.DeleteData(citaSeleccionada.Id);
    }
}