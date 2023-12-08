using AssesmentTestProject.DataTransferObjects;
using System.Threading.Tasks;

namespace AssesmentTestProject.Services
{
    public interface IHierarchyService
    {
        Task<TreeDTO> GetTreeTillTheNthLayerAsync(int n);
    }
}
