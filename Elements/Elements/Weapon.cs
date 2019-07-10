using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public class Weapon : Element.ElementDictionary
    {
        private static Random r = new Random();
        private Dictionary<EElement, float> elementalDefence = new Dictionary<EElement, float>();
        public Weapon()
        {
            AddElement(ElementMix.RandomElement());

            ElementMix temp = ElementMix.RandomElement();
            ElementalDefence.Add(temp.Element, temp.Multiplier);
        }

        public Weapon(float _minDamage, float _maxDamage, ElementMix _eDamage, params ElementMix[] _eDefenses)
        {
            AddElement(_eDamage);
            for (int i = 0; i < _eDefenses.Length; i++) ElementalDefence.Add(_eDefenses[i].Element, _eDefenses[i].Multiplier);
            MinDamage = _minDamage;
            MaxDamage = _maxDamage;
        }

        public virtual Dictionary<EElement, float> ElementalDamage { get { return ElementValues; } }
        public virtual Dictionary<EElement, float> ElementalDefence { get { return elementalDefence; } }
        public virtual float MinDamage { get; protected set; }
        public virtual float MaxDamage { get; protected set; }
        public float MidPoint { get { return (MinDamage + MaxDamage) / 2; } }

        public void SetMaxDamage(float _newMaxDamage) => MaxDamage = _newMaxDamage;
        public void SetMinDamage(float _newMinDamage) => MinDamage = _newMinDamage;
        public float CalculateDamage()
        {
            int tempMin = (int)(MinDamage * 10000);
            int tempMax = (int)(MaxDamage * 10000);
            int toFloat = r.Next(tempMin, tempMax);
            return (float)toFloat / 10000f;
        }
        
    }
}
