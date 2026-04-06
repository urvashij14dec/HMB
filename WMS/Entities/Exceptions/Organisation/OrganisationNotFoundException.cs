namespace Entities.Exceptions.MCompany
{
    public sealed class MCompanyNotFoundException : NotFoundException
    {
        public MCompanyNotFoundException(int companyId)
            : base($"The company with id: {companyId} doesn't exist in the database.")
        {
        }
    }
}
