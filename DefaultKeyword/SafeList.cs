namespace Assignment01.DefaultKeyword
{
    // Q14: Write a SafeList<T> that returns default when the index is invalid.
    public class SafeList<T>
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);

        public T? GetAt(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                return _items[index];
            }
            return default(T);
        }

        public T? this[int index] => GetAt(index);

        public int Count => _items.Count;
    }
}
