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

namespace WPF_Keyboard
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.keyboard.KeyPressedEvent += (s, e) =>
            {
                tb1.Text = tb1.Text + e;
            };
            this.keyboard.DeleteKeyPressedEvent += (s, e) =>
            {
                if (tb1.Text != "")
                    tb1.Text = tb1.Text.Substring(0, tb1.Text.Length - 1);
            };
        }
    }
}
