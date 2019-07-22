using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Elements;
using Elements.Player;
using Elements.Clothings;
namespace ElementTestRealtime
{
    class Game
    {
        public void Run()
        {
            Player p1 = CreatePlayer();
            Enemy e1 = CreateEnemy();

            int roundCounter = 0;
            while (p1.CurrentHealth > 0 && e1.CurrentHealth > 0)
            {
                Console.WriteLine(++roundCounter);
                float enemyTakeD = e1.TakeDamage(p1.Weapon);
                if (e1.CurrentHealth <= 0) break;
                float playerTakeD = p1.TakeDamage(e1.Weapon);

                WriteDamage(p1.Name, playerTakeD);
                Console.WriteLine(p1.CurrentHealth + " / " + p1.MaxHealth + " HP");
                WriteDamage(e1.Name, enemyTakeD);
                Console.WriteLine(e1.CurrentHealth + " / " + e1.MaxHealth + " HP");

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Rounds: " + roundCounter);
            Console.WriteLine("Player: " + p1.CurrentHealth + " / " + p1.MaxHealth + " HP");
            Console.WriteLine("Enemy : " + e1.CurrentHealth + " / " + e1.MaxHealth + " HP");

            Console.ReadKey();
        }

        private Enemy CreateEnemy()
        {
            /* Resistance:
             * STONE: 60
             * ICE: 20
             * FIRE: 100
             * WATER: -50
             * ELECTRICITY: 50
             * GROUND: 50
             * 
             * WEAPON:
             * ICE: 80
             * WATER: 20
            */

            string name = "Anna";
            float maxHP = 50000;
            float currentHP = maxHP;

            ElementalMix buffGear = ElementalMix.Zero()[0];
            ElementalMix[] res = new ElementalMix[] { new ElementalMix(EElementalTypes.STONE, 0.6f) };
            Top t = new Top(res, buffGear);

            buffGear = ElementalMix.Zero()[0];
            res = new ElementalMix[] { new ElementalMix(EElementalTypes.FIRE, 1f) };
            Shirt s = new Shirt(res, buffGear);

            buffGear = ElementalMix.Zero()[0];
            res = new ElementalMix[] { new ElementalMix(EElementalTypes.WATER, -0.5f) };
            Pants p = new Pants(res, buffGear);

            Gear g = new Gear(t, s, p);

            float wMinDamage = 1000;
            float wMaxDamage = 2000;
            ElementalMix[] buff = new ElementalMix[]
            {
                new ElementalMix(EElementalTypes.ICE, 0.8f),
                new ElementalMix(EElementalTypes.WATER, 0.2f)
            };
            ElementalMix[] resistance = new ElementalMix[]
            {
                new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f),
                new ElementalMix(EElementalTypes.GROUND, 0.5f),
                new ElementalMix(EElementalTypes.ICE, 0.2f),
            };

            Weapon w = new Weapon(wMinDamage, wMaxDamage, buff, resistance);

            return new Enemy(name, currentHP, maxHP, g, w);

        }

        private Player CreatePlayer()
        {
            /* Resistance:
             * ICE: 120
             * FIRE: 100
             * WATER: -50
             * ELECTRICITY: 50
             * GROUND: 50
             * 
             * WEAPON:
             * STONE: 90
             * WATER: 10
            */

            string name = "Matt";
            float maxHP = 100000;
            float currentHP = maxHP;

            ElementalMix buffGear = ElementalMix.Zero()[0];
            ElementalMix[] res = new ElementalMix[] { new ElementalMix(EElementalTypes.ICE, 1f) };
            Top t = new Top(res, buffGear);

            buffGear = ElementalMix.Zero()[0];
            res = new ElementalMix[] { new ElementalMix(EElementalTypes.FIRE, 1f) };
            Shirt s = new Shirt(res, buffGear);

            buffGear = ElementalMix.Zero()[0];
            res = new ElementalMix[] { new ElementalMix(EElementalTypes.WATER, -0.5f) };
            Pants p = new Pants(res, buffGear);

            Gear g = new Gear(t, s, p);

            float wMinDamage = 1000;
            float wMaxDamage = 2000;
            ElementalMix[] buff = new ElementalMix[]
            {
                new ElementalMix(EElementalTypes.STONE, 0.9f),
                new ElementalMix(EElementalTypes.WATER, 0.1f)
            };
            ElementalMix[] resistance = new ElementalMix[]
            {
                new ElementalMix(EElementalTypes.ELECTRICITY, 0.5f),
                new ElementalMix(EElementalTypes.GROUND, 0.5f),
                new ElementalMix(EElementalTypes.ICE, 0.2f),
            };

            Weapon w = new Weapon(wMinDamage, wMaxDamage, buff, resistance);

            return new Player(name, currentHP, maxHP, g, w);
        }

        private void WriteDamage(string _name, float _receivedDamage)
        {
            string part2 = "";
            string part4 = "";

            if (_receivedDamage < 0)
            {
                part2 = " healed ";
                part4 = " HP.";
                _receivedDamage = Math.Abs(_receivedDamage);
            }
            else
            {
                part2 = " took ";
                part4 = " damage. ";
            }

            Console.WriteLine(_name + part2 + _receivedDamage + part4);
        }
    }
}
