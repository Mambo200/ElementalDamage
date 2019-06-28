using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Clothings
{
    public class Top : ClothingEntity
    {
        public override ClothingType Type { get { return ClothingType.TOP; } }

        public override Element ElementDefence { get; protected set; }

    }
}
