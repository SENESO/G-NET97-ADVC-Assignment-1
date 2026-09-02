namespace Assignment01.GenericInterface
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly List<Product> _products = new();

        public void Add(Product entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _products.Add(entity);
        }

        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products.AsReadOnly();
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product is not null)
            {
                return _products.Remove(product);
            }
            return false;
        }
    }
}
