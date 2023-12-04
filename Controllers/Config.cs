namespace NailBar_App.Controllers
{
    public class Config
    {
        private string UrlMain;
        private string UrlCitasPendientesAdmin;
        private string UrlCitasFinalizadasAdmin;
        private string UrlCitasPendientesCliente;
        private string UrlCitasFinalizadasCliente;
        private string UrlClientes;
        private string UrlUsuarios;

        public Config()
        {
            UrlMain = "https://nailbar-e4252-default-rtdb.firebaseio.com/NailBar/";
            UrlCitasPendientesAdmin = "Citas/PendientesAdmin/";
            UrlCitasFinalizadasAdmin = "Citas/FinalizadasAdmin/";
            UrlCitasPendientesCliente = "Citas/PendientesCliente/";
            UrlCitasFinalizadasCliente = "Citas/FinalizadasCliente/";
            UrlClientes = "Clientes/";
            UrlUsuarios = "Usuarios/";
        }
        public string GetUrlMain()
        {
            return UrlMain;
        }
        public string GetUrlCitasPendientesAdmin()
        {
            return UrlMain+UrlCitasPendientesAdmin;
        }
        public string GetUrlCitasFinalizadasAdmin()
        {
            return UrlMain + UrlCitasFinalizadasAdmin;
        }
        public string GetUrlCitasPendientesCliente()
        {
            return UrlMain + UrlCitasPendientesCliente;
        }
        public string GetUrlCitasFinalizadasCliente()
        {
            return UrlMain + UrlCitasFinalizadasCliente;
        }

        public string GetUrlClientes()
        {
            return UrlMain + UrlClientes;
        }
        public string GetUrlUsuarios()
        {
            return UrlMain + UrlUsuarios;
        }

    }

}
