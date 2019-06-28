using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public class Weapon
    {
        public Weapon()
        {
            ElementalDamage = Element.RandomElements(1);
            ElementalDefence = Element.RandomElements(2);
        }

        public Weapon(Element _eDamage, Element _eDefense, float _minDamage, float _maxDamage)
        {
            ElementalDamage = _eDamage;
            ElementalDefence = _eDefense;
            MinDamage = _minDamage;
            MaxDamage = _maxDamage;
        }

        public virtual Element ElementalDamage { get; protected set; }
        public virtual Element ElementalDefence { get; protected set; }
        public virtual float MinDamage { get; protected set; }
        public virtual float MaxDamage { get; protected set; }
        public float MidPoint { get { return (MinDamage + MaxDamage) / 2; } }

    }
}
