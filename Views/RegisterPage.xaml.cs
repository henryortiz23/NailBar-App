using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using NailBar_App.Models;
using Firebase.Database;
using NailBar_App.Controllers;
using NailBar_App.ViewModels;
using System.ComponentModel;

namespace NailBar_App.Views;

public partial class RegisterPage : ContentPage
{
    private string codigo, idCliente;
    private double screenWidth;

    public RegisterPage()
    {
        InitializeComponent();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        entNombre.Text = "Henry Ortiz";
        entCorreo.Text = "henryortiz_m@hotmail.com";
        entPass.Text = "1234";
        entPass2.Text = "1234";
        entTelefono.Text = "12345678";
    }


    public async void OnIniciarSesionClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    public async void Register_Clicked(object sender, EventArgs e)
    {
        if (ComprobarCampos())
        {
            if (await ComprobarExistCliente() == null)
            {
                screenWidth = contenedor1.Width;
                contenedor1.WidthRequest = 0;
                contenedor3.WidthRequest = 0;
                contenedor2.WidthRequest = screenWidth;

                await Task.Run(() => EnviarCorreo());

                contenedor2.WidthRequest = 0;
                contenedor3.WidthRequest = screenWidth;
                entCode.Focus();
            }
            else
            {
                await DisplayAlert("Correo ya existe", "La dirección de correo  " + entCorreo.Text + " ya existe en nuestro sistema.", "Ok");
            }
        }

    }

    private async Task EnviarCorreo()
    {
        
        string user = "nailbarinf@gmail.com", passwd = "thjj atcl jfvt sdcv", smtp = "smtp.gmail.com";
        string destinatario = entCorreo.Text;

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtp);

            mail.From = new MailAddress(user);
            mail.To.Add(destinatario);
            mail.Subject = "Código de verificación NailBar";

            codigo = new Controllers.GeneratedCodeVerification().GetCode();
            
            string htmlBody = new Controllers.BodyHtml(destinatario, codigo).GetBodyString();

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");

            mail.AlternateViews.Add(htmlView);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential(user, passwd);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al enviar correo: " + ex.Message, "Ok");
        }
    }

    public async void Cancelar2(object sender, EventArgs e)
    {
        contenedor2.WidthRequest = 0;
        contenedor3.WidthRequest = 0;
        entCode.Text = string.Empty;
        contenedor1.WidthRequest = screenWidth;
        entNombre.Focus();

    }

    public async void Confirmar(object sender, EventArgs e)
    {
        if (codigo == entCode.Text)
        {
            CrearCliente(); 
        }
        else
        {
            await DisplayAlert("Código incorrecto", "El código proporcionado es incorrecto, por favor revise su correo y proporcione el codigo enviado", "Cerrar");
        }
    }

    public async Task<Cliente> ComprobarExistCliente()
    {
        idCliente = new ConvertIdEmail(entCorreo.Text).GetResp();
        FirebaseClient _firebase;
        _firebase = new FirebaseClient(new Controllers.Config().GetUrlClientes());

        return await _firebase
             .Child(idCliente)
             .OnceSingleAsync<Cliente>();
    }

    private async void CrearCliente()
    {
        Cliente newCliente = new Cliente
        {
            Nombre = entNombre.Text,
            Correo = entCorreo.Text,
            Telefono = entTelefono.Text,
            Password = entPass.Text,
            Latitud = "11111",
            Longitud = "11111",
            Imagen = ""
        };
        ViewModelClientes viewModel = new ViewModelClientes(idCliente, false);
        await viewModel.InsertData(newCliente);


        newCliente.Id = idCliente;
        var titleColor = Color.FromHex("#9e42a5");
        
        var navigationPage = new NavigationPage(new Views.MainClientePage(newCliente));
        navigationPage.BarTextColor = titleColor;

        await Navigation.PopAsync();
        App.Current.MainPage = navigationPage;
    }

    private bool ComprobarCampos()
    {
        if ("".Equals(entNombre.Text.Trim()) || "".Equals(entCorreo.Text.Trim()) || "".Equals(entTelefono.Text.Trim()) || "".Equals(entPass.Text.Trim()) || "".Equals(entPass.Text.Trim()))
        {
            DisplayAlert("Campos vacios","Uno o varios campos requeridos están vacios, por favor complete los mismos","Cerrar");
            entNombre.Focus();
            return false;
        } else if (!entPass.Text.Trim().Equals(entPass2.Text.Trim()))
        {
            DisplayAlert("Contraseñas no coinciden", "La contraseña proporcionada no coincide en ambos campos. Ingrese la misma contraseña en ambos campos por favor.", "Cerrar");
            entPass.Focus();
            return false;
        }
        return true;
    }
}