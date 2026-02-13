using Fen.Wpf.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fen.Wpf.Utils
{
    public class MenuHelper
    {
        public static List<MenuInfo> CreateMenus()
        {
            var list = new List<MenuInfo>();

            MenuInfo m1 = new MenuInfo("出入库管理", null);
            MenuInfo m2 = new MenuInfo("请假管理", null);
            MenuInfo m3 = new MenuInfo("考勤管理", null);

            MenuInfo m3_1 = new MenuInfo("日报管理", m3);
            MenuInfo m3_2 = new MenuInfo("请假管理", m3);

            MenuInfo m4 = new MenuInfo("商品管理", null);
            MenuInfo m4_1 = new MenuInfo("单位管理", m4);
            MenuInfo m4_2 = new MenuInfo("类别管理", m4);
            list.Add(m1);
            list.Add(m2);
            list.Add(m3);
            list.Add(m4);
            return list;
        }
    }
}
