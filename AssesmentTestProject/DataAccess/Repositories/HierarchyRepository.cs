using AssesmentTestProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentTestProject.DataAccess.Repositories
{
    public class HierarchyRepository : Repository<HierarchyModel>, IHierarchyRepository
    {
        private readonly DefaultDBContext _db;

        public HierarchyRepository(DefaultDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<HierarchyModel>> GetFlattenTreeTillTheNthLayerAsync(int n)
        {
            var treeHandler = new TreeHandler(_db, n);

            var roots = await GetAllRootsAsync();
            await treeHandler.RecursivelyGetChildrenFromDatabaseAsync(roots, 1);

            return treeHandler.FlattenTree;
        }

        public async Task<IEnumerable<HierarchyModel>> GetAllRootsAsync()
        {
            return await _db.Hierarcies.Where(x => x.ParentId == null).ToListAsync();
        }

        private class TreeHandler
        {
            private readonly DefaultDBContext _db;
            private readonly int _layerLimit;

            public TreeHandler(DefaultDBContext db, int layerLimit)
            {
                _db = db;
                _layerLimit = layerLimit;
            }

            public ICollection<HierarchyModel> FlattenTree { get; private set; } = new List<HierarchyModel>();

            public async Task RecursivelyGetChildrenFromDatabaseAsync(IEnumerable<HierarchyModel> nodes, int currentLayer)
            {
                if (currentLayer <= _layerLimit)
                {
                    foreach (var node in nodes)
                    {
                        FlattenTree.Add(node);
                        var children = await _db.Hierarcies.Where(x => x.ParentId == node.Id).ToListAsync();
                        await RecursivelyGetChildrenFromDatabaseAsync(children, currentLayer + 1);
                    }
                }
            }
        }
    }
}
