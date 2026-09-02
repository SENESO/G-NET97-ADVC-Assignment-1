namespace Assignment01.Constraints
{
    // Q7: 'struct' constraint (T must be a non-nullable value type)
    public class StructContainer<T> where T : struct
    {
        public T Value { get; set; }

        public StructContainer(T value)
        {
            Value = value;
        }

        public override string ToString() => $"StructContainer: {Value} ({typeof(T).Name})";
    }

    // Q8: 'class' constraint (T must be a reference type)
    public class ClassContainer<T> where T : class
    {
        public T? Value { get; set; }

        public ClassContainer(T? value)
        {
            Value = value;
        }

        public override string ToString() => $"ClassContainer: {Value?.ToString() ?? "null"} ({typeof(T).Name})";
    }

    // Q9: 'new()' constraint (T must have a public parameterless constructor)
    public class Factory<T> where T : new()
    {
        public T CreateInstance()
        {
            return new T();
        }
    }

    public class Person
    {
        public string Name { get; set; } = "Anonymous";
        public int Age { get; set; } = 0;

        public override string ToString() => $"Person [Name: {Name}, Age: {Age}]";
    }

    // Q10: Interface constraint (T must implement the specified interface)
    public class Sorter<T> where T : IComparable<T>
    {
        public static T GetLarger(T item1, T item2)
        {
            return item1.CompareTo(item2) >= 0 ? item1 : item2;
        }
    }

    // Q11: Base class constraint (T must be or derive from the base class)
    public abstract class Animal
    {
        public string Name { get; set; }

        protected Animal(string name)
        {
            Name = name;
        }

        public abstract string MakeSound();
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override string MakeSound() => "Woof!";
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override string MakeSound() => "Meow!";
    }

    public class AnimalShelter<T> where T : Animal
    {
        private readonly List<T> _residents = new();

        public void Add(T animal) => _residents.Add(animal);

        public void MakeAllSpeak()
        {
            foreach (var animal in _residents)
            {
                Console.WriteLine($"  {animal.Name} says: {animal.MakeSound()}");
            }
        }
    }

    // Q12: Multiple constraints (T must satisfy all specified constraints)
    // Rule: Base class / class / struct must come first, followed by interfaces, followed by new()
    public class EntityService<T> where T : class, IComparable<T>, new()
    {
        private readonly List<T> _items = new();

        public T CreateAndRegister()
        {
            T newItem = new T();
            _items.Add(newItem);
            return newItem;
        }

        public void Add(T item) => _items.Add(item);

        public T? GetMax()
        {
            if (_items.Count == 0) return null;
            T max = _items[0];
            foreach (var item in _items)
            {
                if (item.CompareTo(max) > 0)
                    max = item;
            }
            return max;
        }
    }
}
