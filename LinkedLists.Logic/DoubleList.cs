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
                node.Left = _last;
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

        public Response Delete(T item)
        {
            var pointer = _first;
            while (pointer != null)
            {
                if (item!.Equals(pointer.Data))
                {
                    if (pointer == _first)
                    {
                        pointer.Right!.Left = null;
                        _first = pointer.Right;
                    }
                    else if (pointer == _last)
                    {
                        pointer.Left!.Right = null;
                        _last = pointer.Left;
                    }
                    else
                    {
                        pointer.Left!.Right = pointer.Right;
                        pointer.Right!.Left = pointer.Left;
                    }
                    pointer = null;
                    Count--;
                    return new Response
                    {
                        IsScucced = true,
                        Message = $"The element: {item} was deleted."
                    };
                }
                pointer = pointer!.Right;
            }
            return new Response
            {
                IsScucced = false,
                Message = $"The element: {item} not found."
            };
        }

        public Response Insert(T item, int position)
        {
            if (position < 0 || position >= Count)
            {
                return new Response
                {
                    IsScucced = false,
                    Message = $"The position {position} is not valid."
                };
            }
            var node = new DoubleNode<T>(item);
            if (position == 0)
            {
                _first!.Left = node;
                node.Right = _first;
                _first = node;
            }
            else
            {
                int i = 1;
                var pointer = _first!.Right;
                while (i < position)
                {
                    pointer = pointer!.Right;
                    i++;
                }
                pointer!.Left!.Right = node;
                node.Left = pointer.Left;
                node.Right = pointer;
                pointer.Left = node;
            }

            Count++;
            return new Response
            {
                IsScucced = true,
                Message = $"The item {item} was inserted."
            };

        }

        /// <summary>
        /// Fill the linked list with the N first the fibonacci terms
        /// 0, 1, 1, 2, 3, 5, 8, 13, 21, ...
        /// </summary>
        /// <param name="n">Number of fibonacci terms</param>
        public void FillFibonacci(int n)
        {

        }
    }
}
