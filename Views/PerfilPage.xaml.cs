using MauiPopup.Views;
using NailBar_App.Models;
using NailBar_App.ViewModels;

namespace NailBar_App.Views;

public partial class PerfilPage : BasePopupPage
{
    private  Cliente usuarioActual;
    public PerfilPage(Cliente datosCliente)
    {
        InitializeComponent();
        usuarioActual=datosCliente;

        entCorreo.Text = usuarioActual.Correo;
        entNombre.Text = usuarioActual.Nombre;
        entTelefono.Text = usuarioActual.Telefono;
    }

    private void OnCerrarClicked(object sender, EventArgs e)
    {
        MauiPopup.PopupAction.ClosePopup(new PerfilPage(usuarioActual));
    }

    private async void OnActualizarClicked(object sender, EventArgs e)
    {
        if (!entNombre.Text.Trim().Equals(usuarioActual.Nombre) || !entTelefono.Text.Trim().Equals(usuarioActual.Telefono))
        {
            ViewModelClientes viewModel = new ViewModelClientes("",false);
            Cliente newCliente = new Cliente
            {
              Imagen=usuarioActual.Imagen,
              Nombre= entNombre.Text.Trim(),
              Correo= usuarioActual.Correo,
              Password = usuarioActual.Password,
              Telefono= entTelefono.Text.Trim(),
              Latitud =usuarioActual.Latitud,
              Longitud = usuarioActual.Longitud
            };


            await viewModel.UpdateData(usuarioActual.Id, newCliente);
            await MauiPopup.PopupAction.ClosePopup(new PerfilPage(usuarioActual));

            newCliente.Id = usuarioActual.Id;
            MainClientePage.usuarioActual = newCliente;
        }

        
    }

    

}