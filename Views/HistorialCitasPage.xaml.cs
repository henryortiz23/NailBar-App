using NailBar_App.Models;
using NailBar_App.ViewModels;

namespace NailBar_App.Views;

public partial class HistorialCitasPage : ContentPage
{
    private ViewModelCitasFinalizadasAdmin _viewModel;
    private Usuario usuarioActual;
    public HistorialCitasPage(Usuario datosUsuario)
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
        _viewModel = new ViewModelCitasFinalizadasAdmin(usuarioActual.Id, true);
        BindingContext = _viewModel;
    }
}