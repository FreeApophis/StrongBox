using System.CommandLine;

namespace Apophis.StrongBox
{
    public interface IRootCommandBuilder
    {
        RootCommand Build();
    }
}