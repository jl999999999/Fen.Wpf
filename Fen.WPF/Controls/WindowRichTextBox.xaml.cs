using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// WindowRichTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class WindowRichTextBox : Window
    {
        public WindowRichTextBox()
        {
            InitializeComponent();
            // 可选：动态添加超链接（如果需要代码生成，而非 XAML 静态定义）
            // AddHyperlinkDynamically("CSDN", "https://www.csdn.net");
        }

        /// <summary>
        /// 超链接点击事件：用默认浏览器打开
        /// </summary>
        private void Hyperlink_OpenInBrowser(object sender, RoutedEventArgs e)
        {
            if (sender is Hyperlink hyperlink && hyperlink.NavigateUri != null)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = hyperlink.NavigateUri.ToString(),
                        UseShellExecute = true, // .NET Core/.NET 5+ 必须设置为 true
                        Verb = "open" // 显式指定打开方式
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"打开链接失败：{ex.Message}", "错误",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// 动态向 RichTextBox 添加超链接
        /// </summary>
        /// <param name="linkText">超链接显示文本</param>
        /// <param name="url">跳转链接</param>
        private void AddHyperlinkDynamically(string linkText, string url)
        {
            // 创建新的段落
            Paragraph para = new Paragraph();
            para.Inlines.Add(new Run("动态添加的超链接："));

            // 创建超链接
            Hyperlink hyperlink = new Hyperlink
            {
                NavigateUri = new Uri(url),
                Cursor = Cursors.Hand,
                Foreground = Brushes.Blue,
                TextDecorations = TextDecorations.Underline
            };
            hyperlink.Inlines.Add(linkText);
            // 绑定点击事件
            hyperlink.Click += Hyperlink_OpenInBrowser;

            // 将超链接添加到段落
            para.Inlines.Add(hyperlink);
            para.Inlines.Add(new Run("\r\n"));

            // 将段落添加到 RichTextBox 的 FlowDocument
            richTB.Document.Blocks.Add(para);
        }
    }
}

