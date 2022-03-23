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
    public partial class Keyboard : UserControl
    {
        public EventHandler<string> KeyPressedEvent = (s, e) => { };
        private bool isUppercase = false;

        public Keyboard()
        {
            InitializeComponent();
            InitializeKeypressEvents();
        }

        private void InitializeKeypressEvents()
        {
            foreach (var child in gRow1.Children)
            {
                var key = child as KeyboardKey;
                key.KeyUp += (s, e) => { Keypressed(e); };
            }
            foreach (var child in gRow2.Children)
            {
                var key = child as KeyboardKey;
                key.KeyUp += (s, e) => { Keypressed(e); };
            }
            foreach (var child in gRow3.Children)
            {
                var key = child as KeyboardKey;
                key.KeyUp += (s, e) => { Keypressed(e); };
            }
            foreach (var child in gRow4.Children)
            {
                var key = child as KeyboardKey;

                if (key.KeyText != "MAIUSC")
                    key.KeyUp += (s, e) => { Keypressed(e); };
            }
            foreach (var child in gRow5.Children)
            {
                var key = child as KeyboardKey;
                key.KeyUp += (s, e) => { Keypressed(e); };
            }
        }
        private void Keypressed(string key)
        {
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

                    if (key.KeyText != "MAIUSC")
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

                    if (key.KeyText != "MAIUSC")
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
