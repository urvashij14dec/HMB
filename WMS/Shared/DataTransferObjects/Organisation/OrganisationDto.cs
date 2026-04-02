namespace Shared.DataTransferObjects.Organisation
{
    public record OrganisationDto
    {
        public int TableId { get; set; }
        public string? Name { get; set; }
        public string? Shname { get; set; }
        public string? Ceoname { get; set; }
        public string? Contact { get; set; }
        public string? RegistrationNum { get; set; }
        public DateTime? RegistrationDt { get; set; }
        public string? Pan { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? SelfFlag { get; set; }
        public string? Logo { get; set; }
        public string? LogoName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }
    }
}
