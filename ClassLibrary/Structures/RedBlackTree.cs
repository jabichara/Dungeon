using System;
using System.Collections.Generic;

public enum Direction 
{ 
    Left, 
    Right 
};
public enum Color
{
    Header,
    Red,
    Black
}
public class Node
{
    public Node Left;
    public Node Right;
    public Node Parent;
    public Color Color;

    public bool IsHeader
    {
        get
        {
            return Color == Color.Header;
        }
    }
}
public class Node<T> : Node
{
    public T Data;

    public Node()
    {
        Left = this;
        Right = this;
        Parent = null;
        Color = Color.Header;
    }

    public Node(T t)
    {
        Left = null;
        Right = null;
        Color = Color.Black;
        Data = t;
    }
}
public class Tools
{
    public static ulong Depth(Node Root)
    {
        if (Root != null)
        {
            ulong Left = Root.Left != null ? Depth(Root.Left) : 0;
            ulong Right = Root.Right != null ? Depth(Root.Right) : 0;
            return Left < Right ? Right + 1 : Left + 1;
        }
        else
            return 0;
    }
    public static ulong Paths(Node Root, ulong weight)
    {
        if (Root != null)
        {
            ulong Left = Root.Left != null ? Paths(Root.Left, weight + 1) : 0;
            ulong Right = Root.Right != null ? Paths(Root.Right, weight + 1) : 0;
            return Left + Right + weight;
        }
        else
            return 0;
    }
    public static Node PreviousItem(Node Node)
    {
        if (Node.IsHeader) { return Node.Right; }

        if (Node.Left != null)
        {
            Node = Node.Left;
            while (Node.Right != null) Node = Node.Right;
        }
        else
        {
            Node y = Node.Parent;
            if (y.IsHeader) return y;
            while (Node == y.Left) { Node = y; y = y.Parent; }
            Node = y;
        }
        return Node;
    }
    public static Node NextItem(Node Node)
    {
        if (Node.IsHeader) return Node.Left;

        if (Node.Right != null)
        {
            Node = Node.Right;
            while (Node.Left != null) Node = Node.Left;
        }
        else
        {
            Node y = Node.Parent;
            if (y.IsHeader) return y;
            while (Node == y.Right) { Node = y; y = y.Parent; }
            Node = y;
        }
        return Node;
    }
    static Node Minimum(Node x)
    {
        while (x.Left != null) x = x.Left;
        return x;
    }
    static Node Maximum(Node x)
    {
        while (x.Right != null) x = x.Right;
        return x;
    }
    static void RotateLeft(Node x, ref Node Root)
    {
        Node y = x.Right;

        x.Right = y.Left;
        if (y.Left != null)
            y.Left.Parent = x;
        y.Parent = x.Parent;

        if (x == Root)
            Root = y;
        else if (x == x.Parent.Left)
            x.Parent.Left = y;
        else
            x.Parent.Right = y;
        y.Left = x;
        x.Parent = y;
    }
    static void RotateRight(Node x, ref Node Root)
    {
        Node y = x.Left;

        x.Left = y.Right;
        if (y.Right != null)
            y.Right.Parent = x;
        y.Parent = x.Parent;

        if (x == Root)
            Root = y;
        else if (x == x.Parent.Right)
            x.Parent.Right = y;
        else
            x.Parent.Left = y;
        y.Right = x;
        x.Parent = y;
    }
    public static void Rebalance(Node x, ref Node Root)
    {
        x.Color = Color.Red;
        while (x != Root && x.Parent.Color == Color.Red)
        {
            if (x.Parent == x.Parent.Parent.Left)
            {
                Node y = x.Parent.Parent.Right;
                if (y != null && y.Color == Color.Red)
                {
                    x.Parent.Color = Color.Black;
                    y.Color = Color.Black;
                    x.Parent.Parent.Color = Color.Red;
                    x = x.Parent.Parent;
                }
                else
                {
                    if (x == x.Parent.Right)
                    {
                        x = x.Parent;
                        RotateLeft(x, ref Root);
                    }
                    x.Parent.Color = Color.Black;
                    x.Parent.Parent.Color = Color.Red;
                    RotateRight(x.Parent.Parent, ref Root);
                }
            }
            else
            {
                Node y = x.Parent.Parent.Left;
                if (y != null && y.Color == Color.Red)
                {
                    x.Parent.Color = Color.Black;
                    y.Color = Color.Black;
                    x.Parent.Parent.Color = Color.Red;
                    x = x.Parent.Parent;
                }
                else
                {
                    if (x == x.Parent.Left)
                    {
                        x = x.Parent;
                        RotateRight(x, ref Root);
                    }
                    x.Parent.Color = Color.Black;
                    x.Parent.Parent.Color = Color.Red;
                    RotateLeft(x.Parent.Parent, ref Root);
                }
            }
        }
        Root.Color = Color.Black;
    }
    static void TSwap<X>(ref X u, ref X v)
    { 
        X t = u; 
        u = v; 
        v = t; 
    }
    public static Node RebalanceForRemove(Node z, ref Node Root, ref Node Leftmost, ref Node Rightmost)
    {
        Node y = z;
        Node x;
        if (y.Left == null)
            x = y.Right;
        else
            if (y.Right == null)
            x = y.Left;
        else
        {
            y = y.Right;
            while (y.Left != null) y = y.Left;
            x = y.Right;
        }

        Node x_Parent;
        if (y != z)
        {
            z.Left.Parent = y;
            y.Left = z.Left;
            if (y != z.Right)
            {
                x_Parent = y.Parent;
                if (x != null) x.Parent = y.Parent;
                y.Parent.Left = x;
                y.Right = z.Right;
                z.Right.Parent = y;
            }
            else
                x_Parent = y;

            if (Root == z)
                Root = y;
            else if (z.Parent.Left == z)
                z.Parent.Left = y;
            else
                z.Parent.Right = y;
            y.Parent = z.Parent;
            TSwap(ref y.Color, ref z.Color);
            y = z;
        }
        else  // y == z
        {
            x_Parent = y.Parent;
            if (x != null) x.Parent = y.Parent;
            if (Root == z)
                Root = x;
            else
                if (z.Parent.Left == z)
                z.Parent.Left = x;
            else
                z.Parent.Right = x;
            if (Leftmost == z)
                if (z.Right == null)
                    Leftmost = z.Parent;
                else
                    Leftmost = Minimum(x);
            if (Rightmost == z)
                if (z.Left == null)
                    Rightmost = z.Parent;
                else
                    Rightmost = Maximum(x);
        }
        if (y.Color != Color.Red)
        {
            while (x != Root && (x == null || x.Color == Color.Black))
                if (x == x_Parent.Left)
                {
                    Node w = x_Parent.Right;
                    if (w.Color == Color.Red)
                    {
                        w.Color = Color.Black;
                        x_Parent.Color = Color.Red;
                        RotateLeft(x_Parent, ref Root);
                        w = x_Parent.Right;
                    }
                    if ((w.Left == null || w.Left.Color == Color.Black) &&
                        (w.Right == null || w.Right.Color == Color.Black))
                    {
                        w.Color = Color.Red;
                        x = x_Parent;
                        x_Parent = x_Parent.Parent;
                    }
                    else
                    {
                        if (w.Right == null || w.Right.Color == Color.Black)
                        {
                            if (w.Left != null) w.Left.Color = Color.Black;
                            w.Color = Color.Red;
                            RotateRight(w, ref Root);
                            w = x_Parent.Right;
                        }
                        w.Color = x_Parent.Color;
                        x_Parent.Color = Color.Black;
                        if (w.Right != null) w.Right.Color = Color.Black;
                        RotateLeft(x_Parent, ref Root);
                        break;
                    }
                }
                else
                {
                    Node w = x_Parent.Left;
                    if (w.Color == Color.Red)
                    {
                        w.Color = Color.Black;
                        x_Parent.Color = Color.Red;
                        RotateRight(x_Parent, ref Root);
                        w = x_Parent.Left;
                    }
                    if ((w.Right == null || w.Right.Color == Color.Black) &&
                        (w.Left == null || w.Left.Color == Color.Black))
                    {
                        w.Color = Color.Red;
                        x = x_Parent;
                        x_Parent = x_Parent.Parent;
                    }
                    else
                    {
                        if (w.Left == null || w.Left.Color == Color.Black)
                        {
                            if (w.Right != null) w.Right.Color = Color.Black;
                            w.Color = Color.Red;
                            RotateLeft(w, ref Root);
                            w = x_Parent.Left;
                        }
                        w.Color = x_Parent.Color;
                        x_Parent.Color = Color.Black;
                        if (w.Left != null) w.Left.Color = Color.Black;
                        RotateRight(x_Parent, ref Root);
                        break;
                    }
                }
            if (x != null) x.Color = Color.Black;
        }
        return y;
    }
    public static int BlackCount(Node Node, Node Root)
    {
        if (Node == null)
            return 0;
        else
        {
            int count = Node.Color == Color.Black ? 1 : 0;

            if (Node == Root)
                return count;
            else
                return count + BlackCount(Node.Parent, Root);
        }
    }
}
public struct SetEntry<T> : IEnumerator<T>
{
    public SetEntry(Node<T> n)
    {
        Node = n;
    }
    public T Value
    {
        get
        {
            return Node.Data;
        }
    }
    public bool IsEnd
    {
        get
        {
            return Node.IsHeader;
        }
    }
    public bool MoveNext()
    {
        Node = (Node<T>)Tools.NextItem(Node);
        return !Node.IsHeader;
    }
    public bool MovePrevious()
    {
        Node = (Node<T>)Tools.PreviousItem(Node);
        return !Node.IsHeader;
    }
    public void Reset()
    {
        while (!MoveNext()) ;
    }
    object System.Collections.IEnumerator.Current
    {
        get
        {
            return Node.Data;
        }
    }
    T IEnumerator<T>.Current
    {
        get
        {
            return Node.Data;
        }
    }
    public static bool operator ==(SetEntry<T> x, SetEntry<T> y)
    {
        return x.Node == y.Node;
    }
    public static bool operator !=(SetEntry<T> x, SetEntry<T> y)
    {
        return x.Node != y.Node;
    }
    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public override string ToString()
    {
        return Value.ToString();
    }
    public void Dispose()
    {

    }
    public Node<T> Node;
}
public class RedBlackTree<T>
{
    readonly IComparer<T> Comparer;
    readonly Node<T> Header;
    public ulong Length { get; private set; }
    public ulong Depth
    {
        get
        {
            return Tools.Depth(Root);
        }
    }
    public RedBlackTree()
    {
        Comparer = Comparer<T>.Default;
        Header = new Node<T>();
        Length = 0;
    }
    public Node<T> Root
    {
        get
        {
            return (Node<T>)Header.Parent;
        }
        set
        {
            Header.Parent = value;
        }
    }
    Node<T> LeftMost
    {
        get
        {
            return (Node<T>)Header.Left;
        }
        set
        {
            Header.Left = value;
        }
    }
    Node<T> RightMost
    {
        get
        {
            return (Node<T>)Header.Right;
        }
        set
        {
            Header.Right = value;
        }
    }
    public SetEntry<T> Begin
    {
        get
        {
            return new SetEntry<T>((Node<T>)Header.Left);
        }
    }
    public SetEntry<T> End
    {
        get
        {
            return new SetEntry<T>(Header);
        }
    }
    public bool this[T Key]
    {
        get
        {
            Node<T> Node = Search(Key);
            if (Node == null) return false; else return true;
        }
    }
    Node<T> Add(T Key, Node<T> y, Direction From)
    {
        Node<T> z = new Node<T>(Key);
        Length++;

        if (y == Header)
        {
            Root = z;
            RightMost = z;
            LeftMost = z;
        }
        else if (From == Direction.Left)
        {
            y.Left = z;
            if (y == LeftMost) LeftMost = z;
        }
        else
        {
            y.Right = z;
            if (y == RightMost) RightMost = z;
        }

        z.Parent = y;
        Tools.Rebalance(z, ref Header.Parent);
        return z;
    }
    public Node<T> Add(T Key)
    {
        Node<T> y = Header;
        Node<T> x = Root;

        int c = -1;
        while (x != null)
        {
            y = x;
            c = Comparer.Compare(Key, x.Data);
            if (c < 0)
                x = (Node<T>)x.Left;
            else if (c > 0)
                x = (Node<T>)x.Right;
            else
                throw new Exception("Entry already exists!");
        }

        Direction From = c < 0 ? Direction.Left : Direction.Right;
        return Add(Key, y, From);
    }
    public void Remove(T Key)
    {
        Node<T> root = Root;

        for (; ; )
        {
            if (root == null)
                throw new Exception("Entry not found!");

            int Compare = Comparer.Compare(Key, root.Data);

            if (Compare < 0)
                root = (Node<T>)root.Left;

            else if (Compare > 0)
                root = (Node<T>)root.Right;

            else // Item is found
            {
                Tools.RebalanceForRemove(root, ref Header.Parent, ref Header.Left, ref Header.Right);
                Length--;
                break;
            }
        }
    }
    public Node<T> Search(T Key)
    {
        if (Root == null)
            return null;
        else
        {
            Node<T> search = Root;

            do
            {
                long result = Comparer.Compare(Key, search.Data);

                if (result < 0) search = (Node<T>)search.Left;

                else if (result > 0) search = (Node<T>)search.Right;

                else break;

            } while (search != null);

            return search;
        }
    }
    public override string ToString()
    {
        string StringOut = "{";

        SetEntry<T> start = Begin;
        SetEntry<T> end = End;
        SetEntry<T> last = End; last.MovePrevious();

        while (start != end)
        {
            string NewStringOut = start.Value.ToString();
            if (start != last) NewStringOut += ",";
            StringOut += NewStringOut;
            start.MoveNext();
        }

        StringOut += "}";
        return StringOut;
    }
}