using MauiPopup.Views;
using NailBar_App.Models;
using NailBar_App.ViewModels;

namespace NailBar_App.Views;

public partial class CalificarClientePage : BasePopupPage
{
    private Cliente usuarioActual;
    private int calificacion;
    private Cita citaActual;
    public CalificarClientePage(Cliente datosUsuario, Cita citaSeleccionada)
    {
        InitializeComponent();
        usuarioActual = datosUsuario;
        citaActual = citaSeleccionada;
    }

    private void OnCerrarClicked(object sender, EventArgs e)
    {
        MauiPopup.PopupAction.ClosePopup(new CalificarClientePage(usuarioActual, citaActual));
    }

    private void OnAceptarClicked(object sender, EventArgs e)
    {
        calificar();
    }

    private async void evaluate(object sender, EventArgs e)
    {
        if (sender is Image image) 
        {
            btnAceptar.IsEnabled = true;
            deseleccionar();
            int ob = int.Parse(image.AutomationId);
            switch (ob)
            {
                case 1:
                    star1.Source = "star2.svg";
                    calificacion = 1;
                    break;
                case 2:
                    star1.Source = "star2.svg";
                    star2.Source = "star2.svg";
                    calificacion = 2;
                    break;
                case 3:
                    star1.Source = "star2.svg";
                    star2.Source = "star2.svg";
                    star3.Source = "star2.svg";
                    calificacion = 3;
                    break;
                case 4:
                    star1.Source = "star2.svg";
                    star2.Source = "star2.svg";
                    star3.Source = "star2.svg";
                    star4.Source = "star2.svg";
                    calificacion = 4;
                    break;
                case 5:
                    star1.Source = "star2.svg";
                    star2.Source = "star2.svg";
                    star3.Source = "star2.svg";
                    star4.Source = "star2.svg";
                    star5.Source = "star2.svg";
                    calificacion = 5;
                    break;
            }

        }
    }

    private void deseleccionar()
    {
        star1.Source = "star1.svg";
        star2.Source = "star1.svg";
        star3.Source = "star1.svg";
        star4.Source = "star1.svg";
        star5.Source = "star1.svg";
    }

    private async void calificar()
    {
        
        ViewModelCitasFinalizadasAdmin modelAdminF = new ViewModelCitasFinalizadasAdmin(usuarioActual.Id, false);
        ViewModelCitasFinalizadasCliente modelClienteF = new ViewModelCitasFinalizadasCliente(citaActual.IdCliente, false);
        

        var newCita = new Cita
        {
            Cliente = citaActual.Cliente,
            IdAgente = citaActual.IdAgente,
            Agente = citaActual.Agente,
            Telefono = citaActual.Telefono,
            Estado = citaActual.Estado,
            Fecha = citaActual.Fecha,
            Hora = citaActual.Hora,
            Tipo = citaActual.Tipo,
            Precio = citaActual.Precio,
            Calificacion = calificacion.ToString(),
            Extra = citaActual.Extra,
            IdCliente = citaActual.IdCliente
        };

        await modelAdminF.UpdateData(citaActual.Id, newCita);
        await modelClienteF.UpdateData(citaActual.Id, newCita);

        await MauiPopup.PopupAction.ClosePopup(new CalificarClientePage(usuarioActual, citaActual));
    }
}