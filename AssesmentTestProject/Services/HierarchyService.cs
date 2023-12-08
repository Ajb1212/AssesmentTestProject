using AssesmentTestProject.DataAccess;
using AssesmentTestProject.DataAccess.Repositories;
using AssesmentTestProject.DataTransferObjects;
using AssesmentTestProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentTestProject.Services
{
    public class HierarchyService : IHierarchyService
    {
        private readonly IHierarchyRepository _hierarchyRepository;

        public HierarchyService(IUnitOfWork unitOfWork)
        {
            _hierarchyRepository = unitOfWork.HierarchyRepository;
        }

        public async Task<TreeDTO> GetTreeTillTheNthLayerAsync(int n)
        {
            var flattenTree = await _hierarchyRepository.GetFlattenTreeTillTheNthLayerAsync(n);
            var treeHandler = new TreeHandler(flattenTree);
            return treeHandler.CreateTree();
        }

        private class TreeHandler
        {
            private readonly IEnumerable<HierarchyModel> _flattenTree;

            public TreeHandler(IEnumerable<HierarchyModel> flattenTree)
            {
                _flattenTree = flattenTree;
            }

            public TreeDTO CreateTree()
            {
                var root = _flattenTree.SingleOrDefault(x => x.ParentId == null);
                var nodeLookup = _flattenTree.ToLookup(item => item.ParentId);
                return CreateTreeNode(root, nodeLookup);
            }

            private TreeDTO CreateTreeNode(HierarchyModel node, ILookup<int?, HierarchyModel> nodeLookup)
            {
                var treeNode = new TreeDTO(node.Id, node.Title);
                treeNode.AddChildren(nodeLookup[node.Id].Select(child =>
                {
                    return CreateTreeNode(child, nodeLookup);
                }));

                return treeNode;
            }
        }
    }
}
