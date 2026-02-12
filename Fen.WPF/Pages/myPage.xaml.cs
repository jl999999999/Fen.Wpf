using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fen.Wpf.Pages
{
    /// <summary>
    /// myPage.xaml 的交互逻辑
    /// </summary>
    public partial class myPage : Page
    {
        private string param = string.Empty;
        public myPage()
        {
            InitializeComponent();
        }
        public myPage(string p) : this()
        {
            param = p;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(param?.ToString());
        }
    }
}
