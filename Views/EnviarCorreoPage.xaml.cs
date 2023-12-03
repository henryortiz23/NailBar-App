namespace NailBar_App.Views;

using System.Net;
using System.Net.Mail;

public partial class EnviarCorreoPage : ContentPage
{
	public EnviarCorreoPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string user = "nailbarinf@gmail.com", passwd = "thjj atcl jfvt sdcv", smtp= "smtp.gmail.com";
        string destinatario = "henryortiz_m@hotmail.com";
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtp);

            mail.From = new MailAddress(user);
            mail.To.Add(destinatario);
            mail.Subject = "Código de verificación NailBar";

            string _code = new Controllers.GeneratedCodeVerification().GetCode();
            string htmlBody = new Controllers.BodyHtml(destinatario,_code).GetBodyString();

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");

            mail.AlternateViews.Add(htmlView);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential(user, passwd);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al enviar correo: "+ex.Message, "Ok");
        }

    }
}