using Audi100.Models;
using System.Threading.Tasks;

namespace Audi100.Server.Repository
{
    public interface ILoginRepository
    {
        Task<User?> AuthenticateUserAsync(string userName, string password);
    }
}
