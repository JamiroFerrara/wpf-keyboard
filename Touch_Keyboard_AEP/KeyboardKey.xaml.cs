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

        SolidColorBrush background = (SolidColorBrush)new BrushConverter().ConvertFrom("#9e9e9e");
        SolidColorBrush backgroundPressed = new SolidColorBrush(Colors.Gray);

        public double OriginalWidth { get; set; }
        public double OriginalHeight { get; set; }
        public double ClickedWidth { get { return OriginalWidth - 2; } }
        public double ClickedHeight { get { return OriginalHeight - 2; } }

        public string KeyText
        {
            get { return (string)GetValue(KeyTextProperty); }
            set { SetValue(KeyTextProperty, value); }
        }
        public double KFontSize
        {
            get { return (double)GetValue(KFontSizeProperty); }
            set { SetValue(KFontSizeProperty, value); }
        }

        public static readonly DependencyProperty KeyTextProperty =
            DependencyProperty.Register("KeyText", typeof(string), typeof(KeyboardKey), new PropertyMetadata("x"));

        public static readonly DependencyProperty KFontSizeProperty =
            DependencyProperty.Register("KFontSize", typeof(double), typeof(Keyboard), new PropertyMetadata(Convert.ToDouble(20)));

        public KeyboardKey()
        {
            InitializeComponent();
            this.Loaded += (s, e) => { this.OriginalWidth = this.Width; this.OriginalHeight = this.Height; };
        }

        private void ButtonPressed()
        {
            border.Background = backgroundPressed;
            this.Height = this.ClickedHeight;
            this.Width = this.ClickedWidth;

            KeyDown(this, KeyText);
        }
        private void ButtonReleased()
        {
            border.Background = background;
            this.Height = this.OriginalHeight;
            this.Width = this.OriginalWidth;

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
