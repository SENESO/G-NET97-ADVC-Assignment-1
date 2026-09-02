namespace Assignment01.GenericClass
{
    // Q2: Write a generic class Container<T> with Add and Get methods.
    public class Container<T>
    {
        private readonly List<T> _items = new();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new IndexOutOfRangeException($"Index {index} is out of range. Count is {_items.Count}.");

            return _items[index];
        }

        public int Count => _items.Count;

        public override string ToString() => $"Container<{typeof(T).Name}> [Count: {Count}]";
    }
}
