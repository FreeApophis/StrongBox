using System.CommandLine;
using System.Threading.Tasks;

namespace Apophis.StrongBox
{
    /// <summary>
    /// Your application implementation, the Run is the main entry point to your program.
    /// </summary>
    internal class Application : IApplication
    {
        private readonly IRootCommandBuilder _rootCommandBuilder;

        public Application(IRootCommandBuilder rootCommandBuilder)
        {
            _rootCommandBuilder = rootCommandBuilder;
        }

        public async Task<int> Run(string[] args)
        {
            // Parse the incoming args and invoke the handler
            return await _rootCommandBuilder
                .Build()
                .InvokeAsync(args);
        }
    }
}