using HowToCreateWebAPI.Contracts;
using HowToCreateWebAPI.Infrastructure;

namespace HowToCreateWebAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : IbaseModel
    {

        private readonly FakeDbContext _db = new FakeDbContext();
        protected readonly List<T> _Table;
        public BaseRepository()
        {
            _Table = _db.GetTable<T>();
        }

        #region--CRUD--

        // Create
         public void Add(T model)
        {
            model.Id = _Table.Count + 1;
            _Table.Add(model);
        }

        // Retrieve
        public T GetOne(int id)
        {
            return _Table.FirstOrDefault(u => u.Id == id);
        }
        public  IEnumerable<T> GetAll()
        {
            return _Table;
        }

        // Update
        public void Update(T model)
        {
            var index = _Table.FindIndex(u => u.Id == model.Id);
            _Table[index] = model;

        }

        // Delete
        public void Delete(int id)
        {
            _Table.RemoveAll(u => u.Id == id);
        }
        #endregion
    }
}
