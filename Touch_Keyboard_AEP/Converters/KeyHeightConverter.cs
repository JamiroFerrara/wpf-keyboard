using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Touch_Keyboard_AEP.Converters
{
    public class KeyHeightConverter : IValueConverter
    {
        private static double KeyHeight = 48.50;
        private static double KeyboardHeight = 285; //300:50
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var keyboardHeight = (double)value;
                var keyHeight = keyboardHeight / (KeyboardHeight / KeyHeight);
                return keyHeight;
            }
            return KeyHeight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
