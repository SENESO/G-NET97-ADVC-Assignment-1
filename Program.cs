using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Assignment01.GenericClass;
using Assignment01.MultipleTypeParameters;
using Assignment01.GenericMethods;
using Assignment01.GenericInterface;
using Assignment01.Constraints;
using Assignment01.DefaultKeyword;
using Assignment01.CovarianceAndContravariance;
using Assignment01.StaticMembers;
using Assignment01.GenericInheritance;
using Assignment01.Cache;

namespace Assignment01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question 01: What is a generic class? Why use generics?
            /*
             * Question 01:
             * What is a generic class? Why use generics?
             * 
             * Answer:
             * A generic class is a class defined with type parameters (like T) instead of a specific data type.
             * The actual type is specified when creating an instance (e.g., Container<int>).
             * 
             * Why use generics:
             * 1. Type Safety: Type mismatches are caught at compile time instead of runtime.
             * 2. Performance: Avoids boxing and unboxing overhead when working with value types.
             * 3. Code Reusability: We can write one class or method that works with any data type.
             */
            ArrayList nonGenericList = new ArrayList();
            nonGenericList.Add(10);
            nonGenericList.Add("Text");

            List<int> genericList = new List<int>();
            genericList.Add(10);

            Console.WriteLine($"Generic List<int> Count: {genericList.Count}, Item: {genericList[0]}");
            #endregion

            #region Question 02: Write a generic class Container<T> with Add and Get methods.
            /*
             * Question 02:
             * Write a generic class Container<T> with Add and Get methods.
             * (Implemented in GenericClass/Container.cs)
             */
            Container<int> intContainer = new Container<int>();
            intContainer.Add(100);
            intContainer.Add(200);
            intContainer.Add(300);
            Console.WriteLine($"Container<int>[0]: {intContainer.Get(0)}");
            Console.WriteLine($"Container<int>[1]: {intContainer.Get(1)}");
            Console.WriteLine($"Container<int> Count: {intContainer.Count}");

            Container<string> stringContainer = new Container<string>();
            stringContainer.Add("C# Generics");
            stringContainer.Add("ASP.NET Core");
            Console.WriteLine($"Container<string>[0]: {stringContainer.Get(0)}");
            #endregion

            #region Question 03: What are multiple type parameters? Write Pair<TKey, TValue>.
            /*
             * Question 03:
             * What are multiple type parameters? Write Pair<TKey, TValue>.
             * 
             * Answer:
             * Multiple type parameters allow a generic class or method to accept more than one type parameter,
             * separated by commas (such as class Pair<TKey, TValue>).
             * (Implemented in MultipleTypeParameters/Pair.cs)
             */
            Pair<int, string> employeePair = new Pair<int, string>(101, "Alice Smith");
            Pair<string, decimal> productPricePair = new Pair<string, decimal>("Laptop", 1250.50m);

            Console.WriteLine($"Pair 1: {employeePair}");
            Console.WriteLine($"Pair 2: {productPricePair}");
            #endregion

            #region Question 04: What is a generic method? Write Swap<T> method.
            /*
             * Question 04:
             * What is a generic method? Write Swap<T> method.
             * 
             * Answer:
             * A generic method is a method that defines its own type parameters (like void Swap<T>(ref T a, ref T b)).
             * It can be inside a normal class or a generic class, and the compiler can infer the type automatically.
             * (Implemented in GenericMethods/Utility.cs)
             */
            int a = 10, b = 20;
            Console.WriteLine($"Before Swap: a = {a}, b = {b}");
            Utility.Swap(ref a, ref b);
            Console.WriteLine($"After Swap:  a = {a}, b = {b}");

            string s1 = "Hello", s2 = "World";
            Console.WriteLine($"Before Swap: s1 = {s1}, s2 = {s2}");
            Utility.Swap(ref s1, ref s2);
            Console.WriteLine($"After Swap:  s1 = {s1}, s2 = {s2}");
            #endregion

            #region Question 05: Write a generic method FindMax<T> that finds maximum value.
            /*
             * Question 05:
             * Write a generic method FindMax<T> that finds maximum value.
             * 
             * Answer:
             * We constrain T to IComparable<T> so we can use CompareTo to compare items.
             * (Implemented in GenericMethods/Utility.cs)
             */
            int[] numbers = { 15, 42, 8, 99, 23, 74 };
            int maxNumber = Utility.FindMax(numbers);
            Console.WriteLine($"Max Number: {maxNumber}");

            Product[] products =
            {
                new Product(1, "Mouse", 25.0m),
                new Product(2, "Monitor", 350.0m),
                new Product(3, "Keyboard", 75.0m)
            };
            Product maxProduct = Utility.FindMax(products);
            Console.WriteLine($"Max Product: {maxProduct}");
            #endregion

            #region Question 06: What is a generic interface? Write IRepository<T>.
            /*
             * Question 06:
             * What is a generic interface? Write IRepository<T>.
             * 
             * Answer:
             * A generic interface is an interface defined with type parameters.
             * A class implementing it can either specify a concrete type or remain generic.
             * (Implemented in GenericInterface/IRepository.cs)
             */
            IRepository<Product> productRepo = new ProductRepository();
            productRepo.Add(new Product(1, "Laptop", 1200m));
            productRepo.Add(new Product(2, "Desk Chair", 250m));
            productRepo.Add(new Product(3, "Webcam", 80m));

            foreach (var prod in productRepo.GetAll())
            {
                Console.WriteLine($"  - {prod}");
            }

            var item = productRepo.GetById(2);
            Console.WriteLine($"GetById(2): {item}");

            productRepo.Delete(2);
            Console.WriteLine($"Remaining products count: {productRepo.GetAll().Count()}");
            #endregion

            #region Question 07: What is the 'struct' constraint? Write an example.
            /*
             * Question 07:
             * What is the 'struct' constraint? Write an example.
             * 
             * Answer:
             * The 'struct' constraint (where T : struct) means T must be a non-nullable value type (like int, double, bool).
             * Reference types and nullable types are not allowed.
             * (Implemented in Constraints/ConstraintDemos.cs)
             */
            StructContainer<int> intStruct = new StructContainer<int>(42);
            StructContainer<DateTime> dateStruct = new StructContainer<DateTime>(DateTime.Now);

            Console.WriteLine(intStruct);
            Console.WriteLine(dateStruct);
            #endregion

            #region Question 08: What is the 'class' constraint? Write an example.
            /*
             * Question 08:
             * What is the 'class' constraint? Write an example.
             * 
             * Answer:
             * The 'class' constraint (where T : class) means T must be a reference type (like string, class, interface, or array).
             * Value types are not allowed.
             * (Implemented in Constraints/ConstraintDemos.cs)
             */
            ClassContainer<string> stringRef = new ClassContainer<string>("Reference Type");
            ClassContainer<Product> productRef = new ClassContainer<Product>(new Product(10, "Tablet", 500m));

            Console.WriteLine(stringRef);
            Console.WriteLine(productRef);
            #endregion

            #region Question 09: What is the 'new()' constraint? Write an example.
            /*
             * Question 09:
             * What is the 'new()' constraint? Write an example.
             * 
             * Answer:
             * The 'new()' constraint (where T : new()) means T must have a public parameterless constructor,
             * which allows creating new instances using 'new T()'.
             * (Implemented in Constraints/ConstraintDemos.cs)
             */
            Factory<Person> personFactory = new Factory<Person>();
            Person person = personFactory.CreateInstance();
            person.Name = "John Doe";
            person.Age = 30;

            Factory<Product> productFactory = new Factory<Product>();
            Product product = productFactory.CreateInstance();
            product.Name = "Default Product";

            Console.WriteLine($"Factory created: {person}");
            Console.WriteLine($"Factory created: {product}");
            #endregion

            #region Question 10: What is the interface constraint? Write an example.
            /*
             * Question 10:
             * What is the interface constraint? Write an example.
             * 
             * Answer:
             * An interface constraint (e.g. 'where T : IComparable<T>') ensures that T implements
             * the specified interface, enabling call of interface members directly.
             * (Implemented in Constraints/ConstraintDemos.cs)
             */
            int largerInt = Sorter<int>.GetLarger(55, 89);
            Console.WriteLine($"Larger int: {largerInt}");

            Product prodA = new Product(1, "Item A", 150m);
            Product prodB = new Product(2, "Item B", 299m);
            Product largerProd = Sorter<Product>.GetLarger(prodA, prodB);
            Console.WriteLine($"Larger product: {largerProd}");
            #endregion

            #region Question 11: What is the base class constraint? Write an example.
            /*
             * Question 11:
             * What is the base class constraint? Write an example.
             * 
             * Answer:
             * A base class constraint (e.g. 'where T : Animal') ensures that T is or derives
             * from the specified base class.
             * (Implemented in Constraints/ConstraintDemos.cs)
             */
            AnimalShelter<Dog> dogShelter = new AnimalShelter<Dog>();
            dogShelter.Add(new Dog("Buddy"));
            dogShelter.Add(new Dog("Max"));
            dogShelter.MakeAllSpeak();

            AnimalShelter<Cat> catShelter = new AnimalShelter<Cat>();
            catShelter.Add(new Cat("Oliver"));
            catShelter.MakeAllSpeak();
            #endregion

            #region Question 12: How do you apply multiple constraints? Write an example.
            /*
             * Question 12:
             * How do you apply multiple constraints? Write an example.
             * 
             * Answer:
             * We separate multiple constraints with commas:
             * where T : class, IComparable<T>, new()
             * 
             * Ordering rules:
             * 1. Primary constraint (class, struct, or base class) must be first.
             * 2. Interfaces come next.
             * 3. new() must always be last.
             * (Implemented in Constraints/ConstraintDemos.cs)
             */
            EntityService<Product> service = new EntityService<Product>();
            Product registered = service.CreateAndRegister();
            registered.Id = 100;
            registered.Name = "Registered Product";
            registered.Price = 850m;

            service.Add(new Product(101, "Second Product", 450m));
            Console.WriteLine($"Max item in service: {service.GetMax()}");
            #endregion

            #region Question 13: What does the 'default' keyword do in generics?
            /*
             * Question 13:
             * What does the 'default' keyword do in generics?
             * 
             * Answer:
             * The 'default' keyword returns the default value for type T:
             * - null for reference types
             * - 0 for numeric types
             * - false for boolean
             * - zero-initialized memory for structs
             */
            Console.WriteLine($"default(int)      = {default(int)}");
            Console.WriteLine($"default(bool)     = {default(bool)}");
            Console.WriteLine($"default(double)   = {default(double)}");
            Console.WriteLine($"default(DateTime) = {default(DateTime)}");
            Console.WriteLine($"default(string)   = {(default(string) == null ? "null" : default(string))}");
            Console.WriteLine($"default(Product)  = {(default(Product) == null ? "null" : default(Product))}");
            #endregion

            #region Question 14: Write a SafeList<T> that returns default when the index is invalid.
            /*
             * Question 14:
             * Write a SafeList<T> that returns default when the index is invalid.
             * (Implemented in DefaultKeyword/SafeList.cs)
             */
            SafeList<int> safeInts = new SafeList<int>();
            safeInts.Add(10);
            safeInts.Add(20);
            Console.WriteLine($"safeInts[0]: {safeInts.GetAt(0)}");
            Console.WriteLine($"safeInts[1]: {safeInts.GetAt(1)}");
            Console.WriteLine($"safeInts[5] (invalid): {safeInts.GetAt(5)}");

            SafeList<string> safeStrings = new SafeList<string>();
            safeStrings.Add("Route");
            Console.WriteLine($"safeStrings[0]: {safeStrings.GetAt(0)}");
            Console.WriteLine($"safeStrings[99] (invalid): {(safeStrings.GetAt(99) == null ? "null" : safeStrings.GetAt(99))}");
            #endregion

            #region Question 15: What is covariance? Explain the 'out' keyword.
            /*
             * Question 15:
             * What is covariance? Explain the 'out' keyword.
             * 
             * Answer:
             * Covariance allows using a more derived type than expected (Derived -> Base).
             * It is declared on interfaces/delegates using 'out' (e.g., IProducer<out T>).
             * T can only be used as a return type (output), not as a method parameter (input).
             * "If you can produce a Dog, you can produce an Animal."
             * (Implemented in CovarianceAndContravariance/VarianceClasses.cs)
             */
            IProducer<VDog> dogProducer = new DogProducer("Rex");
            IProducer<VAnimal> animalProducer = dogProducer;

            VAnimal producedAnimal = animalProducer.Produce();
            Console.WriteLine($"Produced animal: {producedAnimal}");
            #endregion

            #region Question 16: What is contravariance? Explain the 'in' keyword.
            /*
             * Question 16:
             * What is contravariance? Explain the 'in' keyword.
             * 
             * Answer:
             * Contravariance allows using a more basic type than expected (Base -> Derived).
             * It is declared on interfaces/delegates using 'in' (e.g., IConsumer<in T>).
             * T can only be used as a method parameter (input), not as a return type (output).
             * "If you can consume an Animal, you can consume a Dog."
             * (Implemented in CovarianceAndContravariance/VarianceClasses.cs)
             */
            IConsumer<VAnimal> animalConsumer = new AnimalConsumer();
            IConsumer<VDog> dogConsumer = animalConsumer;

            dogConsumer.Consume(new VDog("Buster"));
            #endregion

            #region Question 17: What is the difference between covariance and contravariance?
            /*
             * Question 17:
             * What is the difference between covariance and contravariance?
             * 
             * Answer:
             * 1. Covariance (out):
             *    - Direction: Derived -> Base (IProducer<Dog> can be assigned to IProducer<Animal>)
             *    - Position: Output only (return types)
             *    - Example: IEnumerable<out T>
             * 
             * 2. Contravariance (in):
             *    - Direction: Base -> Derived (IConsumer<Animal> can be assigned to IConsumer<Dog>)
             *    - Position: Input only (method parameters)
             *    - Example: Action<in T>, IComparable<in T>
             */
            IProducer<VDog> pDog = new DogProducer("Max");
            IProducer<VAnimal> pAnimal = pDog;
            Console.WriteLine($"Covariant: {pAnimal.Produce()}");

            IConsumer<VAnimal> cAnimal = new AnimalConsumer();
            IConsumer<VDog> cDog = cAnimal;
            cDog.Consume(new VDog("Rocky"));
            #endregion

            #region Question 18: How do static members work in generic types?
            /*
             * Question 18:
             * How do static members work in generic types?
             * 
             * Answer:
             * Static members are not shared between different type arguments.
             * Each closed type has its own static fields in memory.
             * For example, Counter<int>.Count and Counter<string>.Count are separate variables.
             * (Implemented in StaticMembers/Counter.cs)
             */
            Counter<int>.Increment();
            Counter<int>.Increment();
            Counter<int>.Increment();

            Counter<string>.Increment();

            Console.WriteLine($"Counter<int>.Count:    {Counter<int>.Count}");
            Console.WriteLine($"Counter<string>.Count: {Counter<string>.Count}");
            Console.WriteLine($"Counter<double>.Count: {Counter<double>.Count}");
            #endregion

            #region Question 19: How can you inherit from a generic class?
            /*
             * Question 19:
             * How can you inherit from a generic class?
             * 
             * Answer:
             * 1. Specify the type directly:
             *    class IntList : MyList<int>
             * 2. Keep the derived class generic:
             *    class ObservableList<T> : MyList<T>
             * 3. Add new type parameters:
             *    class KeyedList<TKey, TValue> : MyList<TValue>
             * (Implemented in GenericInheritance/InheritanceClasses.cs)
             */
            IntList numbersList = new IntList();
            numbersList.Add(10);
            numbersList.Add(20);
            numbersList.Add(30);
            Console.WriteLine($"IntList Sum: {numbersList.Sum()}");

            ObservableList<string> obsList = new ObservableList<string>();
            obsList.ItemAdded += item => Console.WriteLine($"Item added: {item}");
            obsList.Add("Alpha");
            obsList.Add("Beta");

            KeyedList<string, int> keyedList = new KeyedList<string, int>();
            keyedList.Add("Score1", 95);
            keyedList.Add("Score2", 88);
            Console.WriteLine($"KeyedList FindByKey('Score1'): {keyedList.FindByKey("Score1")}");
            #endregion

            #region Question 20: Complete Exercise - Create a generic Cache<TKey, TValue> with Add, Get, Remove, Contains, and expiration support.
            /*
             * Question 20:
             * Complete Exercise - Create a generic Cache<TKey, TValue> with Add, Get, Remove, Contains, and expiration support.
             * (Implemented in Cache/Cache.cs)
             */
            Cache<string, string> cache = new Cache<string, string>();

            cache.Add("User_1", "Alice");
            cache.Add("Temp_Token", "XYZ-999", TimeSpan.FromMilliseconds(500));

            Console.WriteLine($"Contains 'User_1': {cache.Contains("User_1")}, Value: {cache.Get("User_1")}");
            Console.WriteLine($"Contains 'Temp_Token': {cache.Contains("Temp_Token")}, Value: {cache.Get("Temp_Token")}");

            Thread.Sleep(600);

            Console.WriteLine($"Contains 'Temp_Token' after expiration: {cache.Contains("Temp_Token")}");

            bool found = cache.TryGet("Temp_Token", out string? tokenValue);
            Console.WriteLine($"TryGet('Temp_Token'): Found={found}, Value={(tokenValue ?? "null")}");

            cache.Remove("User_1");
            Console.WriteLine($"Contains 'User_1' after Remove: {cache.Contains("User_1")}");
            Console.WriteLine($"Active items in cache: {cache.Count}");
            #endregion
        }
    }
}
