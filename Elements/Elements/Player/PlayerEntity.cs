using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements.Clothings;

namespace Elements.Player
{
    public abstract class PlayerEntity
    {
        public abstract PlayerType PlayerType { get; }
        public virtual float MaxHealth { get; protected set; }
        public float CurrentHealth { get; protected set; }
        public abstract Weapon Weapon { get; protected set; }
        public abstract Gear Gear { get; protected set; }
        public PlayerEntity GetEntity { get { return this; } }
    }

    public enum PlayerType
    {
        PLAYER,
        ENEMY
    }
}
