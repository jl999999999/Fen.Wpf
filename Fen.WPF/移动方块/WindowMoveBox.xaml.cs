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

namespace Fen.Wpf.移动方块
{
    /// <summary>
    /// WindowMoveBox.xaml 的交互逻辑
    /// </summary>
    public partial class WindowMoveBox : Window
    {
        public WindowMoveBox()
        {
            InitializeComponent();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            UIElementCollection list = gridcontent.Children;
            Border b = null;
            foreach (UIElement item in list)
            {

                if (item is Border)
                {
                    if (((item as Border).Background as SolidColorBrush).Color == Colors.Yellow)
                    {
                        b = item as Border;

                    }
                    (item as Border).Background = new SolidColorBrush(Colors.Transparent);

                }
            }

            string name = b.Name;
            int index = Convert.ToInt32(name.Replace("B", ""));
            if (e.Key == Key.Up)
            {
                index = index - 3 >= 1 ? index - 3 : index;
            }
            else if (e.Key == Key.Down)
            {
                index = index + 3 <= 9 ? index + 3 : index;
            }
            else if (e.Key == Key.Left)
            {
                index = index - 1 >= 1 ? index - 1 : index;
            }
            else if (e.Key == Key.Right)
            {
                index = index + 1 <= 9 ? index + 1 : index;
            }

            var obj = gridcontent.FindName("B" + index);

            if (obj != null) { (obj as Border).Background = new SolidColorBrush(Colors.Yellow); }
        }
    }
}
