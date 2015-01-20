using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Em.Workspace.Modules.MarketMaker.Converters
{
    public class SpotPriceColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return new SolidColorBrush(Colors.Green);
            }
            return new SolidColorBrush(Colors.DarkRed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
