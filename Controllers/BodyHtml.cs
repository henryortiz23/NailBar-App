using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailBar_App.Controllers
{

    public class BodyHtml
    {
        private readonly string _bodyString;

        public BodyHtml(string email, string cod)
        {
            _bodyString =
            "<div style='margin:0;padding:0' bgcolor='#FFFFFF'>\n" +
                "<table width='100%' height='100%' style='min-width:348px' border='0' cellspacing='0' cellpadding='0' lang='en'>\n" +
                    "<tbody>\n" +
                        "<tr height='32' style='height:32px'>\n" +
                            "<td></td>\n" +
                        "</tr>\n" +
                        "<tr align='center'>\n" +
                            "<td>\n" +
                                "<div>\n" +
                                    "<div></div>\n" +
                                "</div>\n" +
                                "<table border='0' cellspacing='0' cellpadding='0' style='padding-bottom:20px;max-width:516px;min-width:220px'>\n" +
                                    "<tbody>\n" +
                                        "<tr>\n" +
                                            "<td width='8' style='width:8px'></td>\n" +
                                            "<td>\n" +
                                                "<div style='border-style:solid;border-width:thin;border-color:#dadce0;border-radius:8px;padding:20px 20px' align='center'>\n" +
                                                    "<img src='https://www.dropbox.com/scl/fi/4kj7x31r2drnl3kh0k8ay/logo_NailBar.png?rlkey=xj06rz5u1umhnnkjsd9b5fz0j&dl=1' width='60' height='auto' aria-hidden='true' style='margin-bottom:16px' alt='NailBar'>\n" +
                                                    "<div style='border-bottom:thin solid #dadce0;color:rgba(0,0,0,0.87);line-height:32px;padding-bottom:24px;text-align:center;word-break:break-word'>\n" +
                                                        "<div style='font-size:24px;font-family:Arial,Helvetica,sans-serif;'>\n" +
                                                            "Código de verificación NailBar" + "\n" +
                                                        "</div>\n" +
                                                    "</div>\n" +
                                                    "<div style='font-size:14px;color:rgba(0,0,0,0.87);line-height:20px;padding-top:20px;text-align:left;font-family:Arial,Helvetica,sans-serif;'>\n" +
                                                        "<p style='text-decoration:none;color:rgba(0,0,0,0.87)'>\n" +
                                                            "Se ha proporcionado la dirección de correo electrónico "+
                                                            "<b>" + email + "</b> " + "para registrarse en nuestra app NailBar, por favor proporcione el código que se muestra a continuación." + "\n" +
                                                        "</p>\n" +
                                                        "<h1 align='center'>" + cod + "</h1>\n" +
                                                    "</div>\n" +
                                                    "<div>" + "Recuerde que el código proporcionado es necesario para completar el proceso de registro en NailBar" + "</div>\n" +
                                                "</div>\n\n" +
                                                "<div style='text-align:left'>\n" +
                                                    "<div style='font-family:Arial,Helvetica,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center'>\n" +
                                                        "<div>" + "Por favor no responda este correo, ya que el mismo es generado automáticamente y no obtendra respuesta alguna." + "</div>\n" +
                                                        "<div style='direction:ltr'>" + "© 2023" + "</div>\n" +
                                                    "</div>\n" +
                                                "</div>\n" +
                                            "</td>\n" +
                                            "<td width='8' style='width:8px'></td>\n" +
                                        "</tr>\n" +
                                    "</tbody>\n" +
                                "</table>\n" +
                            "</td>\n" +
                        "</tr>\n" +
                        "<tr height='32' style='height:32px'>\n" +
                            "<td></td>\n" +
                        "</tr>\n" +
                    "</tbody>\n" +
                "</table>\n" +
            "</div>";
        }

        public string GetBodyString()
        {
            return _bodyString;
        }
    }

}
