using System.Threading.Tasks;

namespace Apophis.StrongBox.Client
{
    public class StrongBoxService : IStrongBoxService
    {
        public StrongBoxService()
        {
        }

        public Task<int> List()
        {
            System.Console.WriteLine("nothing to list");

            return Task.Run(() => 0);
        }
    }
}