using AssesmentTestProject.DataAccess.Repositories;
using AssesmentTestProject.Models;
using System.Threading.Tasks;

namespace AssesmentTestProject.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultDBContext _db;

        public UnitOfWork(DefaultDBContext db)
        {
            _db = db;
        }

        private IHierarchyRepository _hierarchyRepository;
        public IHierarchyRepository HierarchyRepository
        {
            get
            {
                if (_hierarchyRepository is null)
                {
                    _hierarchyRepository = new HierarchyRepository(_db);
                }

                return _hierarchyRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose() => _db.Dispose();
    }
}
