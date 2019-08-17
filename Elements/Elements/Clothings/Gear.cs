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

        /// <summary>
        /// Adds element from defence
        /// </summary>
        /// <param name="_notAddable">These elements could not be added because all gears already have this elemental defence in some kind. Lengh is 0 if all items could be added.</param>
        /// <param name="_elements">Elements to add</param>
        /// <returns>true if all Items could be added. false if one or more items failed to add</returns>
        public bool AddElementDefence(out ElementalMix[] _notAddable, params ElementalMix[] _elements)
        {
            List<ElementalMix> noAddable = new List<ElementalMix>();

            foreach (ElementalMix mix in _elements)
            {
                //top
                if (!Top.ElementDefence.Contains(mix))
                {
                    ElementalMix[] newDef = new ElementalMix[Top.ElementDefence.Length + 1];
                    for (int i = 0; i < Top.ElementDefence.Length; i++)
                    {
                        newDef[i] = Top.ElementDefence[i];
                    }
                    newDef[newDef.Length - 1] = mix;
                    Top.SetElementDefence(newDef);
                    continue;
                }

                // Shirt
                if (!Shirt.ElementDefence.Contains(mix))
                {
                    ElementalMix[] newDef = new ElementalMix[Shirt.ElementDefence.Length + 1];
                    for (int i = 0; i < Shirt.ElementDefence.Length; i++)
                    {
                        newDef[i] = Shirt.ElementDefence[i];
                    }
                    newDef[newDef.Length - 1] = mix;
                    Shirt.SetElementDefence(newDef);
                    continue;
                }

                // Pants
                if (!Pants.ElementDefence.Contains(mix))
                {
                    ElementalMix[] newDef = new ElementalMix[Pants.ElementDefence.Length + 1];
                    for (int i = 0; i < Pants.ElementDefence.Length; i++)
                    {
                        newDef[i] = Pants.ElementDefence[i];
                    }
                    newDef[newDef.Length - 1] = mix;
                    Pants.SetElementDefence(newDef);
                    continue;
                }

                // mix could not be added
                noAddable.Add(mix);
            }

            _notAddable = noAddable.ToArray();

            if (noAddable.Count < 1) return true;
            else return false;

        }

        /// <summary>
        /// Removes element from defence
        /// </summary>
        /// <param name="_notRemoveable">The not removeable.</param>
        /// <param name="_elements">The elements.</param>
        /// <returns></returns>
        public bool RemoveElementDefence(out EElementalTypes[] _notRemoveable, params EElementalTypes[] _elements)
        {
            List<EElementalTypes> noAddable = new List<EElementalTypes>();

            foreach (EElementalTypes eType in _elements)
            {
                //top
                if (ElementalMix.Contains(eType, Top.ElementDefence))
                {
                    int index = 0;
                    ElementalMix[] newDef = new ElementalMix[Top.ElementDefence.Length - 1];
                    foreach (ElementalMix item in Top.ElementDefence)
                    {
                        if (item.ElementalType != eType)
                        {
                            newDef[index] = item;
                            index++;
                        }
                    }
                    Top.SetElementDefence(newDef);
                    continue;
                }

                // Shirt
                if (ElementalMix.Contains(eType, Shirt.ElementDefence))
                {
                    int index = 0;
                    ElementalMix[] newDef = new ElementalMix[Shirt.ElementDefence.Length - 1];
                    foreach (ElementalMix item in Shirt.ElementDefence)
                    {
                        if (item.ElementalType != eType)
                        {
                            newDef[index] = item;
                            index++;
                        }
                    }
                    Shirt.SetElementDefence(newDef);
                    continue;
                }

                // Pants
                if (ElementalMix.Contains(eType, Pants.ElementDefence))
                {
                    int index = 0;
                    ElementalMix[] newDef = new ElementalMix[Pants.ElementDefence.Length - 1];
                    foreach (ElementalMix item in Pants.ElementDefence)
                    {
                        if (item.ElementalType != eType)
                        {
                            newDef[index] = item;
                            index++;
                        }
                    }
                    Pants.SetElementDefence(newDef);
                    continue;

                }
                // mix could not be added
                noAddable.Add(eType);
            }

            _notRemoveable = noAddable.ToArray();

            if (noAddable.Count < 1) return true;
            else return false;

        }
    }
}
