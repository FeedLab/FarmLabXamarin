using System.Threading.Tasks;

namespace FarmLabDevice
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }
}
