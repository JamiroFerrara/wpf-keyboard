using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Touch_Keyboard_AEP.Converters
{
    public class KeyWidthConverter : IValueConverter
    {
        private static double KeyWidth = 48.50;
        private static double KeyboardWidth = 800; //800:50
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var keyboardWidth = (double)value;
                var keyWidth = keyboardWidth / (KeyboardWidth / KeyWidth);
                return keyWidth;
            }
            return KeyWidth;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
