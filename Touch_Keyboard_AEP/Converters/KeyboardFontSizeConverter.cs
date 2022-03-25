using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Touch_Keyboard_AEP.Converters
{
    public class KeyboardFontSizeConverter
    {
        private static double KeyFont = 18;
        private static double KeyboardWidth = 800;
        private static double KeyboardHeight = 300;
        public double Convert(double value)
        {
            if (value != null)
            {
                var keyHeight = (double)value;
                var fontSize = keyHeight * (KeyFont / KeyboardHeight);
                return fontSize;
            }
            return KeyFont;
        }
    }
}
