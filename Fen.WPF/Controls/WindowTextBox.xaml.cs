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
    /// WindowTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class WindowTextBox : Window
    {
        public WindowTextBox()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mytextbox.Text = "这是点击后的内容";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"文本内容：{mytextbox.Text}，选中的文本内容：{mytextbox.SelectedText},选中文本起始索引：{mytextbox.SelectionStart}");
           
        }
    }
}
