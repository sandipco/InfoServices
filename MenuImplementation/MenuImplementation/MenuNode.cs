using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuImplementation
{
    public class MenuNode
    {
        public List<MenuNode> ChildNodes { get; set; }
        public Menu MenuItem { get; set; }
        public MenuNode(Menu m)
        {
            ChildNodes = new List<MenuNode>();
            MenuItem = m;
        }
        public MenuNode AddNode(Menu menu)
        {
            MenuNode node = new MenuNode(menu);
            ChildNodes.Add(node);
            return node;
        }

    }
}
