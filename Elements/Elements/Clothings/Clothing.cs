using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Clothings
{
    /// <summary>
    /// Main Class for Clothings (top, shirt, pants)
    /// </summary>
    public abstract class ClothingEntity
    {
        /// <summary>
        /// Type of Clothing
        /// </summary>
        public abstract ClothingType Type { get; }

        /// <summary>
        /// Elemental Defence of Clothing
        /// </summary>
        public virtual Element ElementDefence { get; protected set; }

        /// <summary>
        /// Elemental Buff of Clothing
        /// </summary>
        public virtual Element ElementBuff { get; protected set; }

        /// <summary>
        /// Set Elemental Defence
        /// </summary>
        /// <param name="_defence">new Elemental Defence</param>
        public void SetElementDefence(Element _defence) => ElementDefence = _defence;

        /// <summary>
        /// Set Elemental Buff
        /// </summary>
        /// <param name="_buff">new Elemental Buff</param>
        public void SetElementBuff(Element _buff) => ElementBuff = _buff;

        /// <summary>
        /// Set Elemental Buff and Defence
        /// </summary>
        /// <param name="_defence">new Elemental Defence</param>
        /// <param name="_buff">new Elemental Buff</param>
        public void SetElementBuffAndDefence(Element _defence, Element _buff)
        {
            SetElementBuff(_buff);
            SetElementDefence(_defence);
        }
    }

    /// <summary>
    /// Type of Clothing
    /// </summary>
    public enum ClothingType
    {
        TOP,
        SHIRT,
        PANTS
    }
}
