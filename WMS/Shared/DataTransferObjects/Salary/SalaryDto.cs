namespace Shared.DataTransferObjects.Salary
{
    public class SalaryDto
    {
        public long TabId { get; set; }
        public string Ecode { get; set; }
        public decimal? Basic { get; set; }
        public decimal? GrossPay { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
    }
}
