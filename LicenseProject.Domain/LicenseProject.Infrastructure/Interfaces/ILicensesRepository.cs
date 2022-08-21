using LicenseProject.Domain.Models;

namespace LicenseProject.Infrastructure
{
    public interface ILicensesRepository
    {
        void Create(Licenses license);
        void Delete(Licenses licenses);
        IEnumerable<Licenses> ReturnAll();
        Licenses ReturnById(Guid id);
    }
}