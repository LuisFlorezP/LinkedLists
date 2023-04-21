using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace LinkedLists.Logic
{
    public class DoubleList<T>
    {
        private DoubleNode<T>? _first;

        private DoubleNode<T>? _last;

        public DoubleList()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        public int Count { get; set; }

        public bool IsEmpty => Count == 0;

        public override string ToString()
        {
            var output = string.Empty;
            var pointer = _first;
            while (pointer != null)
            {
                output += $" - {pointer.Data}\n";
                pointer = pointer.Right;
            }
            return output;
        }

        public string ToInvertedList()
        {
            var output = string.Empty;
            var pointer = _last;
            while (pointer != null)
            {
                output += $"{pointer.Data}\n";
                pointer = pointer.Left;
            }
            return output;
        }

        public void Add(T item)
        {
            var node = new DoubleNode<T>(item);
            if (IsEmpty)
            {
                _first = node;
                _last = node;    
            }
            else
            {
                node.Left= _last;
                _last!.Right = node;
                _last = node;
            }
            Count++;
        }

        public Responce Delete(T item)
        {
            var pointer = _first;
            var delete = new Responce();
            if (IsEmpty) 
            {
                return delete;
            }
            else
            {
                if (pointer.Data.Equals(item) && Count == 1)
                {
                    _first = null;
                    pointer = null;
                    delete.IsSucced = true;
                    Count--;
                    return delete;
                }
                else if (pointer.Data.Equals(item))
                {
                    _first = pointer.Right;
                    pointer.Right.Left = null;
                    pointer = null;
                    delete.IsSucced = true;
                    Count--;
                    return delete;
                }
                else
                {
                    while (pointer.Right.Right != null)
                    {
                        pointer = pointer.Right;
                        if (pointer.Data.Equals(item))
                        {
                            pointer.Left.Right = pointer.Right;
                            pointer.Right.Left = pointer.Left;
                            pointer = null;
                            delete.IsSucced = true;
                            Count--;
                            return delete;
                        }
                    }
                    if (pointer.Right.Data.Equals(item))
                    {
                        pointer = pointer.Right;
                        pointer.Left.Right = null;
                        _last = pointer.Left;
                        pointer = null;
                        delete.IsSucced = true;
                        Count--;
                        return delete;
                    }
                    else
                    {
                        return delete;
                    }
                }
            }
        }

        public Responce Insert(T item, int position)
        {
            var insert = new Responce();
            if (IsEmpty && position != 0)
            {
                return insert;
            }
            else if (IsEmpty && position == 0)
            { 
                insert.IsSucced = true;
                Add(item);
                return insert;
            }
            else if (Count <= position)
            {
                return insert;
            }
            else 
            {
                var nodo = new DoubleNode<T>(item);
                var pointer = _first;
                if (position == 0)
                {
                    nodo.Right = pointer;
                    pointer.Left = nodo;
                    _first = nodo;
                    insert.IsSucced = true;
                    Count++;
                    return insert;
                }
                for (int i = 1; i < Count; i++)
                {
                    pointer = pointer.Right;
                    if (position == i)
                    {
                        nodo.Right = pointer;
                        nodo.Left = pointer.Left;
                        pointer.Left.Right = nodo;
                        pointer.Left = nodo;
                        insert.IsSucced = true;
                        Count++;
                        return insert;
                    }
                }
            }
            return insert;
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            int i = 0;
            var pointer = _first;
            while (pointer != null)
            {
                array[i] = pointer.Data!;
                i++;
                pointer = pointer.Right;
            }
            return array;
        }
    }
}
