namespace Shared.DataTransferObjects.Designation
{
    public class DesignationDto
    {
        public int TableId { get; set; }
        public string DesigCode { get; set; }
        public string DesigDesc { get; set; }
        public string DesigHindi { get; set; }
        public int? OrderNumber { get; set; }
    }
}
