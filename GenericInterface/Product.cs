namespace Assignment01.GenericInterface
{
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Product() { }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int CompareTo(Product? other)
        {
            if (other is null) return 1;
            return Price.CompareTo(other.Price);
        }

        public override string ToString() => $"Product [Id={Id}, Name={Name}, Price={Price:C}]";
    }
}
