namespace Entities.Exceptions.Organisation
{
    public sealed class OrganisationNotFoundException : NotFoundException
    {
        public OrganisationNotFoundException(int organisationId)
            : base($"The organisation with id: {organisationId} doesn't exist in the database.")
        {
        }
    }
}
