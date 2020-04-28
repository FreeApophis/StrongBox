using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;

namespace Apophis.StrongBox
{
    public class RootCommandBuilder : IRootCommandBuilder
    {
        private readonly List<Func<Command>> _commands = new List<Func<Command>> { BuildListCommand, BuildRemoveFileCommand, TouchCommand, BuildDirectoryCommand, BuildRemoveDirectoryCommand, BuildPushCommand, BuildPullCommand, BuildSyncCommand };

        public RootCommand Build()
        {
            return _commands.Aggregate(BuildRoot(), (root, command) =>
            {
                root.AddCommand(command());

                return root;
            });
        }

        private static RootCommand BuildRoot()
        {
            return new RootCommand("StrongBox: cryptographically secure cloud space");
        }

        private static Command BuildSyncCommand()
        {
            return new Command("sync", "synchronize directory with the strong box storage");
        }

        private static Command BuildPullCommand()
        {
            return new Command("pull", "pull file from the strong box storage");
        }

        private static Command BuildPushCommand()
        {
            return new Command("push", "push file to the strong box storage");
        }

        private static Command BuildRemoveDirectoryCommand()
        {
            return new Command("rmdir", "delete directory on the strong box storage");
        }

        private static Command BuildDirectoryCommand()
        {
            return new Command("mkdir", "create directory on the strong box storage");
        }

        private static Command TouchCommand()
        {
            return new Command("touch", "update last changed date on the strong box storage");
        }

        private static Command BuildRemoveFileCommand()
        {
            return new Command("rm", "remove a file from the strong box storage");
        }

        private static Command BuildListCommand()
        {
            return new Command("ls", "list directory contents on the strong box storage");
        }
    }
}