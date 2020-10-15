using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Structures
{
    public class StackRealization<T> : IStackRealization<T>
    {
        public StackItem<T> Head;

        public StackRealization()
        {
            Head = null;
        }

        public void Push(T el)
        {
            if (Head == null)
            {
                Head = new StackItem<T>(el, null);
            }
            else
            {
                StackItem<T> newElem = new StackItem<T>(el, Head);
                Head = newElem;
            }
        }

        public T Pop()
        {
            if (Head == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                StackItem<T> ejectedElem = Head;
                Head = Head.Tail;
                return ejectedElem.Value;
            }
        }

        public T Top()
        {
            if (Head == null)
            {
                throw new NullReferenceException();
            }
            return Head.Value;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public T[] Print()
        {
            if (Head == null)
            {
                return new T[0];
            }

            List<T> elems = new List<T>();
            StackItem<T> elem = Head;
            while(true)
            {
                if (elem == null)
                {
                    break;
                }
                elems.Add(elem.Value);
                elem = elem.Tail;
            }
            return elems.ToArray();
        }
    }

    public class StackItem<T>
    {
        public T Value { get; set; }
        public StackItem<T> Tail { get; set; }

        public StackItem(T value, StackItem<T> tail)
        {
            Value = value;
            Tail = tail;
        }
    }

    public interface IStackRealization<T>
    {
        void Push(T el);
        T Pop();
        T Top();
        bool IsEmpty();
        T[] Print();
    }
}
