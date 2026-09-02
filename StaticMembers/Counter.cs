namespace Assignment01.StaticMembers
{
    // Q18: How do static members work in generic types?
    public class Counter<T>
    {
        public static int Count { get; private set; } = 0;

        public static void Increment() => Count++;

        public static void Reset() => Count = 0;
    }
}
