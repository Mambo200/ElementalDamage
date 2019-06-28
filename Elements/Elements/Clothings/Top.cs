using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Clothings
{
    public class Top : ClothingEntity
    {
        /// <summary>
        /// Set Top with 0 Elemental Defence and 0 Elemental Buff
        /// </summary>
        public Top()
        {
            ElementBuff = Element.Zero();
            ElementDefence = Element.Zero();
        }

        /// <summary>
        /// Set Top
        /// </summary>
        /// <param name="_defence">Top Elemental Defence</param>
        /// <param name="_buff">Top Elemental Buff</param>
        public Top(Element _defence, Element _buff)
        {
            ElementDefence = _defence;
            ElementBuff = _buff;
        }

        /// <summary>
        /// Type of Clothing
        /// </summary>
        public override ClothingType Type { get { return ClothingType.TOP; } }
    }
}
