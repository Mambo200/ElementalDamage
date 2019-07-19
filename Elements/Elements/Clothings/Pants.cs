using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Clothings
{
    public class Pants : ClothingEntity
    {
        /// <summary>
        /// Set Pants with 0 Elemental Defence and 0 Elemental Buff
        /// </summary>
        public Pants() : base() { }

        /// <summary>
        /// Set Pants
        /// </summary>
        /// <param name="_defence">Pants Elemental Defence</param>
        /// <param name="_buff">Pants Elemental Buff</param>
        public Pants(ElementalMix[] _defence, ElementalMix _buff) : base(_defence, _buff) { }

        /// <summary>
        /// Type of Clothing
        /// </summary>
        public override ClothingType Type { get { return ClothingType.PANTS; } }
    }
}
