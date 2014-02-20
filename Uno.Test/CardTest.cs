using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Uno.Structures.Factories;
using Uno.Structures.Interfaces;
using Uno.Game.Deck;
using Uno.Structures.Enums;
using Castle.DynamicProxy;
using Uno.Interfaces.Interceptors;
using Castle.Facilities.TypedFactory;

namespace Uno.Test
{
    [TestClass]
    public class CardTest
    {
        private IWindsorContainer GetContainer()
        {
            return new WindsorContainer()
                .Install(FromAssembly.This())
                .AddFacility<TypedFactoryFacility>()
                .Register(Component.For<ICardFactory>().AsFactory())
                .Register(Component.For<ICard>().ImplementedBy<Card>().LifestyleTransient());
        }
        [TestMethod]
        public void TestCardBehavior()
        {
            var container = GetContainer();
            var factory = container.Resolve<ICardFactory>();
            var colors = Enum.GetValues(typeof(ECardColor));
            var values = Enum.GetValues(typeof(ECardValue));
            foreach (var color in colors)
            {
                if ((ECardColor)color == ECardColor.Undefined) continue;

                foreach (var value in values)
                {
                    var card = factory.Create((ECardColor) color, (ECardValue) value);

                    Assert.AreEqual(card.Color, (ECardColor) color);
                    Assert.AreEqual(card.Value, (ECardValue) value);
                    card.Reset();
                    if (card.Value == ECardValue.ColorChange || card.Value == ECardValue.ColorChangePlusFour)
                    {
                        Assert.AreEqual(card.Color, ECardColor.Undefined);
                    }
                    else
                    {
                        Assert.AreEqual(card.Color, (ECardColor) color);
                    }
                    Console.WriteLine(card.Color + " " + card.Value);
                    factory.Release(card);
                }

            }
            factory.Dispose();
            Assert.AreEqual(1, 1);
        }
    }
}
