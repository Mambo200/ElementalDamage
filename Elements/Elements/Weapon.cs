using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public class Weapon
    {
        /// <summary>
        /// Creates a Weapon with one random Elemental Damage and two randon Elemental Defence. Attack goes from 10 to 100
        /// </summary>
        public Weapon()
        {
            ElementalDamage = Element.RandomElements(1);
            ElementalDefence = Element.RandomElements(2);
            MinDamage = 10;
            MaxDamage = 100;
        }

        /// <summary>
        /// Creates a Weapon
        /// </summary>
        /// <param name="_eDamage">Weapons elemental damage</param>
        /// <param name="_eDefense">Elemental defence the Weapon gives to the Player</param>
        /// <param name="_minDamage">minimum damage of Weapon (resistance not included)</param>
        /// <param name="_maxDamage">maximum damage of Weapon (resistance not included)</param>
        public Weapon(Element _eDamage, Element _eDefense, float _minDamage, float _maxDamage)
        {
            ElementalDamage = _eDamage;
            ElementalDefence = _eDefense;
            MinDamage = _minDamage;
            MaxDamage = _maxDamage;
        }

        /// <summary>Hot much of Weapondamage is Elemental Damage</summary>
        public virtual float PercentageOfElementDamage { get; protected set; }
        /// <summary>Elemental Damage of Weapon</summary>
        public virtual Element ElementalDamage { get; protected set; }
        /// <summary>Elemental Defence of Weapon which will be added to Player Elemental Defence</summary>
        public virtual Element ElementalDefence { get; protected set; }
        /// <summary>Minimum Damage the weapon can deal (if enemy has no resistance)</summary>
        public virtual float MinDamage { get; protected set; }
        /// <summary>Maximum Damage the weapon can deal (if enemy has no weaknesses)</summary>
        public virtual float MaxDamage { get; protected set; }
        /// <summary>Average Damage of weapon</summary>
        public float MidPoint { get { return (MinDamage + MaxDamage) / 2; } }

    }
}
