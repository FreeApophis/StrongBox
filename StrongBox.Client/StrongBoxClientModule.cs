using Autofac;

namespace Apophis.StrongBox.Client
{
    public class StrongBoxClientModule : Module
    {
        public ClientMode ClientMode { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StrongBoxService>().As<IStrongBoxService>().SingleInstance();
        }
    }
}
