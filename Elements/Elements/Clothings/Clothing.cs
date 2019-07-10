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
    public abstract class ClothingEntity : Element.ElementDictionary 
    {
        public abstract ClothingType Type { get; }
        public virtual ElementMix ElementDefence { get; protected set; }
        public Dictionary<EElement, float> Resistance { get { return ElementValues; } }
    }

    public enum ClothingType
    {
        TOP,
        SHIRT,
        PANTS
    }
}
