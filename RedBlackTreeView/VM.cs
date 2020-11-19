using ClassLibrary.Structures;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RedBlackTreeView
{
    public class VM : BindableBase
    {
        public RedBlackTree<int> Tree { get; set; }
        public ObservableCollection<TreeLevel> Items { get; set; }
        public DelegateCommand Add { get; set; }
        public int AddValue { get; set; }
        public DelegateCommand Delete { get; set; }
        public int DeleteValue { get; set; }
        public DelegateCommand Find { get; set; }
        public int FindValue { get; set; }
        public DelegateCommand Min { get; set; }
        public DelegateCommand Max { get; set; }
        public int FindNextValue { get; set; }
        public int FindPrevValue { get; set; }
        public DelegateCommand FindNext { get; set; }
        public DelegateCommand FindPrev { get; set; }
        public VM()
        {
            Add = new DelegateCommand(() =>
            {
                Node<int> sni = Tree.Search(AddValue);
                if (sni == null)
                {
                    Tree.Add(AddValue);
                    UpdateItems();
                    RaisePropertyChanged("Items");
                }
                else
                {
                    string title = "Information";
                    string message = AddValue + " already exists in tree";
                    MessageBox.Show(message, title);
                }
            });
            Delete = new DelegateCommand(() =>
            {
                Node<int> sni = Tree.Search(DeleteValue);
                if (sni != null)
                {
                    Tree.Remove(DeleteValue);
                    UpdateItems();
                    RaisePropertyChanged("Items");
                }
            });
            Find = new DelegateCommand(() =>
            {
                Node<int> sni = Tree.Search(FindValue);
                string title = "Information";
                string message = null;
                if (sni != null)
                {
                    message = "Color of " + FindValue + " is " + sni.Color.ToString();
                }
                else
                {
                    message = FindValue + " not exists in tree";
                }
                MessageBox.Show(message, title);
            });
            Min = new DelegateCommand(() =>
            {
                int min = int.MaxValue;
                Node<int> sni = Tree.Root;
                while (sni != null)
                {
                    min = sni.Data;
                    sni = (Node<int>)sni.Left;
                }
                string message = "Min value in tree is " + min;
                string title = "Information";
                MessageBox.Show(message, title);
            });
            Max = new DelegateCommand(() =>
            {
                int max = int.MinValue;
                Node<int> sni = Tree.Root;
                while (sni != null)
                {
                    max = sni.Data;
                    sni = (Node<int>)sni.Right;
                }
                string message = "Max value in tree is " + max;
                string title = "Information";
                MessageBox.Show(message, title);
            });
            FindNext = new DelegateCommand(() =>
            {
                Node<int> sni = Tree.Search(FindNextValue);
                string message = null;
                string title = "Information";
                if (sni != null)
                {
                    Node<int> next = (Node<int>)Tools.NextItem(sni);
                    if (next != null && next.Data != 0 && next.Color != Color.Header)
                    {
                        message = "Next after " + FindNextValue + " - " + next.Data + ", color - " + next.Color;
                    }
                    else
                    {
                        message = "Nothing after " + FindNextValue;
                    }
                }
                else
                {
                    message = FindNextValue + " not exist in tree";
                }
                MessageBox.Show(message, title);
            });
            FindPrev = new DelegateCommand(() =>
            {
                Node<int> sni = Tree.Search(FindPrevValue);
                string message = null;
                string title = "Information";
                if (sni != null)
                {
                    Node<int> prev = (Node<int>)Tools.PreviousItem(sni);
                    if (prev != null && prev.Data != 0 && prev.Color != Color.Header)
                    {
                        message = "Prev before " + FindPrevValue + " - " + prev.Data + ", color - " + prev.Color;
                    }
                    else
                    {
                        message = "Nothing prev " + FindPrevValue;
                    }
                }
                else
                {
                    message = FindPrevValue + " not exist in tree";
                }
                MessageBox.Show(message, title);
            });
            Tree = new RedBlackTree<int>();

            List<int> list = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 25; i++)
            {
                int a = rnd.Next(1, 100);
                if (!list.Contains(a))
                {
                    list.Add(a);
                    Tree.Add(a);
                }
            }
            UpdateItems();
        }
        public void UpdateItems()
        {
            var e = GetTree();
            Items = new ObservableCollection<TreeLevel>();
            foreach (var ei in e)
            {
                Items.Add(new TreeLevel(ei));
            }
        }
        public ObservableCollection<ObservableCollection<Node<int>>> GetTree()
        {
            bool levelIsNotNull = true;
            var lists = new ObservableCollection<ObservableCollection<Node<int>>>();
            if (Tree.Root == null)
            {
                return new ObservableCollection<ObservableCollection<Node<int>>>();
            }
            var level = new ObservableCollection<Node<int>> { Tree.Root };
            while (levelIsNotNull)
            {
                var nextLevel = new ObservableCollection<Node<int>>();
                levelIsNotNull = false;
                foreach (var node in level)
                {
                    if (node != null)
                    {
                        if (node.Left != null || node.Right != null)
                            levelIsNotNull = true;
                        nextLevel.Add((Node<int>)node.Left);
                        nextLevel.Add((Node<int>)node.Right);
                    }
                    else
                    {
                        nextLevel.Add(null);
                        nextLevel.Add(null);
                    }
                }
                lists.Add(level);
                level = nextLevel;
            }
            return lists;
        }
    }
    public class TreeLevel
    {
        public int Level { get; set; }
        public ObservableCollection<TreeLevelItem> Items { get; set; }
        public TreeLevel(ObservableCollection<Node<int>> e)
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
        public bool Visibility { get; set; }
        public TreeLevelItem(Node<int> n)
        {
            if (n != null)
            {
                Value = n.Data.ToString();
                if (n.Color == Color.Black || n.Color == Color.Header)
                {
                    Colour = new SolidColorBrush(Colors.Black);
                }
                else if (n.Color == Color.Red)
                {
                    Colour = new SolidColorBrush(Colors.OrangeRed);
                }
                Visibility = true;
            }
            else
            {
                Value = "-";
                Visibility = false;
                Colour = new SolidColorBrush(Colors.White);
            }
        }
    }
}
