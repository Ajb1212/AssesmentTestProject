using AssesmentTestProject.Models;
using System.Threading.Tasks;

namespace AssesmentTestProject.DataAccess.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> GetAsync(int id);
        void InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
