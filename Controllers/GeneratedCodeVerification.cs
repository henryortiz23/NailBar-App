using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailBar_App.Controllers
{
    public class GeneratedCodeVerification
    {
        private readonly string _code;

        public GeneratedCodeVerification()
        {
            Random random = new Random();
            StringBuilder codeBuilder = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                int num = random.Next(10);
                codeBuilder.Append(num);
            }
            _code = codeBuilder.ToString();
        }

        public string GetCode()
        {
            return _code;
        }
    }
}
