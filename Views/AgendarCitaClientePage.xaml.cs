using Firebase.Database;
using NailBar_App.Controllers;
using NailBar_App.Models;
using NailBar_App.ViewModels;
using System.Diagnostics;

namespace NailBar_App.Views;

public partial class AgendarCitaClientePage : ContentPage
{
    private readonly ViewModelCitasPendientesCliente _viewModel;
    private readonly ViewModelUsuarios _viewModelUsuarios;
    private string idEmpl;
    private string idCliente;
    private string nomAgente;
    private List<string> listHoras;
    private Cliente usuarioActual;
    public AgendarCitaClientePage(Cliente datosCliente)
    {
        InitializeComponent();
        idCliente = datosCliente.Id;
        usuarioActual = datosCliente;
        _viewModel = new ViewModelCitasPendientesCliente(idCliente,false);
        _viewModelUsuarios = new ViewModelUsuarios("");
        
        BindingContext = _viewModelUsuarios;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        cargarHoras();
    }


    private async void CrearCitaClicked(object sender, EventArgs e)
    {
        string nFecha = datFecha.Date.ToShortDateString();
        string hHora = datHora.SelectedItem.ToString();
        string hIndex = datHora.SelectedIndex.ToString();
        string idItem = nFecha.Replace("/", "") + "_" + hIndex;

        var newCita = new Cita
        {
            Cliente = usuarioActual.Nombre,
            Agente = nomAgente,
            IdAgente=idEmpl,
            Telefono= usuarioActual.Telefono,
            Estado = "0",
            Fecha = nFecha,
            Hora = hHora,
            Tipo = picServicios.SelectedItem.ToString(),
            Precio = entPrecio.Text,
            Calificacion = "0",
            Extra = ediInfoExtra.Text,
            IdCliente= usuarioActual.Id
        };
        
        if (await ComprobarAdmin(idItem) == null) 
        {
            if (await ComprobarCliente(idItem) == null)
            {
                await _viewModel.InsertData(hIndex, newCita);
                ViewModelCitasPendientesAdmin tempViewModel = new ViewModelCitasPendientesAdmin(idEmpl,false);
                await tempViewModel.InsertData(hIndex, newCita);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("No disponible", "Usted ya cuenta con una cita a la fecha y hora seleccionada", "Cerrar");
            }
        }
        else
        {
            await DisplayAlert("No disponible","La agente seleccionada ya tiene ocupada la fecha y hora seleccionada","Cerrar");
        }

    }
    private void SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedIndex = picServicios.SelectedIndex;
        if (selectedIndex != -1)
        {
            string precio = "0.00";

            switch (selectedIndex)
            {
                case 0:
                    precio = "150.00";
                    break;
                case 1:
                    precio = "130.00";
                    break;
                case 2:
                    precio = "200.00";
                    break;
                case 3:
                    precio = "300.00";
                    break;
            }
            entPrecio.Text = precio;
        }
    }


    private void SelectedIndexChangedEmpleados(object sender, EventArgs e)
    {
        var selectedIndex = picEmpleados.SelectedIndex;
        if (selectedIndex != -1)
        {
            limpiar();
            Usuario user = _viewModelUsuarios.DataItems[selectedIndex];
            idEmpl = user.Id;
            nomAgente = user.Nombre;
        }
    }

    private void limpiar()
    {
        picServicios.SelectedItem = string.Empty;
        entPrecio.Text = string.Empty;
        datFecha.Date = DateTime.Now;
        datHora.SelectedIndex = -1;
        ediInfoExtra.Text = string.Empty;
    }


    private async void CancelarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void cargarHoras()
    {
        listHoras = new List<string> {
            "01:00 pm",
            "01:30 pm",
            "02:00 pm",
            "02:30 pm",
            "03:00 pm",
            "03:30 pm",
            "04:00 pm",
            "04:30 pm",
            "05:00 pm",
            "05:30 pm",
            "06:00 pm",
            "06:30 pm"
        };
        datHora.ItemsSource = listHoras;
    }

    public async Task<Cita> ComprobarAdmin(string idItem)
    {

        FirebaseClient _firebase;
        _firebase = new FirebaseClient(new Config().GetUrlCitasPendientesAdmin() + idEmpl);

       return await _firebase
            .Child(idItem)
            .OnceSingleAsync<Cita>();
    }

    public async Task<Cita> ComprobarCliente(string idItem)
    {
        
        FirebaseClient _firebase;
        _firebase = new FirebaseClient(new Controllers.Config().GetUrlCitasPendientesCliente() + idCliente);

        return await _firebase
             .Child(idItem)
             .OnceSingleAsync<Cita>();
    }
}