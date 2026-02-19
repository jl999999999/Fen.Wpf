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
    /// WindowListBox.xaml 的交互逻辑
    /// </summary>
    public partial class WindowListBox : Window
    {
        public WindowListBox()
        {
            InitializeComponent();
        }



        private void PrintText(object sender, SelectionChangedEventArgs e)
        {
            var obj = sender as ListBox;
            if (obj != null) {
                tb.Text =obj.SelectionMode.ToString();
                foreach (ListBoxItem item in obj.SelectedItems)
                {
                    tb.Text += item.Content.ToString() + ".";
                }
            }


        }
        private void PrintText1(object sender, SelectionChangedEventArgs e)
        {
            var obj = sender as ListBox;
            if (obj != null)
            {
                tb.Text = obj.SelectionMode.ToString();
                foreach (var  item in obj.SelectedItems)
                {
                    tb.Text += item.ToString() + ".";
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.listbox.DataContext = new List<string>() { "1001", "1002", "1003", "1004", "1005", "1006" };
        }


    }
}
