using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements.Clothings;

namespace Elements.Player
{
    public class Player : PlayerEntity
    {
        /// <summary>
        /// Create new Player
        /// </summary>
        /// <param name="_name">name of Player</param>
        /// <param name="_currentHP">current hp of player</param>
        /// <param name="_maxHP">max hp of Player</param>
        /// <param name="_gear">Gear of Player</param>
        /// <param name="_weapon">Weapon of Player</param>
        public Player(string _name, float _currentHP, float _maxHP, Gear _gear, Weapon _weapon)
        {
            Init(_name, _currentHP, _maxHP, _gear, _weapon);
        }

        /// <summary>Player Type</summary>
        public override PlayerType PlayerType { get { return PlayerType.PLAYER; } }

        /// <summary>
        /// Set Name of Player
        /// </summary>
        /// <param name="_newName">New Name of Player</param>
        public void SetName(string _newName) => Name = _newName;
        /// <summary>
        /// Set new Gear
        /// </summary>
        /// <param name="_newGear">New Gear of Player</param>
        public void SetGear(Gear _newGear) => Gear = _newGear;
        /// <summary>
        /// Set new Gear
        /// </summary>
        /// <param name="_newTop">New Top of Player</param>
        /// <param name="_newShirt">New Shirt of Player</param>
        /// <param name="_newPants">New Pants of Player</param>
        public void SetGear(Top _newTop, Shirt _newShirt, Pants _newPants) 
            => Gear = new Gear(_newTop, _newShirt, _newPants);

        public static explicit operator Player(Enemy _other)
        {
            return new Player
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
