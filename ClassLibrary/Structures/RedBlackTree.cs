using System;

namespace ClassLibrary.Structures
{
    public class RBTree
    {
        /// <summary>
        /// Root node of the tree (both reference & pointer)
        /// </summary>
        public Node Root;
        /// <summary>
        /// New instance of a Red-Black tree object
        /// </summary>
        public RBTree() { }
        /// <summary>
        /// Left Rotate
        /// </summary>
        /// <param name="X"></param>
        /// <returns>void</returns>
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
        /// <summary>
        /// Rotate Right
        /// </summary>
        /// <param name="Y"></param>
        /// <returns>void</returns>
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
        /// <summary>
        /// Display Tree
        /// </summary>
        public void DisplayTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }
            if (Root != null)
            {
                InOrderDisplay(Root);
            }
        }
        /// <summary>
        /// Find item in the tree
        /// </summary>
        /// <param name="key"></param>
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
        /// <summary>
        /// Insert a new object into the RB Tree
        /// </summary>
        /// <param name="item"></param>
        public void Insert(int item)
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
            newItem.Colour = RBTreeColour.Red;//colour the new node red
            InsertFixUp(newItem);//call method to check for violations and fix
        }
        public void InOrderDisplay(Node current)
        {
            if (current != null)
            {
                InOrderDisplay(current.Left);
                Console.Write("({0}) ", current.Value);
                InOrderDisplay(current.Right);
            }
        }
        public void InsertFixUp(Node item)
        {
            //Checks Red-Black Tree properties
            while (item != Root && item.Parent.Colour == RBTreeColour.Red)
            {
                /*We have a violation*/
                if (item.Parent == item.Parent.Parent.Left)
                {
                    Node Y = item.Parent.Parent.Right;
                    if (Y != null && Y.Colour == RBTreeColour.Red)//Case 1: uncle is red
                    {
                        item.Parent.Colour = RBTreeColour.Black;
                        Y.Colour = RBTreeColour.Black;
                        item.Parent.Parent.Colour = RBTreeColour.Red;
                        item = item.Parent.Parent;
                    }
                    else //Case 2: uncle is black
                    {
                        if (item == item.Parent.Right)
                        {
                            item = item.Parent;
                            LeftRotate(item);
                        }
                        //Case 3: recolour & rotate
                        item.Parent.Colour = RBTreeColour.Black;
                        item.Parent.Parent.Colour = RBTreeColour.Red;
                        RightRotate(item.Parent.Parent);
                    }

                }
                else
                {
                    //mirror image of code above
                    Node X = null;

                    X = item.Parent.Parent.Left;
                    if (X != null && X.Colour == RBTreeColour.Black)//Case 1
                    {
                        item.Parent.Colour = RBTreeColour.Red;
                        X.Colour = RBTreeColour.Red;
                        item.Parent.Parent.Colour = RBTreeColour.Black;
                        item = item.Parent.Parent;
                    }
                    else //Case 2
                    {
                        if (item == item.Parent.Left)
                        {
                            item = item.Parent;
                            RightRotate(item);
                        }
                        //Case 3: recolour & rotate
                        item.Parent.Colour = RBTreeColour.Black;
                        item.Parent.Parent.Colour = RBTreeColour.Red;
                        LeftRotate(item.Parent.Parent);

                    }

                }
                Root.Colour = RBTreeColour.Black;//re-colour the root black as necessary
            }
        }
        /// <summary>
        /// Deletes a specified value from the tree
        /// </summary>
        /// <param name="item"></param>
        public void Delete(int key)
        {
            //first find the node in the tree to delete and assign to item pointer/reference
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
        /// <summary>
        /// Checks the tree for any violations after deletion and performs a fix
        /// </summary>
        /// <param name="X"></param>
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

    /// <summary>
    /// Object of type Node contains 4 properties
    /// Colour
    /// Left
    /// Right
    /// Parent
    /// Data
    /// </summary>
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