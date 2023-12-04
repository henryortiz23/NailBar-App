using CommunityToolkit.Maui.Behaviors;
using Microsoft.Maui.Graphics.Text;
using System.Resources;
//using System.Drawing;

namespace NailBar_App
{
    public partial class App : Application
    {
        public App()
        {
            App.AccentColor = Colors.AliceBlue;
            InitializeComponent();
            App.AccentColor = Colors.AliceBlue;
            var statusBarColor = Microsoft.Maui.Graphics.Color.FromHex("#fbebff");
            var titleColor = Microsoft.Maui.Graphics.Color.FromHex("#9e42a5");
            //var navigationPage = new NavigationPage(new Views.LoginPage());
            //var navigationPage = new NavigationPage(new Views.PANTALLA_PRINCIPAL());
            var navigationPage = new NavigationPage(new Views.LoginPage());
            navigationPage.BarTextColor = titleColor;

            MainPage = navigationPage;

            MainPage.Behaviors.Add(new StatusBarBehavior { StatusBarColor = statusBarColor, StatusBarStyle= CommunityToolkit.Maui.Core.StatusBarStyle.DarkContent });
            
            
        }
    }
}