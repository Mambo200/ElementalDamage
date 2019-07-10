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
        }
    }
}
