using ClassLibrary.Structures;
using Prism.Commands;
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
        private RBTree Tree { get; set; }
        public ObservableCollection<TreeLevel> Items { get; set; }
        public DelegateCommand Add { get; set; }
        public int AddValue { get; set; }
        public DelegateCommand Delete { get; set; }
        public int DeleteValue { get; set; }
        public DelegateCommand Find { get; set; }
        public int FindValue { get; set; }
        public DelegateCommand Min { get; set; }
        public DelegateCommand Max { get; set; }
        public VM()
        {
            Add = new DelegateCommand(() =>
            {
                Tree.Add(AddValue);
                UpdateItems();
                RaisePropertyChanged("Items");
            });
            Delete = new DelegateCommand(() =>
            {
                Tree.Delete(DeleteValue);
                UpdateItems();
                RaisePropertyChanged("Items");
            });
            Find = new DelegateCommand(() =>
            {
                Tree.Find(FindValue);
            });
            Min = new DelegateCommand(() =>
            {

            });
            Max = new DelegateCommand(() =>
            {

            });
            Tree = new RBTree();
            Tree.Add(5);
            Tree.Add(3);
            Tree.Add(6);
            Tree.Add(7);
            Tree.Add(2);
            Tree.Add(4);
            Tree.Add(5);
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Tree.Add(rnd.Next(0, 10));
            }
            UpdateItems();
        }

        public void UpdateItems()
        {
            var e = Tree.GetTree();
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
                else if (n.Colour == RBTreeColour.Red)
                {
                    Colour = new SolidColorBrush(Colors.OrangeRed);
                }
            }
            else
            {
                Value = "-";
                Colour = new SolidColorBrush(Colors.White);
            }
        }
    }
}
