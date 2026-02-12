using Fen.Wpf.Pages;
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
using System.Windows.Shapes;

namespace Fen.Wpf.Controls
{
    /// <summary>
    /// WindowFrame.xaml 的交互逻辑
    /// </summary>
    public partial class WindowFrame : Window
    {
        public WindowFrame()
        {
            InitializeComponent();
        }

        private void Button_Click_page(object sender, RoutedEventArgs e)
        {
            myframe.Navigate(new myPage("这是参数"));//使用对象
            //myframe.Source = new Uri("../Pages/myPage.xaml", UriKind.Relative);//相对路径
        }

        private void Button_Click_baidu(object sender, RoutedEventArgs e)
        {
            //使用uri
            myframe.Source = new Uri("https://www.baidu.com");
        }
    }
}
