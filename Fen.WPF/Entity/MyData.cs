using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Fen.Wpf.Entity
{
   public  class MyData
    {
        private string colorName = "Red";
        private int width = 120;
        private string value = "默认值";
        private string title = "标题";


        public string ColorName { get => colorName; set => colorName = value; }
        public int Width { get => width; set => width = value; }
        public string Value { get => value; set => this.value = value; }
        public string Title { get => title; set => title = value; }
    }
}
