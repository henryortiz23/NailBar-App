using Microsoft.Maui.Graphics.Text;
using System.Diagnostics;
using System.Globalization;

namespace NailBar_App.Controllers
{
    public class Star1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valor =int.Parse(value.ToString()) ;
            if (valor > 0)
                return "star2.svg";

            return "star1.svg";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Star2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valor = int.Parse(value.ToString());
            if (valor > 1)
                return "star2.svg";

            return "star1.svg"; 
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Star3 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valor = int.Parse(value.ToString());
            if (valor > 2)
                return "star2.svg";

            return "star1.svg"; 
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Star4 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valor = int.Parse(value.ToString());
            if (valor > 3)
                return "star2.svg";

            return "star1.svg"; 
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Star5 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valor = int.Parse(value.ToString());
            if (valor > 4)
                return "star2.svg";

            return "star1.svg"; 
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}