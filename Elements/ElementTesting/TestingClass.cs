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
    public class TestingClass
    {
        [TestMethod]
        public void InitializeElemental()
        {
            Top top = new Top();
            Shirt shirt = new Shirt();
            Pants pants = new Pants();


            Gear gear = new Gear(top, shirt, pants);
            Weapon weapon = new Weapon(Element.Zero(), Element.Zero(), 20, 100);
            
            Player p1 = new Player("Peter", gear, weapon);
            
        }
    }
}
