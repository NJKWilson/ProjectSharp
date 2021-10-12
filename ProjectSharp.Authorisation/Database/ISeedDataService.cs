using System.Threading.Tasks;

namespace ProjectSharp.Authorisation.Database
{
    public interface ISeedDataService
    {
        Task SeedAdminUser();
    }
}