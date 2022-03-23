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

namespace Touch_Keyboard_AEP
{
    public partial class KeyboardKey : UserControl
    {
        public EventHandler<string> KeyDown = (s, e) => { };
        public EventHandler<string> KeyUp = (s, e) => { };

        SolidColorBrush background = new SolidColorBrush(Colors.DarkGray);
        SolidColorBrush backgroundPressed = new SolidColorBrush(Colors.Gray);

        public string KeyText
        {
            get { return (string)GetValue(KeyTextProperty); }
            set { SetValue(KeyTextProperty, value); }
        }
        public static readonly DependencyProperty KeyTextProperty =
            DependencyProperty.Register("KeyText", typeof(string), typeof(KeyboardKey), new PropertyMetadata("x"));

        public KeyboardKey()
        {
            InitializeComponent();
        }
        private void ButtonPressed()
        {
            border.Background = backgroundPressed;
            KeyDown(this, KeyText);
        }
        private void ButtonReleased()
        {
            border.Background = background;
            KeyUp(this, KeyText);
        }

        private void key_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ButtonPressed();
        }

        private void key_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ButtonReleased();
        }

        private void key_MouseLeave(object sender, MouseEventArgs e)
        {
            border.Background = background;
        }
    }
}
