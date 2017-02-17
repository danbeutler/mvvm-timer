using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Dbe.Timer.SL.Helpers
{
    public class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new object();

            byte a;
            byte r;
            byte g;
            byte b;
            string val = value.ToString();

            if (val.Length > 7)
            {
                a = System.Convert.ToByte(val.Substring(1, 2), 16);
                r = System.Convert.ToByte(val.Substring(3, 2), 16);
                g = System.Convert.ToByte(val.Substring(5, 2), 16);
                b = System.Convert.ToByte(val.Substring(7, 2), 16);
            }
            else
            {
                a = 255;
                r = System.Convert.ToByte(val.Substring(1, 2), 16);
                g = System.Convert.ToByte(val.Substring(3, 2), 16);
                b = System.Convert.ToByte(val.Substring(5, 2), 16);
            }

            return new SolidColorBrush(Color.FromArgb(a, r, g, b));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
