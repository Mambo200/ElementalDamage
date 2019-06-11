using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public class Player : Fightable
    {
        private Player() { }

        /// <summary>
        /// Player Constructor
        /// </summary>
        /// <param name="_hp">HP of Player</param>
        /// <param name="_name">Name of Player</param>
        /// <param name="_resistance">Resistance of Player</param>
        /// <param name="_weapon">Weapon of Player</param>
        public Player(int _hp, string _name, Resistance _resistance, Weapon _weapon)
        {
            HP = _hp;
            Name = _name;
            Resistance = _resistance;
            Weapon = _weapon;
        }

        ~Player()
        {

        }
    }
}
