using System.Threading.Tasks;

namespace Apophis.StrongBox.Client
{
    public interface IStrongBoxService
    {
        Task<int> List();
    }
}