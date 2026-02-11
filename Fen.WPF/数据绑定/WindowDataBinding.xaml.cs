using Fen.Wpf.Entity;
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

namespace Fen.Wpf.数据绑定
{
    /// <summary>
    /// WindowDataBinding.xaml 的交互逻辑
    /// </summary>
    public partial class WindowDataBinding : Window
    {
        public WindowDataBinding()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyLabel.DataContext = new MyData() {Title="标题001" };
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("按钮被点击！");

        }


    }
}
