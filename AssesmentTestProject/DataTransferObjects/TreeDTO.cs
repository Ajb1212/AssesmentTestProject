using System.Collections.Generic;
using System.Linq;

namespace AssesmentTestProject.DataTransferObjects
{
    public class TreeDTO
    {
        public TreeDTO(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public List<TreeDTO> Children { get; private set; }

        public void AddChildren(IEnumerable<TreeDTO> children)
        {
            if (Children is null)
                Children = new List<TreeDTO>(children.Count());

            Children.AddRange(children);
        }
    }
}
