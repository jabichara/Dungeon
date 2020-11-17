using ClassLibrary.Structures;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RedBlackTreeView
{
    public class VM : BindableBase
    {
        public ObservableCollection<TreeLevel> Items { get; set; }
        public VM()
        {
            var tree = new RBTree();
            tree.Add(5);
            tree.Add(3);
            tree.Add(6);
            tree.Add(7);
            tree.Add(2);
            tree.Add(4);
            tree.Add(5);
            tree.Add(9);
            tree.Add(10);
            tree.Add(11);
            var e = tree.GetTree();
            Items = new ObservableCollection<TreeLevel>();
            foreach (var ei in e)
            {
                Items.Add(new TreeLevel(ei));
            }
        }
    }
    public class TreeLevel
    {
        public int Level { get; set; }
        public ObservableCollection<TreeLevelItem> Items { get; set; }
        public TreeLevel(ObservableCollection<Node> e)
        {
            Items = new ObservableCollection<TreeLevelItem>();
            foreach (var node in e)
            {
                Items.Add(new TreeLevelItem(node));
            }
        }
    }
    public class TreeLevelItem
    {
        public string Value { get; set; }
        public SolidColorBrush Colour { get; set; }
        public TreeLevelItem(Node n)
        {
            if (n != null)
            {
                Value = n.Value.ToString();
                if (n.Colour == RBTreeColour.Black)
                {
                    Colour = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    Colour = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                Value = "-";
                Colour = new SolidColorBrush(Colors.AliceBlue);
            }
        }
    }
}
