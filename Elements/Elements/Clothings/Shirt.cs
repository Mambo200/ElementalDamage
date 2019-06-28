using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Clothings
{
    public class Shirt : ClothingEntity
    {
        /// <summary>
        /// Set Shirt with 0 Elemental Defence and 0 Elemental Buff
        /// </summary>
        public Shirt()
        {
            ElementBuff = Element.Zero();
            ElementDefence = Element.Zero();
        }

        /// <summary>
        /// Set Shirt
        /// </summary>
        /// <param name="_defence">Shirt Elemental Defence</param>
        /// <param name="_buff">Shirt Elemental Buff</param>
        public Shirt(Element _defence, Element _buff)
        {
            ElementDefence = _defence;
            ElementBuff = _buff;
        }

        /// <summary>
        /// Type of Clothing
        /// </summary>
        public override ClothingType Type { get { return ClothingType.SHIRT; } }
    }
}
