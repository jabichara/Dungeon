using System;
using System.Collections.Generic;

namespace ClassLibrary.Structures
{
    public class RBTree
    {
        
        public Node Root;
        
        public RBTree() { }
        
        public void LeftRotate(Node X)
        {
            Node Y = X.Right; // set Y
            X.Right = Y.Left; //turn Y's left subtree into X's right subtree
            if (Y.Left != null)
            {
                Y.Left.Parent = X;
            }
            if (Y != null)
            {
                Y.Parent = X.Parent;//link X's parent to Y
            }
            if (X.Parent == null)
            {
                Root = Y;
            }
            if (X == X.Parent.Left)
            {
                X.Parent.Left = Y;
            }
            else
            {
                X.Parent.Right = Y;
            }
            Y.Left = X; //put X on Y's left
            if (X != null)
            {
                X.Parent = Y;
            }

        }
        
        public void RightRotate(Node Y)
        {
            // right rotate is simply mirror code from left rotate
            Node X = Y.Left;
            Y.Left = X.Right;
            if (X.Right != null)
            {
                X.Right.Parent = Y;
            }
            if (X != null)
            {
                X.Parent = Y.Parent;
            }
            if (Y.Parent == null)
            {
                Root = X;
            }
            if (Y == Y.Parent.Right)
            {
                Y.Parent.Right = X;
            }
            if (Y == Y.Parent.Left)
            {
                Y.Parent.Left = X;
            }

            X.Right = Y;//put Y on X's right
            if (Y != null)
            {
                Y.Parent = X;
            }
        }
        
        public List<List<Node>> DisplayTree()
        {
            bool levelIsNotNull = true;
            var lists = new List<List<Node>>();
            if (Root == null)
            {
                Console.WriteLine("XUITA");
            }
            var level = new List<Node> { Root };
            while (levelIsNotNull)
            {
                var nextLevel = new List<Node>();
                levelIsNotNull = false;
                foreach (var node in level)
                {
                    if (node != null)
                    {
                        if (node.Left != null || node.Right != null)
                            levelIsNotNull = true;
                        nextLevel.Add(node.Left);
                        nextLevel.Add(node.Right);
                    }
                }
                lists.Add(level);
                level = nextLevel;
            }
            
            return lists;
        }
     
        public Node Find(int key)
        {
            bool isFound = false;
            Node temp = Root;
            Node item = null;
            while (!isFound)
            {
                if (temp == null)
                {
                    break;
                }
                if (key < temp.Value)
                {
                    temp = temp.Left;
                }
                if (key > temp.Value)
                {
                    temp = temp.Right;
                }
                if (key == temp.Value)
                {
                    isFound = true;
                    item = temp;
                }
            }
            if (isFound)
            {
                Console.WriteLine("{0} was found", key);
                return temp;
            }
            else
            {
                Console.WriteLine("{0} not found", key);
                return null;
            }
        }

        public void Add(int item)
        {
            Node newItem = new Node(item);
            if (Root == null)
            {
                Root = newItem;
                Root.Colour = RBTreeColour.Black;
                return;
            }
            Node Y = null;
            Node X = Root;
            while (X != null)
            {
                Y = X;
                if (newItem.Value < X.Value)
                {
                    X = X.Left;
                }
                else
                {
                    X = X.Right;
                }
            }
            newItem.Parent = Y;
            if (Y == null)
            {
                Root = newItem;
            }
            else if (newItem.Value < Y.Value)
            {
                Y.Left = newItem;
            }
            else
            {
                Y.Right = newItem;
            }
            newItem.Left = null;
            newItem.Right = null;
            newItem.Colour = RBTreeColour.Red;
        }
            //InsertFixUp(newItem);
        //}
        //public void InOrderDisplay(Node current)
        //{
        //    if (current != null)
        //    {
        //        InOrderDisplay(current.Left);
        //        Console.Write("({0}) ", current.Value);
        //        InOrderDisplay(current.Right);
        //    }
        //}
        public void InsertFixUp(Node item)
        {
            while (item != Root && item.Parent.Colour == RBTreeColour.Red)
            {
                if (item.Parent == item.Parent.Parent.Left)
                {
                    Node Y = item.Parent.Parent.Right;
                    if (Y != null && Y.Colour == RBTreeColour.Red)
                    {
                        item.Parent.Colour = RBTreeColour.Black;
                        Y.Colour = RBTreeColour.Black;
                        item.Parent.Parent.Colour = RBTreeColour.Red;
                        item = item.Parent.Parent;
                    }
                    else 
                    {
                        if (item == item.Parent.Right)
                        {
                            item = item.Parent;
                            LeftRotate(item);
                        }
                        item.Parent.Colour = RBTreeColour.Black;
                        item.Parent.Parent.Colour = RBTreeColour.Red;
                        RightRotate(item.Parent.Parent);
                    }

                }
                else
                {
                    Node X = null;

                    X = item.Parent.Parent.Left;
                    if (X != null && X.Colour == RBTreeColour.Black)
                    {
                        item.Parent.Colour = RBTreeColour.Red;
                        X.Colour = RBTreeColour.Red;
                        item.Parent.Parent.Colour = RBTreeColour.Black;
                        item = item.Parent.Parent;
                    }
                    else 
                    {
                        if (item == item.Parent.Left)
                        {
                            item = item.Parent;
                            RightRotate(item);
                        }
                        item.Parent.Colour = RBTreeColour.Black;
                        item.Parent.Parent.Colour = RBTreeColour.Red;
                        LeftRotate(item.Parent.Parent);

                    }

                }
                Root.Colour = RBTreeColour.Black;
            }
        }
        
        public void Delete(int key)
        {
            Node item = Find(key);
            Node X = null;
            Node Y = null;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.Left == null || item.Right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item);
            }
            if (Y.Left != null)
            {
                X = Y.Left;
            }
            else
            {
                X = Y.Right;
            }
            if (X != null)
            {
                X.Parent = Y;
            }
            if (Y.Parent == null)
            {
                Root = X;
            }
            else if (Y == Y.Parent.Left)
            {
                Y.Parent.Left = X;
            }
            else
            {
                Y.Parent.Left = X;
            }
            if (Y != item)
            {
                item.Value = Y.Value;
            }
            if (Y.Colour == RBTreeColour.Black)
            {
                DeleteFixUp(X);
            }

        }        
        public void DeleteFixUp(Node X)
        {

            while (X != null && X != Root && X.Colour == RBTreeColour.Black)
            {
                if (X == X.Parent.Left)
                {
                    Node W = X.Parent.Right;
                    if (W.Colour == RBTreeColour.Red)
                    {
                        W.Colour = RBTreeColour.Black; //case 1
                        X.Parent.Colour = RBTreeColour.Red; //case 1
                        LeftRotate(X.Parent); //case 1
                        W = X.Parent.Right; //case 1
                    }
                    if (W.Left.Colour == RBTreeColour.Black && W.Right.Colour == RBTreeColour.Black)
                    {
                        W.Colour = RBTreeColour.Red; //case 2
                        X = X.Parent; //case 2
                    }
                    else if (W.Right.Colour == RBTreeColour.Black)
                    {
                        W.Left.Colour = RBTreeColour.Black; //case 3
                        W.Colour = RBTreeColour.Red; //case 3
                        RightRotate(W); //case 3
                        W = X.Parent.Right; //case 3
                    }
                    W.Colour = X.Parent.Colour; //case 4
                    X.Parent.Colour = RBTreeColour.Black; //case 4
                    W.Right.Colour = RBTreeColour.Black; //case 4
                    LeftRotate(X.Parent); //case 4
                    X = Root; //case 4
                }
                else //mirror code from above with "right" & "left" exchanged
                {
                    Node W = X.Parent.Left;
                    if (W.Colour == RBTreeColour.Red)
                    {
                        W.Colour = RBTreeColour.Black;
                        X.Parent.Colour = RBTreeColour.Red;
                        RightRotate(X.Parent);
                        W = X.Parent.Left;
                    }
                    if (W.Right.Colour == RBTreeColour.Black && W.Left.Colour == RBTreeColour.Black)
                    {
                        W.Colour = RBTreeColour.Black;
                        X = X.Parent;
                    }
                    else if (W.Left.Colour == RBTreeColour.Black)
                    {
                        W.Right.Colour = RBTreeColour.Black;
                        W.Colour = RBTreeColour.Red;
                        LeftRotate(W);
                        W = X.Parent.Left;
                    }
                    W.Colour = X.Parent.Colour;
                    X.Parent.Colour = RBTreeColour.Black;
                    W.Left.Colour = RBTreeColour.Black;
                    RightRotate(X.Parent);
                    X = Root;
                }
            }
            if (X != null)
                X.Colour = RBTreeColour.Black;
        }
        public Node Minimum(Node X)
        {
            while (X.Left.Left != null)
            {
                X = X.Left;
            }
            if (X.Left.Right != null)
            {
                X = X.Left.Right;
            }
            return X;
        }
        public Node TreeSuccessor(Node X)
        {
            if (X.Left != null)
            {
                return Minimum(X);
            }
            else
            {
                Node Y = X.Parent;
                while (Y != null && X == Y.Right)
                {
                    X = Y;
                    Y = Y.Parent;
                }
                return Y;
            }
        }
    }

    
    public class Node
    {
        public RBTreeColour Colour;
        public Node Left;
        public Node Right;
        public Node Parent;
        public int Value;

        public Node(int data) 
        { 
            Value = data; 
        }

        public Node(RBTreeColour colour) 
        { 
            Colour = colour; 
        }

        public Node(int data, RBTreeColour colour) 
        { 
            Value = data; 
            Colour = colour; 
        }
    }

    public enum RBTreeColour
    {
        Red,
        Black
    }
}