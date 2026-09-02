namespace Assignment01.GenericInheritance
{
    // Q19: Generic base class
    public class MyList<T>
    {
        protected readonly List<T> _items = new();

        public virtual void Add(T item) => _items.Add(item);

        public int Count => _items.Count;

        public T this[int index] => _items[index];

        public void PrintAll()
        {
            Console.WriteLine($"  [{string.Join(", ", _items)}]");
        }
    }

    // 1. Concrete (Closed) Inheritance: Inheriting by specifying the type argument
    public class IntList : MyList<int>
    {
        public int Sum()
        {
            int sum = 0;
            foreach (var item in _items)
                sum += item;
            return sum;
        }
    }

    // 2. Open Generic Inheritance: Derived class is also generic and passes type parameter to base
    public class ObservableList<T> : MyList<T>
    {
        public event Action<T>? ItemAdded;

        public override void Add(T item)
        {
            base.Add(item);
            ItemAdded?.Invoke(item);
        }
    }

    // 3. Adding More Type Parameters: Derived class adds another type parameter
    public class KeyedList<TKey, TValue> : MyList<TValue> where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _lookup = new();

        public void Add(TKey key, TValue value)
        {
            base.Add(value);
            _lookup[key] = value;
        }

        public TValue? FindByKey(TKey key) => _lookup.TryGetValue(key, out var val) ? val : default;
    }
}
