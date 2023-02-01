using Library.Models;

namespace Library.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        public T Get(int id);
        IEnumerable<T> GetAll();
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save();

    }
}
