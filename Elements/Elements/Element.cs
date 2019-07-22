using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    /// <summary>
    /// This class helps to define new Element Mixes
    /// </summary>
    [System.Serializable]
    public class ElementalMix
    {
        /// <summary>Element Type. See <see cref="EElementalTypes"/></summary>
        public EElementalTypes ElementalType { get; private set; }
        /// <summary>Element Multiplier</summary>
        public float Percentage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementalMix"/> class.
        /// </summary>
        /// <param name="_elementalType">Type of the element</param>
        /// <param name="_percentage">Multiplier</param>
        public ElementalMix(EElementalTypes _elementalType, float _percentage)
        {
            ElementalType = _elementalType;
            Percentage = _percentage;
        }

        /// <summary>
        /// Return an empty <see cref="ElementalMix"/> Array
        /// </summary>
        /// <returns><see cref="ElementalMix"/> with type NONE and 0 multiplier</returns>
        public static ElementalMix[] Zero()
        {
            ElementalMix[] toReturn = new ElementalMix[1];
            toReturn[0] = new ElementalMix(EElementalTypes.NONE, 0f);
            return toReturn;
        }

        /// <summary>
        /// Return an empty <see cref="ElementalMix"/>
        /// </summary>
        /// <returns><see cref="ElementalMix"/> with type NONE and 0 multiplier</returns>
        public static ElementalMix ZeroOne() { return new ElementalMix(EElementalTypes.NONE, 0f); }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            ElementalMix other = (ElementalMix)obj;

            if (this.ElementalType != other.ElementalType) return false;
            if (this.Percentage != other.Percentage) return false;

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 1469661199;
            hashCode = hashCode * -1521134295 + ElementalType.GetHashCode();
            hashCode = hashCode * -1521134295 + Percentage.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return ElementalType + " " + Percentage;
        }
    }

    /// <summary>Element Types</summary>
    public enum EElementalTypes
    {
        NONE,
        NORMAL,
        FIRE,
        WATER,
        ICE,
        ELECTRICITY,
        GROUND,
        STONE
    }


}
