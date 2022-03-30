using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Touch_Keyboard_AEP.Converters;

namespace Touch_Keyboard_AEP
{
    public partial class Keyboard : UserControl
    {
        public EventHandler<string> KeyPressedEvent = (s, e) => { };
        public EventHandler<string> DeleteKeyPressedEvent = (s, e) => { };
        private bool isUppercase = false;

        public Key_Layouts.KeyLayouts Layout
        {
            get { return (Key_Layouts.KeyLayouts)GetValue(LayoutProperty); }
            set { SetValue(LayoutProperty, value); }
        }
        public double KeyFontSize
        {
            get { return (double)GetValue(KeyFontSizeProperty); }
            set { SetValue(KeyFontSizeProperty, value); }
        }

        public static readonly DependencyProperty LayoutProperty =
            DependencyProperty.Register("Layout", typeof(Key_Layouts.KeyLayouts), typeof(Keyboard), new PropertyMetadata(Key_Layouts.KeyLayouts.ITA_QWERTY));
        public static readonly DependencyProperty KeyFontSizeProperty =
            DependencyProperty.Register("KeyFontSize", typeof(double), typeof(Keyboard), new PropertyMetadata(Convert.ToDouble(20)));

        public Keyboard()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                InitializeKeypressEvents();
                InitLayout();
            };
        }
        private void InitLayout()
        {
            switch (Layout)
            {
                case Key_Layouts.KeyLayouts.ITA_QWERTY:
                    var layout = Key_Layouts.ITA_QWERTY.GetLayout();
                    int count = 0;
                    foreach (var key in layout)
                    {
                        string name = "k" + count.ToString();
                        var res = this.FindName(name);
                        KeyboardKey keyboardKey = (KeyboardKey)res;
                        keyboardKey.KeyText = key;
                        count++;
                    }
                    break;
            }
        }
        private void InitializeKeypressEvents()
        {
            KeyboardFontSizeConverter converter = new KeyboardFontSizeConverter();

            foreach (var child in gRow1.Children)
            {
                var key = child as KeyboardKey;
                key.txtText.FontSize = converter.Convert(this.ActualHeight);
                key.KeyUp += (s, e) => { Keypressed(e); };
            }
            foreach (var child in gRow2.Children)
            {
                var key = child as KeyboardKey;
                key.txtText.FontSize = converter.Convert(this.ActualHeight);
                key.KeyUp += (s, e) => { Keypressed(e); };
            }
            foreach (var child in gRow3.Children)
            {
                var key = child as KeyboardKey;
                key.txtText.FontSize = converter.Convert(this.ActualHeight);
                key.KeyUp += (s, e) => { Keypressed(e); };
            }
            foreach (var child in gRow4.Children)
            {
                var key = child as KeyboardKey;
                key.txtText.FontSize = converter.Convert(this.ActualHeight);

                if (key.KeyText != "⇪")
                    key.KeyUp += (s, e) => { Keypressed(e); };
            }

            kSpace.KeyUp += (s, e) => { Keypressed(e); };
        }
        private void Keypressed(string key)
        {
            if (key == "←")
                DeleteKeyPressedEvent(this, key);
            else
                KeyPressedEvent(this, key);
        }
        private void SwitchUppercase()
        {
            if (!isUppercase)
            {
                foreach (var child in gRow1.Children)
                {
                    var key = child as KeyboardKey;
                    key.KeyText = key.KeyText.ToUpper();
                }
                foreach (var child in gRow2.Children)
                {
                    var key = child as KeyboardKey;
                    key.KeyText = key.KeyText.ToUpper();
                }
                foreach (var child in gRow3.Children)
                {
                    var key = child as KeyboardKey;
                    key.KeyText = key.KeyText.ToUpper();
                }
                foreach (var child in gRow4.Children)
                {
                    var key = child as KeyboardKey;

                    if (key.KeyText != "⇪")
                        key.KeyText = key.KeyText.ToUpper();
                }
                isUppercase = true;
            }
            else
            {
                foreach (var child in gRow1.Children)
                {
                    var key = child as KeyboardKey;
                    key.KeyText = key.KeyText.ToLower();
                }
                foreach (var child in gRow2.Children)
                {
                    var key = child as KeyboardKey;
                    key.KeyText = key.KeyText.ToLower();
                }
                foreach (var child in gRow3.Children)
                {
                    var key = child as KeyboardKey;
                    key.KeyText = key.KeyText.ToLower();
                }
                foreach (var child in gRow4.Children)
                {
                    var key = child as KeyboardKey;

                    if (key.KeyText != "⇪")
                        key.KeyText = key.KeyText.ToLower();
                }
                isUppercase = false;
            }
        }
        private void Uppercase_Down(object sender, MouseButtonEventArgs e)
        {
            SwitchUppercase();
        }
    }
}
