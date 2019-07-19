using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public class ElementalMix
    {
        public EElementalTypes ElementalType { get; private set; }
        public float Percentage { get; private set; }

        public ElementalMix(EElementalTypes _elementalType, float _percentage)
        {
            ElementalType = _elementalType;
            Percentage = _percentage;
        }

        public static ElementalMix[] Zero()
        {
            ElementalMix[] toReturn = new ElementalMix[1];
            toReturn[0] = new ElementalMix(EElementalTypes.NONE, 0f);
            return toReturn;
        }

        public static ElementalMix ZeroOne() { return new ElementalMix(EElementalTypes.NONE, 0f); }
    }


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
