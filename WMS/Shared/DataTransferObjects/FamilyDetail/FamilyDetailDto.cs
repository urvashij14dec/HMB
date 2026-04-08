namespace Shared.DataTransferObjects.FamilyDetail
{
    public class FamilyDetailDto
    {
        public int RowId { get; set; }
        public string? Ecode { get; set; }
        public string? PersonName { get; set; }
        public int? RelationWithEmp { get; set; }
        public string? Sex { get; set; }
        public string? PersonStatus { get; set; }
        public string? Dependent { get; set; }
    }
}
