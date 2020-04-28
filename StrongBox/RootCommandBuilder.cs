using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using Apophis.StrongBox.Client;

namespace Apophis.StrongBox
{
    public class RootCommandBuilder : IRootCommandBuilder
    {
        private readonly IStrongBoxService _strongBoxService;
        private readonly List<Func<Command>> _commands;

        public RootCommandBuilder(IStrongBoxService strongBoxService)
        {
            _commands = new List<Func<Command>>
            {
                BuildListCommand, BuildRemoveFileCommand, TouchCommand, BuildDirectoryCommand,
                BuildRemoveDirectoryCommand, BuildPushCommand, BuildPullCommand, BuildSyncCommand,
            };

            _strongBoxService = strongBoxService;
        }

        public RootCommand Build()
        {
            return _commands.Aggregate(BuildRoot(), (root, command) =>
            {
                root.AddCommand(command());

                return root;
            });
        }

        private RootCommand BuildRoot()
        {
            return new RootCommand("StrongBox: cryptographically secure cloud space");
        }

        private Command BuildSyncCommand()
        {
            return new Command("sync", "synchronize directory with the strong box storage");
        }

        private Command BuildPullCommand()
        {
            return new Command("pull", "pull file from the strong box storage");
        }

        private Command BuildPushCommand()
        {
            return new Command("push", "push file to the strong box storage");
        }

        private Command BuildRemoveDirectoryCommand()
        {
            return new Command("rmdir", "delete directory on the strong box storage");
        }

        private Command BuildDirectoryCommand()
        {
            return new Command("mkdir", "create directory on the strong box storage");
        }

        private Command TouchCommand()
        {
            return new Command("touch", "update last changed date on the strong box storage");
        }

        private Command BuildRemoveFileCommand()
        {
            return new Command("rm", "remove a file from the strong box storage");
        }

        private Command BuildListCommand()
        {
            var command = new Command("ls", "list directory contents on the strong box storage")
            {
                Handler = CommandHandler.Create(_strongBoxService.List),
            };

            return command;
        }
    }
}