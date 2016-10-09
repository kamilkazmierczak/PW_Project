using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace mvvmtest
{
    public class YearToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter/*jak uzyc pokazane na slajdach*/, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Black;

            float price = (float)value;
            if(price < 2000)
            {
                brush.Color = Colors.Red;
            }
            else if (price > 3000)
            {
                brush.Color = Colors.Green;
            }
            else
            {
                brush.Color = Colors.Blue;
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
