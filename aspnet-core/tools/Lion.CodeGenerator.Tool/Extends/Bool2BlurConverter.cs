using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Effects;

namespace Lion.CodeGenerator.Tool.Extends
{
    public class Bool2BlurConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;
            if (value != null && bool.TryParse(value.ToString(), out result))
            {
                if (result)
                    return new BlurEffect() { Radius = 10 };
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
