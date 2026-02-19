using Fen.Wpf.Utils;
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
    /// WindowTreeView.xaml 的交互逻辑
    /// </summary>
    public partial class WindowTreeView : Window
    {
        public WindowTreeView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tree1.DataContext = MenuHelper.CreateMenus();
        }
    }
}
