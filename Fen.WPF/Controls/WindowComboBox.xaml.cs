using Fen.Wpf.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            List<ClassInfo> list1 = new List<ClassInfo>();
            list1.Add(new ClassInfo() { ClassName = "初三一班", Code = "31" });
            list1.Add(new ClassInfo() { ClassName = "初三二班", Code = "32" });
            list1.Add(new ClassInfo() { ClassName = "初三三班", Code = "33" });

            comboBox5.ItemsSource = list1;
            comboBox5.DisplayMemberPath = "ClassName";
            comboBox5.SelectedValuePath = "Code";

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var obj = comboBox3;
            if (obj.Items.Count == 0 || obj.Items == null)
                return;
            MessageBox.Show($"{obj.Text}，Items[0]={obj.Items?[0].ToString()}");
            obj.Items.RemoveAt(0);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var obj = comboBox4;

            var list = obj.DataContext as List<ClassInfo>;
            if (list.Count == 0 || list == null)
                return;
            MessageBox.Show($"{obj.Text}，DataContext[0]={list[0].ClassName}");
            list.RemoveAt(0);
            obj.DataContext = null;
            obj.DataContext = list;
            obj.DisplayMemberPath = "ClassName";
            obj.SelectedValuePath = "Code";
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var obj = comboBox5;

            var list = obj.ItemsSource as List<ClassInfo>;
            if (list.Count == 0 || list == null)
                return;
            MessageBox.Show($"{obj.Text}，ItemsSource[0]={list[0].ClassName}");
            list.RemoveAt(0);
            obj.ItemsSource = null;
            obj.ItemsSource = list;
            obj.DisplayMemberPath = "ClassName";
            obj.SelectedValuePath = "Code";
        }
    }
}
