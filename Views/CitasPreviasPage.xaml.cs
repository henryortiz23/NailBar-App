using NailBar_App.Models;
using NailBar_App.ViewModels;

namespace NailBar_App.Views;

public partial class CitasPreviasPage : ContentPage
{
    private ViewModelCitasPreviasCliente _viewModel;
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
        _viewModel = new ViewModelCitasPreviasCliente(usuarioActual.Id);
        BindingContext = _viewModel;
    }
}