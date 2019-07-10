using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    /// <summary>
    /// Element Mix Class
    /// </summary>
    public struct ElementMix
    {
        private static Random r = new Random();
        public EElement Element { get; private set; }
        public float Multiplier { get; private set; }
        public int Percentage { get { return (int)(Multiplier * 100); } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementMix"/> struct. 1.0 = 100%, 0 = 0%
        /// </summary>
        /// <param name="_element">Element</param>
        /// <param name="_multiplier">Multiplier</param>
        public ElementMix(EElement _element, float _multiplier)
        {
            Element = _element;
            Multiplier = _element == EElement.NONE ? 0 : _multiplier;
        }

        /// <summary>
        /// Get a random Element with Element 0 to 1
        /// </summary>
        /// <returns>new random Element</returns>
        public static ElementMix RandomElement()
        {
            return new ElementMix((EElement)r.Next(0, (int)EElement.MAX), (float)Math.Round(r.NextDouble(), 2));
        }

        public override bool Equals(object obj)
        {
            // check type
            if (this.GetType() != obj.GetType()) return false;

            if (this.Element == ((ElementMix)obj).Element &&
                this.Multiplier == ((ElementMix)obj).Multiplier) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {

            return Element.ToString() + " " + Multiplier.ToString();
        }
    }

    /// <summary>
    /// Elements
    /// </summary>
    public enum EElement
    {
        /// <summary>No Element</summary>
        NONE,
        /// <summary>Fire Element</summary>
        FIRE,
        /// <summary>Thunder Element</summary>
        THUNDER,
        /// <summary>Ice Element</summary>
        ICE,
        /// <summary>Earth Element</summary>
        EARTH,
        /// <summary>Poision Element</summary>
        POISON,
        /// <summary>Bomb Element</summary>
        BOMB,
        /// <summary>Wind Element</summary>
        WIND,
        /// <summary>Water Element</summary>
        WATER,
        /// <summary>Holy Element</summary>
        HOLY,
        /// <summary>Dark Element</summary>
        DARK,
        /// <summary>DO NOT USE AS ELEMENTAL</summary>
        MAX
    }
}
