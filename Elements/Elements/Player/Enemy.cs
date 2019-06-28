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
    }
}
