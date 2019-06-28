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
        public override Weapon Weapon { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }
        public override Gear Gear { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

        public override PlayerType PlayerType { get { return PlayerType.PLAYER; } }
    }
}
