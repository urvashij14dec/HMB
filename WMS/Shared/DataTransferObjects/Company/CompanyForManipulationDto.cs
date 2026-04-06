namespace Shared.DataTransferObjects.MCompany
{
    public abstract record MCompanyForManipulationDto
    {

        public string? CompCode { get; set; }

        public string? CompanyDesc { get; set; }

        public DateTime? Cdate { get; set; }

        public string? CompanyAddress { get; set; }

        public string? Tanno { get; set; }

        public string? Panno { get; set; }

        public string? Pin { get; set; }
    }
}
