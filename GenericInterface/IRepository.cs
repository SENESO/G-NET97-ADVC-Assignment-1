namespace Assignment01.GenericInterface
{
    // Q6: Generic Interface IRepository<T>
    public interface IRepository<T>
    {
        void Add(T entity);
        T? GetById(int id);
        IEnumerable<T> GetAll();
        bool Delete(int id);
    }
}
