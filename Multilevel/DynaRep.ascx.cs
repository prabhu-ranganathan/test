using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Multilevel
{
    public partial class DynaRep : System.Web.UI.UserControl
    {
        List<MenuItem> _FirstLevelMenuItems = new List<MenuItem>();
        List<MenuItem> SecondLevelMenuItems = new List<MenuItem>();
        List<MenuItem> _SecondLevelMenuItems1 = new List<MenuItem>();
        List<MenuItem> _SecondLevelMenuItems2 = new List<MenuItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
          
            _FirstLevelMenuItems.Clear();
            _SecondLevelMenuItems1.Clear();
            _SecondLevelMenuItems2.Clear();

            //Create first level menu items.
            MenuItem mi1 = new MenuItem("First Level -  Menu item 1", "First Level -  Menu item 1", "#Menu1");
            MenuItem mi2 = new MenuItem("First Level -  Menu item 2", "First Level -  Menu item 2", "#Menu2");
            MenuItem mi3 = new MenuItem("First Level -  Menu item 3", "First Level -  Menu item 3", "#Menu3");
            MenuItem mi4 = new MenuItem("First Level -  Menu item 4", "First Level -  Menu item 4", "#Menu4");

            _FirstLevelMenuItems.Add(mi1);
            _FirstLevelMenuItems.Add(mi2);
            _FirstLevelMenuItems.Add(mi3);
            _FirstLevelMenuItems.Add(mi4);

            //Create second level menu items.
            MenuItem submenuitem1 = new MenuItem("Second Level -  Menu item 1", "Second Level -  Menu item 1", "#SubMenu1");
            MenuItem submenuitem2 = new MenuItem("Second Level -  Menu item 2", "Second Level -  Menu item 2", "#SubMenu2");
            MenuItem submenuitem3 = new MenuItem("Second Level -  Menu item 3", "Second Level -  Menu item 3", "#SubMenu3");
            MenuItem submenuitem4 = new MenuItem("Second Level -  Menu item 4", "Second Level -  Menu item 4", "#SubMenu4");

            _SecondLevelMenuItems1.Add(submenuitem1);
            _SecondLevelMenuItems1.Add(submenuitem2);
            _SecondLevelMenuItems2.Add(submenuitem3);
            _SecondLevelMenuItems2.Add(submenuitem4);

            FirstLevelMenuRepeater.DataSource = _FirstLevelMenuItems;
            FirstLevelMenuRepeater.DataBind();
        }



        private class MenuItem
        {
            string _Title;
            string _Desc;
            string _Url;

            public MenuItem()
            {
            }
            public MenuItem(string title, string desc, string Url)
            {
                _Title = title;
                _Desc = desc;
                _Url = Url;
            }

            public string Title
            {
                get
                {
                    return _Title;
                }
                set
                {
                    _Title = value;
                }
            }

            public string Desc
            {
                get
                {
                    return _Desc;
                }
                set
                {
                    _Desc = value;
                }
            }

            public string Url
            {
                get
                {
                    return _Url;
                }
                set
                {
                    _Url = value;
                }
            }

        }

        protected void FirstLevelMenuRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                string Title = DataBinder.Eval(e.Item.DataItem, "Title").ToString().Trim();
                SecondLevelMenuItems.Clear();
                GetSubMenuItems(Title, SecondLevelMenuItems);
                Repeater FourthLevelMenuRepeater = (Repeater)e.Item.FindControl("SecondLevelMenuRepeater");
                FourthLevelMenuRepeater.DataSource = SecondLevelMenuItems;
                FourthLevelMenuRepeater.DataBind();
            }
        }

        private void GetSubMenuItems(string Title, List<MenuItem> MenuItems)
        {
            if (Title == "First Level -  Menu item 1")
            {
                MenuItems = _SecondLevelMenuItems1;
            }
            else if (Title == "First Level -  Menu item 2")
            {
                MenuItems = _SecondLevelMenuItems2;
            }
            SecondLevelMenuItems = MenuItems;
        }
    }
}