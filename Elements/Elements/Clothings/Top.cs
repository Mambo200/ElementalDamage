using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Clothings
{
    /// <summary>
    /// Top Class. See <seealso cref="Elements.Clothings.ClothingEntity"/>.
    /// </summary>
    /// <seealso cref="Elements.Clothings.ClothingEntity" />
    [Serializable]
    public class Top : ClothingEntity
    {
        /// <summary>
        /// Set Top with 0 Elemental Defence and 0 Elemental Buff
        /// </summary>
        public Top(): base() { }

        /// <summary>
        /// Set Top
        /// </summary>
        /// <param name="_defence">Top Elemental Defence</param>
        /// <param name="_buff">Top Elemental Buff</param>
        public Top(ElementalMix[] _defence, ElementalMix _buff) : base(_defence, _buff) { }

        /// <summary>
        /// Type of Clothing
        /// </summary>
        public override ClothingType Type { get { return ClothingType.TOP; } }
    }
}
