﻿using ClassLibrary.Structures;
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
        //private RBTree Tree { get; set; }
        public Set<int> Tree { get; set; }
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
                Tree.Remove(DeleteValue);
                UpdateItems();
                RaisePropertyChanged("Items");
            });
            Find = new DelegateCommand(() =>
            {
                SetNode<int> sni = Tree.Search(FindValue);
                string message = "Color of " + FindValue + " is " + sni.Color.ToString();
                string title = "Information";
                MessageBox.Show(message, title);
            });
            Min = new DelegateCommand(() =>
            {
                int min = int.MaxValue;
                SetNode<int> sni = Tree.Root;
                while (sni != null)
                {
                    min = sni.Data;
                    sni = (SetNode<int>)sni.Left;
                }
                string message = "Min value in tree is " + min;
                string title = "Information";
                MessageBox.Show(message, title);
            });
            Max = new DelegateCommand(() =>
            {
                int max = int.MinValue;
                SetNode<int> sni = Tree.Root;
                while (sni != null)
                {
                    max = sni.Data;
                    sni = (SetNode<int>)sni.Right;
                }
                string message = "Max value in tree is " + max;
                string title = "Information";
                MessageBox.Show(message, title);
            });
            Tree = new Set<int>();
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

        public ObservableCollection<ObservableCollection<SetNode<int>>> GetTree()
        {
            bool levelIsNotNull = true;
            var lists = new ObservableCollection<ObservableCollection<SetNode<int>>>();
            if (Tree.Root == null)
            {
                return new ObservableCollection<ObservableCollection<SetNode<int>>>();
            }
            var level = new ObservableCollection<SetNode<int>> { Tree.Root };
            while (levelIsNotNull)
            {
                var nextLevel = new ObservableCollection<SetNode<int>>();
                levelIsNotNull = false;
                foreach (var node in level)
                {
                    if (node != null)
                    {
                        if (node.Left != null || node.Right != null)
                            levelIsNotNull = true;
                        nextLevel.Add((SetNode<int>)node.Left);
                        nextLevel.Add((SetNode<int>)node.Right);
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
        public TreeLevel(ObservableCollection<SetNode<int>> e)
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
        public TreeLevelItem(SetNode<int> n)
        {
            if (n != null)
            {
                Value = n.Data.ToString();
                if (n.Color == TriState.Black || n.Color == TriState.Header)
                {
                    Colour = new SolidColorBrush(Colors.Black);
                }
                else if (n.Color == TriState.Red)
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
