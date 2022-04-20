using eCommerceForPeripherials.Data;

namespace eCommerceForPeripherials.Services
{
    public interface IDbService
    {
        ApplicationDbContext GetDbContext();
    }
}
