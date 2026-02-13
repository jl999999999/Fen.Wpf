using System;
using System.Collections.Generic;
using System.Text;

namespace Fen.Wpf.Entity
{
    public class MenuInfo
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<MenuInfo> SubMenus { get; set; }

        public MenuInfo(string menuname, MenuInfo parentmenu)
        {
            MenuName = menuname;
            //将当前菜单挂载到父菜单下面
            if (parentmenu != null)
            {
                List<MenuInfo> list = parentmenu.SubMenus ?? new List<MenuInfo>();
                list.Add(this);
                parentmenu.SubMenus = list;

            }
        }
    }
}
