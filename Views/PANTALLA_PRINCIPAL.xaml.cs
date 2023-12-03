namespace NailBar_App.Views;

public partial class PANTALLA_PRINCIPAL : ContentPage
{
    private Animation anima;// = new Animation();
    
	public PANTALLA_PRINCIPAL()
	{
		InitializeComponent();
        
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();


        
        
        /*
        Device.BeginInvokeOnMainThread(async () =>
        {
            while (true)
            {
                await imageAnimacion.RotateTo(360, 500);
                imageAnimacion.Rotation = 0;
            }
        });
        */


    }

    /*


     */
    private async void OnIniciarSesionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
    private async void OnRegistrarseClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
    private async void OnMainClienteClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new MainClientePage());
    }
    private async void OnAgendarCitaClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new AgendarCitaClientePage());
    }
    private async void OnCitasPreviasClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new CitasPreviasPage());
    }
    private async void OnPerfilClicked(object sender, EventArgs e)
    {
        await MauiPopup.PopupAction.DisplayPopup(new PerfilPage());
    }

    private async void OnCalificarClicked(object sender, EventArgs e)
    {
        await MauiPopup.PopupAction.DisplayPopup(new CalificarClientePage());
    }

    private async void OnEnviarEmailClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EnviarCorreoPage());
    }


    /*ADMINISTRADOR*/
    private async void OnMainAdminClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new MainAdminPage());
    }
    private async void OnAgendarCitaAdminClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgendarCitaAdminPage());
    }
    private async void OnCitasProximasAdminClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new ProximasCitasPage());
    }

    private async void OnCitasHistorialAdminClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorialCitasPage());
    }




    private async void OnEmailIdClicked(object sender, EventArgs e)
    {
        var getId0 = new Controllers.ConvertIdEmail("jerryortiz2100@gmail.com").GetResp();
        Console.WriteLine("CORREO Jerryortiz2100:" + getId0);
        var getIdx = new Controllers.ConvertIdEmail("JERRYORTIZ2100@GMAIL.COM").GetResp();
        Console.WriteLine("CORREO Jerryortiz2100:" + getIdx);

        var getId1 = new Controllers.ConvertIdEmail("usuario1@gmail.com").GetResp();
        Console.WriteLine("CORREO 1:" + getId1);
        var getId2 = new Controllers.ConvertIdEmail("usuario2@gmail.com").GetResp();
        Console.WriteLine("CORREO 1:" + getId2);
        var getId3 = new Controllers.ConvertIdEmail("usuario3@gmail.com").GetResp();
        Console.WriteLine("CORREO 1:" + getId3);
        var getId4 = new Controllers.ConvertIdEmail("usuario4@gmail.com").GetResp();
        Console.WriteLine("CORREO 1:" + getId4);
        var getId5 = new Controllers.ConvertIdEmail("usuario5@gmail.com").GetResp();
        Console.WriteLine("CORREO 1:" + getId5);


    }

}