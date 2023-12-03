using NailBar_App.Models;
using NailBar_App.ViewModels;

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
}