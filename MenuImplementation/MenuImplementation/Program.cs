using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuImplementation
{
    class Program
    {
        static List<Menu> menuCollection;
        static IExceptionLogger _exLogger;
        
        
        static void Main(string[] args)
        {
            _exLogger = new ExceptionLogger();
            try
            {
                menuCollection = new List<Menu>();
                InitializeData(menuCollection);
                var roots = from menu in menuCollection
                            where menu.ParentId == null
                            select menu;
                Menu m = new Menu { Id = 0, Title = "Main" };
                MenuNode rootNode = new MenuNode(m);
                foreach (var r in roots)
                {
                    Console.WriteLine();
                    MenuNode node = rootNode.AddNode(r);
                    node.MenuItem = r;
                    PopulateTree(node);
                }
                Console.WriteLine("---------------------------------------------------------------------");
                PrintTree(rootNode, 0);
                Console.ReadKey();
            }
            catch(System.Exception ex)
            {
                _exLogger.addErrorLog(ex);
            }
        }

        private static void PrintTree(MenuNode m,int level)
        {
            try
            {
                for (int i = 0; i < level; i++)
                {
                    Console.Write("  ");
                }
                level++;
                Console.WriteLine(m.MenuItem.Title);
                if (m.ChildNodes.Count == 0)
                {
                    level--;
                    return;
                }
                else
                {
                    foreach (var n in m.ChildNodes)
                    {

                        PrintTree(n, level);

                    }
                    //level++;
                }
            }
            catch(System.Exception ex)
            {
                _exLogger.addErrorLog(ex);
            }
                            
        }
        static void PopulateTree(MenuNode menuNode)
        {
            try
            {
                var children = from menu in menuCollection
                               where menu.ParentId == menuNode.MenuItem.Id
                               select menu;
                if (children.Count() == 0)
                {
                    return;
                }
                else
                {
                    foreach (var c in children)
                    {
                        MenuNode newNode = menuNode.AddNode(c);
                        PopulateTree(newNode);
                    }
                }
            }
            catch(System.Exception ex)
            {
                _exLogger.addErrorLog(ex);
            }
        }
        static void InitializeData(List<Menu> menuCollection)
        {
            try
            {
                menuCollection.Add(new Menu { Id = 101, Title = "File", Href = "a.html" });
                menuCollection.Add(new Menu { Id = 1011, Title = "New", Href = "project.html", ParentId = 101 });
                menuCollection.Add(new Menu { Id = 10111, Title = "Project", Href = "project.html", ParentId = 1011 });
                menuCollection.Add(new Menu { Id = 10112, Title = "WebSite", Href = "website.html", ParentId = 1011 });
                menuCollection.Add(new Menu { Id = 1012, Title = "Open", Href = "a.html", ParentId = 101 });
                menuCollection.Add(new Menu { Id = 10121, Title = "File", Href = "file.html", ParentId = 1012 });
                menuCollection.Add(new Menu { Id = 10122, Title = "Design", Href = "design.html", ParentId = 1012 });
                menuCollection.Add(new Menu { Id = 101211, Title = "FlowChart", Href = "flowchart.html", ParentId = 10121 });
                menuCollection.Add(new Menu { Id = 101212, Title = "DFD", Href = "dfd.html", ParentId = 10121 });

                menuCollection.Add(new Menu { Id = 102, Title = "Edit" });
                menuCollection.Add(new Menu { Id = 1021, Title = "Copy", Href = "copy.html", ParentId = 102 });
                menuCollection.Add(new Menu { Id = 1022, Title = "Cut", Href = "cut.html", ParentId = 102 });
                menuCollection.Add(new Menu { Id = 1023, Title = "Paste", Href = "paste.html", ParentId = 102 });
                menuCollection.Add(new Menu { Id = 1024, Title = "Paste Special", ParentId = 102 });
                menuCollection.Add(new Menu { Id = 10241, Title = "JSON as Classes", Href = "json.html", ParentId = 1024 });
                menuCollection.Add(new Menu { Id = 10242, Title = "XML as Classes", Href = "xml.html", ParentId = 1024 });
            }
            catch(System.Exception ex)
            {
                _exLogger.addErrorLog(ex);
            }
        }
    }
}