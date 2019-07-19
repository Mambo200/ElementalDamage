using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Clothings
{
    /// <summary>
    /// This class is specified to have only three clothings: one Top, one Shirt, one Pants
    /// </summary>
    public class Gear
    {
        /// <summary>
        /// Set Gear with 0 Elemental Defence and 0 Elemental Buff
        /// </summary>
        public Gear() { }

        /// <summary>
        /// Set Gear
        /// </summary>
        /// <param name="_top">Top Gear</param>
        /// <param name="_shirt">Shirt Gear</param>
        /// <param name="_pants">Pants Gear</param>
        public Gear(Top _top, Shirt _shirt, Pants _pants)
        {
            Top = _top;
            Shirt = _shirt;
            Pants = _pants;
        }

        /// <summary>Top Gear</summary>
        public Top Top = new Top(ElementalMix.Zero(), ElementalMix.ZeroOne());
        /// <summary>Shirt Gear</summary>
        public Shirt Shirt = new Shirt(ElementalMix.Zero(), ElementalMix.ZeroOne());
        /// <summary>Pants Gear</summary>
        public Pants Pants = new Pants(ElementalMix.Zero(), ElementalMix.ZeroOne());
    }
}
