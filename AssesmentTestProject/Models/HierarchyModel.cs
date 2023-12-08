namespace AssesmentTestProject.Models
{
    public class HierarchyModel : BaseModel
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int Link { get; set; }
        public int? ParentId { get; set; }
    }
}
