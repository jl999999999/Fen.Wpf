using System;
using System.Collections;
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
using System.Linq;

namespace Fen.Wpf.Controls
{
    /// <summary>
    /// WindowCheckBox.xaml 的交互逻辑
    /// </summary>
    public partial class WindowCheckBox : Window
    {
        public int CheckValue1 = 1;
        public int CheckValue2 = 2;
        public int CheckValue3 = 3;
        public WindowCheckBox()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            UIElementCollection list = gridmain.Children;
            StringBuilder str = new StringBuilder();
            foreach (UIElement item in list)
            {
                if (item is CheckBox && (item as CheckBox).IsChecked.Value)
                {
                    str.Append($"{(item as CheckBox).Content}:{(item as CheckBox).Tag.ToString()},");
                }

            }
            MessageBox.Show(str.ToString().Trim(','));
        }

    }
}
