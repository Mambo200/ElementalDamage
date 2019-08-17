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
            Weapon weapon = new Weapon(100, 100, null, new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f));

            Player p1 = new Player("Peter", 1000, 1000, gear, weapon);
        }

        [TestMethod]
        public void DealDamage()
        {
            Top top = new Top();
            Shirt shirt = new Shirt();
            Pants pants = new Pants();
            Gear gear = new Gear(top, shirt, pants);
            ElementalMix[] attack = new ElementalMix[]
            {
                new ElementalMix(EElementalTypes.NONE, 0.5f),
                new ElementalMix(EElementalTypes.FIRE, 0.5f),
            };

            Weapon weapon = new Weapon(100, 100, attack, new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f), new ElementalMix(EElementalTypes.NONE, 0.5f));
            Player p1 = new Player("Peter", 1000, 1000, gear, weapon);


            ElementalMix[] defence = new ElementalMix[2];
            defence[0] = new ElementalMix(EElementalTypes.ELECTRICITY, 1);
            defence[1] = new ElementalMix(EElementalTypes.FIRE, 1);
            top = new Top(defence, ElementalMix.ZeroOne());
            shirt = new Shirt();
            pants = new Pants();
            gear = new Gear(top, shirt, pants);
            weapon = new Weapon(100, 100, null, new ElementalMix(EElementalTypes.GROUND, 0.7f), new ElementalMix(EElementalTypes.ELECTRICITY, 0.3f));
            Player p2 = new Player("Hans", 1000, 1000, gear, weapon);

            float damage = p2.TakeDamage(p1.Weapon);
            Assert.AreEqual(50, damage);
        }

        [TestMethod]
        public void DealNoDamage()
        {
            Top top = new Top();
            Shirt shirt = new Shirt();
            Pants pants = new Pants();
            Gear gear = new Gear(top, shirt, pants);
            ElementalMix[] attack = new ElementalMix[]
            {
                new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f),
                new ElementalMix(EElementalTypes.FIRE, 0.5f),
            };

            Weapon weapon = new Weapon(100, 300, attack, new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f), new ElementalMix(EElementalTypes.NONE, 0.5f));
            Player p1 = new Player("Peter", 1000, 1000, gear, weapon);


            ElementalMix[] defence = new ElementalMix[2];
            defence[0] = new ElementalMix(EElementalTypes.ELECTRICITY, 2);
            defence[1] = new ElementalMix(EElementalTypes.FIRE, 0);
            top = new Top(defence, ElementalMix.ZeroOne());
            shirt = new Shirt();
            pants = new Pants();
            gear = new Gear(top, shirt, pants);
            weapon = new Weapon(100, 100, null, new ElementalMix(EElementalTypes.GROUND, 0.7f), new ElementalMix(EElementalTypes.NONE, 0.3f));
            Player p2 = new Player("Hans", 1000, 1000, gear, weapon);

            float damage = p2.TakeDamage(p1.Weapon);
            Assert.AreEqual(0, damage);
        }

        [TestMethod]
        public void DealHealDamage()
        {
            Top top = new Top();
            Shirt shirt = new Shirt();
            Pants pants = new Pants();
            Gear gear = new Gear(top, shirt, pants);
            ElementalMix[] attack = new ElementalMix[]
            {   
                new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f),
                new ElementalMix(EElementalTypes.NORMAL, 0.5f),
            };

            Weapon weapon = new Weapon(100, 100, attack, new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f), new ElementalMix(EElementalTypes.NONE, 0.5f));
            Player p1 = new Player("Peter", 1000, 1000, gear, weapon);


            ElementalMix[] defence = new ElementalMix[2];
            defence[0] = new ElementalMix(EElementalTypes.ELECTRICITY, 3);
            defence[1] = new ElementalMix(EElementalTypes.FIRE, 1);
            top = new Top(defence, ElementalMix.ZeroOne());
            shirt = new Shirt();
            pants = new Pants();
            gear = new Gear(top, shirt, pants);
            weapon = new Weapon(100, 100, null, new ElementalMix(EElementalTypes.GROUND, 0.7f), new ElementalMix(EElementalTypes.NONE, 0.3f));
            Player p2 = new Player("Hans", 1000, 1000, gear, weapon);

            float damage = p2.TakeDamage(p1.Weapon);
            Assert.AreEqual(-50, damage);

        }

        [TestMethod]
        public void DealHealDamage2()
        {
            Top top = new Top();
            Shirt shirt = new Shirt();
            Pants pants = new Pants();
            Gear gear = new Gear(top, shirt, pants);
            ElementalMix[] attack = new ElementalMix[]
            {
                new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f),
                new ElementalMix(EElementalTypes.NONE, 0.5f),
            };

            Weapon weapon = new Weapon(100, 100, attack, new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f), new ElementalMix(EElementalTypes.NONE, 0.5f));
            Player p1 = new Player("Peter", 1000, 1000, gear, weapon);


            ElementalMix[] defence = new ElementalMix[2];
            defence[0] = new ElementalMix(EElementalTypes.ELECTRICITY, 2);
            defence[1] = new ElementalMix(EElementalTypes.NONE, 2);
            top = new Top(defence, ElementalMix.ZeroOne());
            shirt = new Shirt();
            pants = new Pants();
            gear = new Gear(top, shirt, pants);
            weapon = new Weapon(100, 100, null, new ElementalMix(EElementalTypes.GROUND, 0.7f), new ElementalMix(EElementalTypes.NORMAL, 0.3f));
            Player p2 = new Player("Hans", 1000, 1000, gear, weapon);

            float damage = p2.TakeDamage(p1.Weapon);
            Assert.AreEqual(-100, damage);

        }

        [TestMethod]
        public void WeaponResistance()
        {
            Top top = new Top();
            Shirt shirt = new Shirt();
            Pants pants = new Pants();
            Gear gear = new Gear(top, shirt, pants);
            Weapon weapon = new Weapon(100, 100, null, new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f), new ElementalMix(EElementalTypes.NONE, 0.5f));

            ElementalMix[] defence = new ElementalMix[2];
            defence[0] = new ElementalMix(EElementalTypes.ELECTRICITY, 1);
            defence[1] = new ElementalMix(EElementalTypes.NONE, 1);
            top = new Top(defence, ElementalMix.ZeroOne());
            shirt = new Shirt();
            pants = new Pants();
            gear = new Gear(top, shirt, pants);
            defence = new ElementalMix[] { new ElementalMix(EElementalTypes.ELECTRICITY, 1) };
            weapon = new Weapon(100, 100, defence, new ElementalMix(EElementalTypes.GROUND, 0.7f), new ElementalMix(EElementalTypes.NONE, 0.3f), defence[0]);
            Player p1 = new Player("Hans", 1000, 1000, gear, weapon);

            var v = p1.TotalResistance[EElementalTypes.ELECTRICITY];
            Assert.AreEqual(2, v);
        }

        [TestMethod]
        public void AddDefence()
        {
            Top t = new Top();
            Shirt s = new Shirt();
            Pants p = new Pants();

            Elements.Weapon weapon = new Elements.Weapon(10, 20, Elements.ElementalMix.Zero(), Elements.ElementalMix.ZeroOne());

            Enemy enemy = new Enemy("Hans", 100, 100, new Gear(t, s, p), weapon);

            bool work = enemy.Gear.AddElementDefence(out ElementalMix[] noAdd, new ElementalMix(EElementalTypes.GROUND, 0.5f), new ElementalMix(EElementalTypes.GROUND, 0.5f), new ElementalMix(EElementalTypes.GROUND, 0.5f), new ElementalMix(EElementalTypes.GROUND, 0.5f));
            Assert.AreEqual(false, work);
            work = enemy.Gear.RemoveElementDefence(out EElementalTypes[] noAddTypes, EElementalTypes.GROUND, EElementalTypes.GROUND, EElementalTypes.GROUND, EElementalTypes.GROUND);
            Assert.AreEqual(false, work);
            Assert.AreEqual(noAddTypes[0], EElementalTypes.GROUND);
        }

    }
}
