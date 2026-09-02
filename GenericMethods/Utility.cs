namespace Assignment01.GenericMethods
{
    // Q4: What is a generic method? Write Swap<T> method.
    // Q5: Write a generic method FindMax<T> that finds maximum value.
    public static class Utility
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static T FindMax<T>(T[] items) where T : IComparable<T>
        {
            if (items == null || items.Length == 0)
                throw new ArgumentException("Array cannot be null or empty.");

            T max = items[0];
            for (int i = 1; i < items.Length; i++)
            {
                if (items[i].CompareTo(max) > 0)
                {
                    max = items[i];
                }
            }
            return max;
        }

        public static void PrintArray<T>(T[] items)
        {
            Console.WriteLine($"[{string.Join(", ", items)}]");
        }
    }
}
