using AssesmentTestProject.DataAccess.Repositories;
using AssesmentTestProject.Models;
using System;
using System.Threading.Tasks;

namespace AssesmentTestProject.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        public IHierarchyRepository HierarchyRepository { get; }
    }
}
