using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Clothings
{
    /// <summary>
    /// Shirt Class. See <seealso cref="Elements.Clothings.ClothingEntity"/>.
    /// </summary>
    /// <seealso cref="Elements.Clothings.ClothingEntity" />
    public class Shirt : ClothingEntity
    {
        /// <summary>
        /// Set Shirt with 0 Elemental Defence and 0 Elemental Buff
        /// </summary>
        public Shirt() : base() { }

        /// <summary>
        /// Set Shirt
        /// </summary>
        /// <param name="_defence">Shirt Elemental Defence</param>
        /// <param name="_buff">Shirt Elemental Buff</param>
        public Shirt(ElementalMix[] _defence, ElementalMix _buff) : base(_defence, _buff) { }

        /// <summary>
        /// Type of Clothing
        /// </summary>
        public override ClothingType Type { get { return ClothingType.SHIRT; } }
    }
}
