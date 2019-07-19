using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    [System.Serializable]
    public class DamageMix
    {
        private static Random r = new Random();
        public float Damage
        {
            get
            {
                int tempMin = (int)(MinDamage * 1000);
                int tempMax = (int)(MaxDamage * 1000);

                int newValue = r.Next(tempMin, tempMax + 1);


                return (float)newValue / 1000f;
            }
        }

        public Dictionary<EElementalTypes, float> ElementMix { get; private set; }

        /// <summary>Minimum Damage the weapon can deal (if enemy has no resistance)</summary>
        public virtual float MinDamage { get; protected set; }
        /// <summary>Maximum Damage the weapon can deal (if enemy has no weaknesses)</summary>
        public virtual float MaxDamage { get; protected set; }
        /// <summary>Average Damage of weapon</summary>
        public float MidPoint { get { return (MinDamage + MaxDamage) / 2; } }

        public DamageMix(float _minDamage, float _maxDamage, params ElementalMix[] _mixes)
        {
            MinDamage = _minDamage;
            MaxDamage = _maxDamage;
            ElementMix = new Dictionary<EElementalTypes, float>();

            float maxValue = 0;
            foreach (ElementalMix mix in _mixes)
            {
                maxValue += mix.Percentage;
            }
            if (_mixes.Length == 0)
                maxValue = 1;
            foreach (ElementalMix mix in _mixes)
            {
                if (!ElementMix.ContainsKey(mix.ElementalType))
                    ElementMix.Add(mix.ElementalType, mix.Percentage / maxValue);
            }
        }

    }
}
