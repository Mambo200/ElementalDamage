using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements.Clothings;

namespace Elements.Player
{
    public class Enemy : PlayerEntity
    {
        public override PlayerType PlayerType { get { return PlayerType.ENEMY; } }

        /// <summary>
        /// Create new Enemy
        /// </summary>
        /// <param name="_name">name of Enemy</param>
        /// <param name="_currentHP">current hp of Enemy</param>
        /// <param name="_maxHP">max hp of Enemy</param>
        /// <param name="_gear">Gear of Enemy</param>
        /// <param name="_weapon">Weapon of Enemy</param>
        public Enemy(string _name, float _currentHP, float _maxHP, Gear _gear, Weapon _weapon)
        {
            Init(_name, _currentHP, _maxHP, _gear, _weapon);
        }
        public static explicit operator Enemy(Player _other)
        {
            return new Enemy
                (
                _other.Name,
                _other.CurrentHealth,
                _other.MaxHealth,
                _other.Gear,
                _other.Weapon
                );
        }
    }
}
