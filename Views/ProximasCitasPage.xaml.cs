using Microsoft.Maui.Controls.Compatibility;
using NailBar_App.Models;
using NailBar_App.ViewModels;
using System.Diagnostics;

namespace NailBar_App.Views;

public partial class ProximasCitasPage : ContentPage
{
    private ViewModelCitasPendientesAdmin _viewModel;
    private Usuario usuarioActual;
    public ProximasCitasPage(Usuario datosUsuario)
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
        _viewModel = new ViewModelCitasPendientesAdmin(usuarioActual.Id,true);
        BindingContext = _viewModel;
    }


    private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Cita selectedCita)
        {
            if (selectedCita != null)
            {
                bool resp = await DisplayAlert("Confirmar", "¿Desea marcar esta cita como finalizada?", "Sí", "No");

                if (resp)
                {
                    MarcarFinalizada(selectedCita);
                }
                
            }
        }
    }

    private async void MarcarFinalizada (Cita citaSeleccionada)
    {
        String idCliente = citaSeleccionada.IdCliente;
        ViewModelCitasPendientesAdmin modelAdminP = new ViewModelCitasPendientesAdmin(usuarioActual.Id,false);
        ViewModelCitasPendientesCliente modelClienteP = new ViewModelCitasPendientesCliente(citaSeleccionada.IdCliente, false);
        ViewModelCitasFinalizadasAdmin modelAdminF = new ViewModelCitasFinalizadasAdmin(usuarioActual.Id,false);
        ViewModelCitasFinalizadasCliente modelClienteF = new ViewModelCitasFinalizadasCliente(citaSeleccionada.IdCliente, false);
        await modelAdminP.DeleteData(citaSeleccionada.Id);
        await modelClienteP.DeleteData(citaSeleccionada.Id);

        var newCita = new Cita
        {
            Cliente = citaSeleccionada.Cliente,
            IdAgente= citaSeleccionada.IdAgente,
            Agente = citaSeleccionada.Agente,
            Telefono = citaSeleccionada.Telefono,
            Estado = "1",
            Fecha = citaSeleccionada.Fecha,
            Hora = citaSeleccionada.Hora,
            Tipo = citaSeleccionada.Tipo,
            Precio = citaSeleccionada.Precio,
            Calificacion = "0",
            Extra = citaSeleccionada.Extra,
            IdCliente = citaSeleccionada.IdCliente
        };

        await modelAdminF.InsertData(citaSeleccionada.Id, newCita);

        await modelClienteF.InsertData(citaSeleccionada.Id, newCita);
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