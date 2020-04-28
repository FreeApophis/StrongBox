using System.CommandLine;

namespace Apophis.StrongBox
{
    public class RootCommandBuilder : IRootCommandBuilder
    {
        public RootCommand Build()
        {
            var root = new RootCommand("StrongBox: cryptographically secure cloud space");

            root.AddCommand(new Command("ls", "list directory contents on the strong box storage"));
            root.AddCommand(new Command("rm", "remove a file from the strong box storage"));
            root.AddCommand(new Command("touch", "update last changed date on the strong box storage"));
            root.AddCommand(new Command("mkdir", "create directory on the strong box storage"));
            root.AddCommand(new Command("rmdir", "delete directory on the strong box storage"));
            root.AddCommand(new Command("push", "push file to the strong box storage"));
            root.AddCommand(new Command("pull", "pull file from the strong box storage"));
            root.AddCommand(new Command("sync", "synchronize directory with the strong box storage"));

            return root;
        }
    }
}