﻿using Autofac;

namespace Apophis.StrongBox
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            using var container = CompositionRoot
                .Create()
                .RegisterApplication()
                .Build();

            var application = container.Resolve<IApplication>();

            return application.Run(args);
        }
    }
}
