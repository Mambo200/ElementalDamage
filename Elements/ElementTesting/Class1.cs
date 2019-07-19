using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Elements;
using Elements.Clothings;
using Elements.Player;


namespace ElementTesting
{
    [TestClass]
    public class Class1
    {
        private static Random r = new Random();
        [TestMethod]
        public void InitializeElemental()
        {
            Player p1 = new Player();

            ElementMix Element = new ElementMix();
            Assert.AreEqual(EElement.NONE, Element.Element);
            Assert.AreEqual(0f, Element.Multiplier);

            Element = new ElementMix(EElement.FIRE, 1);
            Element = ElementMix.RandomElement();
            Element = new ElementMix(EElement.NONE, 5);

            Weapon weapon = new Weapon(
                100,
                100,
                new ElementMix(EElement.FIRE, 1.5f),
                new ElementMix(EElement.FIRE, 1f),
                new ElementMix(EElement.WATER, 0f),
                new ElementMix(EElement.BOMB, 1.5f)
                );

            Assert.AreEqual(100f, weapon.CalculateDamage());

            Weapon weapon1 = new Weapon();
            Weapon weapon2 = new Weapon();

            try
            {
                weapon2 = new Weapon(100, 50, Element, Element);
            }
            catch (Exception)
            {
            }

            Assert.AreEqual(weapon1, weapon2);

            Element = new ElementMix(EElement.FIRE, 2);
            weapon1.AddElementAttack(Element);
            weapon1.AddElementAttack(Element);
            weapon1.AddElementAttack(Element);
            weapon1.AddElementAttack(Element);
            weapon2.AddElementAttack(Element);

            weapon2.ChangeElementValueAttack(Element.Element, 0);
            Assert.AreNotEqual(weapon1, weapon2);
        }
    }
}
