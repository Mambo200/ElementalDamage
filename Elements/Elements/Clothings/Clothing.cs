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
    [Serializable]
    public abstract class ClothingEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClothingEntity"/> class.
        /// </summary>
        public ClothingEntity()
        {
            ElementBuff = ElementalMix.Zero()[0];
            ElementDefence = ElementalMix.Zero();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ClothingEntity"/> class.
        /// </summary>
        /// <param name="_defence">Defence Attribute</param>
        /// <param name="_buff">Buff Attribute</param>
        public ClothingEntity(ElementalMix[] _defence, ElementalMix _buff)
        {
            ElementDefence = _defence;
            ElementBuff = _buff;
        }
        /// <summary>
        /// Type of Clothing
        /// </summary>
        public abstract ClothingType Type { get; }

        /// <summary>
        /// Elemental Defence of Clothing
        /// </summary>
        public virtual ElementalMix[] ElementDefence { get; protected set; }

        /// <summary>
        /// Elemental Buff of Clothing
        /// </summary>
        public virtual ElementalMix ElementBuff { get; protected set; }

        /// <summary>
        /// Set Elemental Defence
        /// </summary>
        /// <param name="_defence">new Elemental Defence</param>
        public void SetElementDefence(ElementalMix[] _defence) => ElementDefence = _defence;

        /// <summary>
        /// Set Elemental Buff
        /// </summary>
        /// <param name="_buff">new Elemental Buff</param>
        public void SetElementBuff(ElementalMix _buff) => ElementBuff = _buff;

        /// <summary>
        /// Set Elemental Buff and Defence
        /// </summary>
        /// <param name="_defence">new Elemental Defence</param>
        /// <param name="_buff">new Elemental Buff</param>
        public void SetElementBuffAndDefence(ElementalMix[] _defence, ElementalMix _buff)
        {
            SetElementBuff(_buff);
            SetElementDefence(_defence);
        }
    }

    /// <summary>
    /// Type of Clothing
    /// </summary>
    [Serializable]
    public enum ClothingType
    {
        /// <summary>Head</summary>
        TOP,
        /// <summary>Shirt</summary>
        SHIRT,
        /// <summary>Pants</summary>
        PANTS
    }
}
