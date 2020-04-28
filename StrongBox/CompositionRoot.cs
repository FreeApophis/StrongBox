using Apophis.StrongBox.Client;
using Autofac;

namespace Apophis.StrongBox
{
    /// <summary>
    /// This is the composition root of your program, register your services here.
    /// </summary>
    internal class CompositionRoot
    {
        private readonly ContainerBuilder _builder = new ContainerBuilder();

        private CompositionRoot()
        {
        }

        public static CompositionRoot Create()
        {
            return new CompositionRoot();
        }

        public CompositionRoot RegisterApplication()
        {
            _builder.RegisterType<Application>().As<IApplication>();
            _builder.RegisterType<RootCommandBuilder>().As<IRootCommandBuilder>();

            return this;
        }

        public CompositionRoot RegisterModules()
        {
            _builder.RegisterModule(new StrongBoxClientModule
            {
                ClientMode = ClientMode.Local,
            });

            return this;
        }

        public IContainer Build()
        {
            return _builder.Build();
        }
    }
}
