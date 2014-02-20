using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Facilities.TypedFactory;
using Uno.Structures.Interfaces;
using Uno.Game.Deck;
using Castle.Windsor;
using Uno.Structures.Factories;

namespace Uno.IoC
{
    public class IoC : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Contract.Assume(container != null);
            container.AddFacility<TypedFactoryFacility>();
            container.Register(Component.For<ICardFactory>().AsFactory());
            container.Register(Component.For<ICard>().ImplementedBy<Card>().LifestyleTransient());
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
