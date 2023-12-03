using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace NailBar_App.Controllers
{
    public class ConvertIdEmail
    {
        private readonly string _resp;

        public ConvertIdEmail(string email)
        {
            _resp = Obtener(email.ToUpper());
        }

        public string GetResp()
        {
            return _resp;
        }

        private string Obtener(string email)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(email));
                BigInteger bi = new BigInteger(hash);
                long number = (long)(bi % BigInteger.Pow(10, 10));
                return number.ToString().Replace("-","");
            }
        }
    }
}
