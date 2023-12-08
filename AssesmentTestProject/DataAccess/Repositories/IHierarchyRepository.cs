using AssesmentTestProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssesmentTestProject.DataAccess.Repositories
{
    public interface IHierarchyRepository : IRepository<HierarchyModel>
    {
        Task<IEnumerable<HierarchyModel>> GetFlattenTreeTillTheNthLayerAsync(int n);
    }
}
