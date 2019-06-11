using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public abstract class Enemy : Fightable
    {
        private Enemy() { }

        public Enemy(int _hp, string _name, Resistance _resistance, Weapon _weapon)
        {
            HP = _hp;
            Name = _name;
            Resistance = _resistance;
            Weapon = _weapon;
        }
    }
}
