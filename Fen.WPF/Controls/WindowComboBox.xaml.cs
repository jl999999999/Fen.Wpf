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

namespace Fen.Wpf.Controls
{
    /// <summary>
    /// WindowComboBox.xaml 的交互逻辑
    /// </summary>
    public partial class WindowComboBox : Window
    {
        public WindowComboBox()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            comboBox3.Items.Add("C#");
            comboBox3.Items.Add("java");
            comboBox3.Items.Add("C++");

            List<ClassInfo> list = new List<ClassInfo>();
            list.Add(new ClassInfo() { ClassName = "高三一班", Code = "301" });
            list.Add(new ClassInfo() { ClassName = "高三二班", Code = "302" });
            list.Add(new ClassInfo() { ClassName = "高三三班", Code = "303" });

            comboBox4.DataContext = list;
            comboBox4.DisplayMemberPath = "ClassName";
            comboBox4.SelectedValuePath = "Code";

            comboBox5.ItemsSource = list;
            comboBox5.DisplayMemberPath = "ClassName";
            comboBox5.SelectedValuePath = "Code";

        }
    }
}
