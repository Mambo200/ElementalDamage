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

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            ElementalMix other = (ElementalMix)obj;

            if (this.ElementalType != other.ElementalType) return false;
            if (this.Percentage != other.Percentage) return false;

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var hashCode = 1469661199;
            hashCode = hashCode * -1521134295 + ElementalType.GetHashCode();
            hashCode = hashCode * -1521134295 + Percentage.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return ElementalType + " " + Percentage;
        }

        /// <summary>
        /// Changes the percentage
        /// </summary>
        /// <param name="_multiplier">new multiplier Value</param>
        public void ChangePercentage(float _multiplier) => Percentage = _multiplier;

        /// <summary>
        /// Check if Elementalmix contains a specific elemental typa
        /// </summary>
        /// <param name="_type">Type</param>
        /// <param name="_toCheck">Array to check</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool Contains(EElementalTypes _type, params ElementalMix[] _toCheck)
        {
            foreach (ElementalMix type in _toCheck)
            {
                if (type.ElementalType == _type) return true;
            }

            return false;
        }
    }

    /// <summary>Element Types</summary>
    [Serializable]
    public enum EElementalTypes
    {
        /// <summary>No Element</summary>
        NONE,
        /// <summary>No Elemental Damage</summary>
        NORMAL,
        /// <summary>Fire Element</summary>
        FIRE,
        /// <summary>Water Element</summary>
        WATER,
        /// <summary>Ice Element</summary>
        ICE,
        /// <summary>Electric Element</summary>
        ELECTRICITY,
        /// <summary>Ground Element</summary>
        GROUND,
        /// <summary>Stone Element</summary>
        STONE
    }


}
