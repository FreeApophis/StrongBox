using System.Threading.Tasks;

namespace Apophis.StrongBox
{
    /// <summary>
    /// Your application interface, the Run is the main entry point to your program.
    /// </summary>
    internal interface IApplication
    {
        Task<int> Run(string[] args);
    }
}