namespace Shared.DataTransferObjects.Nominee
{
    public class NomineeDto
    {
        public int RowId { get; set; }
        public string? Ecode { get; set; }
        public string? NomineeName { get; set; }
        public string? RelationWithEmp { get; set; }
        public decimal? AmtPercent { get; set; }
    }
}
