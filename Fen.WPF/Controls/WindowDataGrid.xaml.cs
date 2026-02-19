using Fen.Wpf.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fen.Wpf.Controls
{
    /// <summary>
    /// WindowDataGrid.xaml 的交互逻辑
    /// </summary>
    public partial class WindowDataGrid : Window
    {
        // 自定义列的索引（你的自定义列是第5列，索引从0开始所以是4）
        private const int CustomColumnIndex = 4;
        public WindowDataGrid()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<UserInfo> list = new List<UserInfo>();
            list.Add(new UserInfo() { Name = "张三", Age = 20, DeptId = "1001" });
            list.Add(new UserInfo() { Name = "李四", Age = 25, DeptId = "1002" });
            list.Add(new UserInfo() { Name = "王五", Age = 30, DeptId = "1001" });
            grid1.DataContext = list;
            List<DeptInfo> dlist = new List<DeptInfo>();
            dlist.Add(new DeptInfo() { Id = "1001", DeptName = "技术部" });
            dlist.Add(new DeptInfo() { Id = "1002", DeptName = "销售部" });
            depts.ItemsSource = dlist;
            depts.DisplayMemberPath = "DeptName";
            depts.SelectedValuePath = "Id";
        }

        // 按钮点击：获取选中行数据
        private void BtnGetSelectedRow_Click(object sender, RoutedEventArgs e)
        {
            // 检查是否选中行
            if (grid1.SelectedItem == null)
            {
                MessageBox.Show("请先选中一行数据！");
                return;
            }

            // 核心：将选中项转换为UserInfo实体（强类型）
            UserInfo selectedUserInfo = grid1.SelectedItem as UserInfo;
            if (selectedUserInfo != null)
            {
                // 获取选中行的各个字段值
                string result = $"选中行数据：\n" +
                                $"Id：{selectedUserInfo.Id}\n" +
                                $"姓名：{selectedUserInfo.Name}\n" +
                                $"年龄：{selectedUserInfo.Age}\n" +
                                $"DeptId：{selectedUserInfo.DeptId}";
                MessageBox.Show(result);
            }
        }
        // 按钮点击：获取指定单元格数据
        private void BtnGetSpecificCell_Click(object sender, RoutedEventArgs e)
        {
            var list = grid1.DataContext as List<UserInfo>;
            if (list.Count == 0)
            {
                MessageBox.Show("DataGrid中无数据！");
                return;
            }

            // 示例：获取第2行（索引1）、年龄列的值（实体的Age属性）
            int rowIndex = 1; // 行索引从0开始（第2行）
            if (rowIndex < list.Count)
            {
                UserInfo targetUserInfo = list[rowIndex];
                int ageValue = targetUserInfo.Age; // 直接取实体属性
                MessageBox.Show($"第{rowIndex + 1}行，年龄值：{ageValue}");
            }
            else
            {
                MessageBox.Show("指定行不存在！");
            }
        }
        // 按钮点击：遍历所有行数据
        private void BtnTraverseAllRows_Click(object sender, RoutedEventArgs e)
        {
            var list = grid1.ItemsSource as List<UserInfo>;
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("DataGrid中无数据！");
                return;
            }



            string allTextValues = "所有行自定义列TextBox值：\n";
            for (int i = 0; i < list.Count; i++)
            {
                allTextValues += $"ID：{list[i].Id}，姓名：{list[i].Name}，年龄：{list[i].Age}，DeptId：{list[i].DeptId},";

                // 获取当前行的DataGridRow
                DataGridRow row = GetDataGridRow(grid1,i);
                if (row == null)
                {
                    allTextValues += $"第{i + 1}行：控件未加载\n";
                    continue;
                }

                DataGridCell celltextbox = GetDataGridCell(row, 4);
                if (celltextbox != null)
                {

       var textbox=  FindVisualChild<TextBox>(celltextbox);

                    // 5. 操作找到的控件
                    if (textbox != null )
                    {
                        allTextValues += $"自定义列1：{textbox.Text},";
                    }
                }

                //DataGridCell cellrad = GetDataGridCell(row, CustomColumnIndex + 1);
                //if (cellrad != null)
                //{
                //    // 3. 查找行中的TextBox（通过名称）
                //    var rad1 = FindVisualChildByName<RadioButton>(cellrad, "rad1");
                //    // 4. 查找行中的Button（通过名称）
                //    var rad0 = FindVisualChildByName<RadioButton>(cellrad, "rad0");

                //    // 5. 操作找到的控件
                //    if (rad1 != null && rad0 != null)
                //    {
                //        var sex = rad1.IsChecked == true ? "男" : rad0.IsChecked == true ? "女" : "";
                //        allTextValues += $"性别：{sex}\n";
                //    }
                //}

                // 3. 查找行中的TextBox（通过名称）
                var rad1 = FindVisualChildByName<RadioButton>(row, "rad1");
                // 4. 查找行中的Button（通过名称）
                var rad0 = FindVisualChildByName<RadioButton>(row, "rad0");

                // 5. 操作找到的控件
                if (rad1 != null && rad0 != null)
                {
                    var sex = rad1.IsChecked == true ? "男" : rad0.IsChecked == true ? "女" : "";
                    allTextValues += $"性别：{sex}\n";
                }
            }


            MessageBox.Show(allTextValues);
        }

        #region 核心：视觉树查找辅助方法
        /// <summary>
        /// 查找视觉树中的指定类型子控件
        /// </summary>
        public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T t)
                {
                    return t;
                }
                else
                {
                    var childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取指定行和列的DataGridCell
        /// </summary>
        public static DataGridCell GetDataGridCell(DataGridRow row, int columnIndex)
        {
            if (row == null) return null;

            // 获取单元格容器
            DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
            if (presenter == null)
            {
                // 强制加载单元格（解决虚拟化导致控件未创建的问题）
                row.ApplyTemplate();
                presenter = FindVisualChild<DataGridCellsPresenter>(row);
            }

            if (presenter == null) return null;
            // 获取指定索引的单元格
            return presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridCell;
        }

        // 【核心辅助方法】遍历可视化树，查找指定类型+名称的子控件
        public static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            if (parent == null) return null;

            T foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T childType && ((FrameworkElement)child).Name == name)
                {
                    foundChild = childType;
                    break;
                }
                else
                {
                    // 递归查找子控件
                    foundChild = FindVisualChildByName<T>(child, name);
                    if (foundChild != null) break;
                }
            }
            return foundChild;
        }

        // 【辅助方法】获取DataGrid指定行的DataGridRow对象
        public static DataGridRow GetDataGridRow(DataGrid dataGrid, int rowIndex)
        {
            // 确保行已加载（解决虚拟化导致的行未加载问题）
            dataGrid.ScrollIntoView(dataGrid.Items[rowIndex]);
            var rowContainer = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            return rowContainer;
        }

        #endregion
    }
}
