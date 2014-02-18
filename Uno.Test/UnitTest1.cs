using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Uno.DataTypes.Interfaces;
using Uno.Game.Deck;
using Uno.DataTypes.Enums;

namespace Uno.Test
{
    [TestClass]
    public class UnitTest1
    {
        static IWindsorContainer container;
        static ICard _card;

        [TestMethod]
        public void Setup()
        {
            container = new WindsorContainer();
            container.Install(FromAssembly.This());
            container.Register(Component.For<ICard>().ImplementedBy<Card>());
            _card = container.Resolve<ICard>();
        }
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(_card.GetColor + " " + _card.GetValue);
        }
    }
}
