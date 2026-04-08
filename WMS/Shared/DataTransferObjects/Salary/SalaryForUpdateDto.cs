namespace Shared.DataTransferObjects.Salary
{
    public class SalaryForUpdateDto
    {
        public decimal? Basic { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string PayMode { get; set; }
    }
}
