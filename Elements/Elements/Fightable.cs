using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public abstract class Fightable
    {
        private int Hp;
        public virtual int HP {
            get { return Hp; }
            protected set { Hp = Hp - value > 0 ? value : 0; }
        }

        private string name;
        public virtual string Name {
            get { return name; }
            protected set { name = value; }
        }

        private Resistance resistance;
        public virtual Resistance Resistance {
            get { return resistance + weapon.Resistance;}
            protected set { resistance = value; }
        }

        private Weapon weapon;
        public virtual Weapon Weapon
        {
            get { return weapon; }
            protected set { weapon = value; }
        }

        /// <summary>
        /// This Method is called at the guy who RECEIVES damage
        /// </summary>
        /// <param name="_attacker"></param>
        public virtual void GetDamage(Fightable _attacker)
        {
            ReceiveDamage(_attacker.Weapon.GetDamage(), _attacker.Weapon.Damage.Damages);
            AfterGetDamage(_attacker);
        }

        public virtual void ReceiveDamage(int _damage, Element _weaponElement)
        {
            int damage = _damage;

            ELEMENTTYPE eType = Weapon.WeaponElement;

            switch (eType)
            {
                case ELEMENTTYPE.NONE:
                    break;
                case ELEMENTTYPE.WATER:
                    break;
                case ELEMENTTYPE.EARTH:
                    break;
                case ELEMENTTYPE.FIRE:
                    break;
                case ELEMENTTYPE.WIND:
                    break;
                case ELEMENTTYPE.POISON:
                    break;
                case ELEMENTTYPE.ELECTRICITY:
                    break;
                case ELEMENTTYPE.HOLY:
                    break;
                case ELEMENTTYPE.DARK:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This Method is called at the guy who RECEIVED damage
        /// </summary>
        /// <param name="_other"></param>
        public virtual void AfterGetDamage(Fightable _attacker) { }
    }
}
