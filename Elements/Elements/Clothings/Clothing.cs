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
        public abstract ClothingType Type { get; }
        public virtual Element ElementDefence { get; protected set; }
    }

    public enum ClothingType
    {
        TOP,
        SHIRT,
        PANTS
    }
}
