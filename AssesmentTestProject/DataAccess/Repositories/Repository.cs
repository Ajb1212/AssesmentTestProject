using AssesmentTestProject.Models;
using System.Threading.Tasks;

namespace AssesmentTestProject.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly DefaultDBContext _db;

        public Repository(DefaultDBContext db) => _db = db;

        public void Delete(T entity) => _db.Remove(entity);

        public async Task<T> GetAsync(int id) => await _db.FindAsync<T>(id);

        public async void InsertAsync(T entity) => await _db.AddAsync(entity);

        public void Update(T entity) => _db.Update(entity);
    }
}
