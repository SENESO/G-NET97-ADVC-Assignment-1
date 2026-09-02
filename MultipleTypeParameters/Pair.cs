namespace Assignment01.MultipleTypeParameters
{
    // Q3: What are multiple type parameters? Write Pair<TKey, TValue>.
    public class Pair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString() => $"Key: {Key}, Value: {Value}";
    }
}
