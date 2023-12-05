using Firebase.Database;
using NailBar_App.Controllers;
using NailBar_App.Models;

namespace NailBar_App.Views
{
    public partial class LoginPage : ContentPage
    {
        int count = 0;
        private string idUsuario;

        public LoginPage()
        {
            InitializeComponent();
            getPrefences();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void OnIniciarClicked(object sender, EventArgs e)
        {
            if(ComprobarCampos())
            {
                Usuario usuario = await ComprobarExistUser();//Verifica si es usuario
                if (usuario==null)
                {
                    Cliente cliente = await ComprobarExistCliente();//Verifica si es cliente
                    if ( cliente== null)
                    {
                        await DisplayAlert("Cliente no encontrado","No encontramos ninguna cuenta asociada a los datos ingresados","Cerrar");
                    }
                    else
                    {
                        if (entPass.Text.Trim().Equals(cliente.Password))
                        {
                            setPrefences();
                            cliente.Id = idUsuario;
                            var titleColor = Color.FromHex("#9e42a5");

                            var navigationPage = new NavigationPage(new Views.MainClientePage(cliente));
                            
                            navigationPage.BarTextColor = titleColor;

                            await Navigation.PopAsync();
                            App.Current.MainPage = navigationPage;
                        }
                        else
                        {
                            await DisplayAlert("Contraseña incorrecta", "La contraseña ingresada es incorrecta", "Cerrar");
                        }
                    }
                }
                else
                {
                    if (entPass.Text.Trim().Equals(usuario.Password))
                    {
                        setPrefences();
                        usuario.Id= idUsuario;
                        var titleColor = Color.FromHex("#9e42a5");

                        var navigationPage = new NavigationPage(new Views.MainAdminPage(usuario));
                        navigationPage.BarTextColor = titleColor;

                        await Navigation.PopAsync();
                        App.Current.MainPage = navigationPage;

                    }
                    else
                    {
                        await DisplayAlert("Contraseña incorrecta", "La contraseña ingresada es incorrecta", "Cerrar");
                    }
                }
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            //await DisplayAlert("Titulo", "Mensage", "Ok");
        }

        private bool ComprobarCampos()
        {
            if ("".Equals(entCorreo.Text.Trim()) || "".Equals(entPass.Text.Trim()))
            {
                DisplayAlert("Campos vacios", "Uno o varios campos requeridos están vacios, por favor complete los mismos", "Cerrar");
                entCorreo.Focus();
                return false;
            }
            return true;
        }

        public async Task<Cliente> ComprobarExistCliente()
        {
            FirebaseClient _firebase;
            _firebase = new FirebaseClient(new Controllers.Config().GetUrlClientes());

            return await _firebase
                 .Child(idUsuario)
                 .OnceSingleAsync<Cliente>();
        }

        public async Task<Usuario> ComprobarExistUser()
        {
            idUsuario = new ConvertIdEmail(entCorreo.Text).GetResp();
            FirebaseClient _firebase;
            _firebase = new FirebaseClient(new Controllers.Config().GetUrlUsuarios());

            return await _firebase
                 .Child(idUsuario)
                 .OnceSingleAsync<Usuario>();
        }

        private async void getPrefences()
        {
            entCorreo.Text= Preferences.Default.Get("correo","");
            entPass.Text = Preferences.Default.Get("password", "");
        }

        private async void setPrefences()
        {
            Preferences.Default.Set("correo", entCorreo.Text.ToString());
            Preferences.Default.Set("password", entPass.Text.ToString());
        }
    }
}