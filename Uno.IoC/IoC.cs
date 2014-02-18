using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Facilities.TypedFactory;
using Uno.DataTypes.Interfaces;
using Uno.Game.Deck;

namespace Uno.IoC
{
    public class IoC : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<ICard>().ImplementedBy<Card>().LifestyleTransient());
            //container.AddFacility<TypedFactoryFacility>();
            //container.Register(Component.For<IMyFirstFactory>().AsFactory());
            //container
            //    .Register(Component.For<IStartPageModel>().ImplementedBy<StartPageModel>().LifestyleTransient())
            //    .Register(Component.For<IStartPageViewModel>().ImplementedBy<StartPageViewModel>().LifestyleTransient())
            //    .Register(Component.For<IHeading>().ImplementedBy<Heading>().LifestyleTransient())
            //    .Register(Component.For<IShell>().ImplementedBy<Shell>().LifestyleTransient())
            //    .Register(Component.For<MainWindow>().LifestyleTransient());
        }
    }
}
