using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    /// <summary>
    /// Weapon Class
    /// </summary>
    [System.Serializable]
    public class Weapon
    {
        private static Random r = new Random();
        /// <summary>Calculates the Damage at random</summary>
        public float Damage
        {
            get
            {
                int tempMin = (int)(MinDamage * 1000);
                int tempMax = (int)(MaxDamage * 1000);

                int newValue = r.Next(tempMin, tempMax + 1);

                return newValue / 1000f;
            }
        }

        /// <summary>Element Resistance</summary>
        public Dictionary<EElementalTypes, float> Resistance { get; private set; }
        /// <summary>Element Boost</summary>
        public Dictionary<EElementalTypes, float> DamageBoost { get; private set; }

        /// <summary>Minimum Damage the weapon can deal (if enemy has no resistance)</summary>
        public virtual float MinDamage { get; protected set; }
        /// <summary>Maximum Damage the weapon can deal (if enemy has no weaknesses)</summary>
        public virtual float MaxDamage { get; protected set; }
        /// <summary>Average Damage of weapon</summary>
        public float MidPoint { get { return (MinDamage + MaxDamage) / 2; } }

        /// <summary>
        /// Creates a weapon
        /// </summary>
        /// <param name="_minDamage">min damage of weapon</param>
        /// <param name="_maxDamage">max damage of weapon</param>
        /// <param name="_buffs">Element buff (null = no buff)</param>
        /// <param name="_resistances">Element resistance (null = no reststance)</param>
        public Weapon(float _minDamage, float _maxDamage, ElementalMix[] _buffs, params ElementalMix[] _resistances)
        {
            MinDamage = _minDamage;
            MaxDamage = _maxDamage;
            Resistance = new Dictionary<EElementalTypes, float>();
            DamageBoost = new Dictionary<EElementalTypes, float>();


            // add Restsiance
            //if (_resistances != null)
            //{
            //    float maxValue = 0;
            //    foreach (ElementalMix mix in _resistances)
            //    {
            //        maxValue += mix.Percentage;
            //    }
            //    if (_resistances.Length == 0)
            //        maxValue = 1;
            //    foreach (ElementalMix mix in _resistances)
            //    {
            //        if (!Resistance.ContainsKey(mix.ElementalType))
            //            Resistance.Add(mix.ElementalType, mix.Percentage / maxValue);
            //    }
            //}

            foreach (ElementalMix mix in _resistances)
            {
                if (!Resistance.ContainsKey(mix.ElementalType))
                    Resistance.Add(mix.ElementalType, mix.Percentage);
            }



            // add Boost
            if (_buffs != null)
            {
                if (_buffs.Length <= 0)
                    _buffs = new ElementalMix[] { new ElementalMix(EElementalTypes.NONE, 1) };

                float maxValue = 0;
                foreach (ElementalMix mix in _buffs)
                {
                    maxValue += mix.Percentage;
                }
                if (_resistances.Length == 0)
                    maxValue = 1;
                foreach (ElementalMix mix in _buffs)
                {
                    if (!DamageBoost.ContainsKey(mix.ElementalType))
                        DamageBoost.Add(mix.ElementalType, mix.Percentage / maxValue);
                }
            }
            else
                DamageBoost.Add(EElementalTypes.NONE, 1);

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;

            Weapon other = (Weapon)obj;

            if (other.MinDamage != MinDamage) return false;
            if (other.MaxDamage != MaxDamage) return false;

            #region Dictionary Check Boost
            // check attack
            foreach (KeyValuePair<EElementalTypes, float> kv1 in this.DamageBoost)
            {
                bool check = false;

                foreach (KeyValuePair<EElementalTypes, float> kv2 in other.DamageBoost)
                {
                    if (kv1.Key == kv2.Key)
                    {
                        if (kv1.Value == kv2.Value)
                        {
                            check = true;
                            break;
                        }
                    }
                }

                if (check == false) return false;
            }
            #endregion

            #region Dictionary Check Resistance
            // check defence
            foreach (KeyValuePair<EElementalTypes, float> kv1 in this.Resistance)
            {
                bool check = false;

                foreach (KeyValuePair<EElementalTypes, float> kv2 in other.Resistance)
                {
                    if (kv1.Key == kv2.Key)
                    {
                        if (kv1.Value == kv2.Value)
                        {
                            check = true;
                            break;
                        }
                    }
                }

                if (check == false) return false;
            }
            #endregion

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = -279209218;
            hashCode = hashCode * -1521134295 + Damage.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<EElementalTypes, float>>.Default.GetHashCode(Resistance);
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<EElementalTypes, float>>.Default.GetHashCode(DamageBoost);
            hashCode = hashCode * -1521134295 + MinDamage.GetHashCode();
            hashCode = hashCode * -1521134295 + MaxDamage.GetHashCode();
            hashCode = hashCode * -1521134295 + MidPoint.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
