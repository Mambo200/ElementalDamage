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
        /// <summary>
        /// Creates a Weapon with no defence element and damage from 10 to 100
        /// </summary>
        public Weapon()
        {
            MinDamage = 10;
            MaxDamage = 100;
        }

        /// <summary>
        /// Creates a weapon
        /// </summary>
        /// <param name="_minDamage">min damage of weapon</param>
        /// <param name="_maxDamage">max damage of weapon</param>
        /// <param name="_eDamage">elemental attack</param>
        /// <param name="_eDefenses">elemental defence</param>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public Weapon(float _minDamage, float _maxDamage, ElementMix _eDamage, params ElementMix[] _eDefenses)
        {
            if (_maxDamage < _minDamage) throw new ArgumentOutOfRangeException();
            AddElementAttack(_eDamage);
            for (int i = 0; i < _eDefenses.Length; i++) ElementValueDefence.Add(_eDefenses[i].Element, _eDefenses[i].Multiplier);
            MinDamage = _minDamage;
            MaxDamage = _maxDamage;
        }

        /// <summary>
        /// Creates a weapon
        /// </summary>
        /// <param name="_minDamage">min damage of weapon</param>
        /// <param name="_maxDamage">max damage of weapon</param>
        /// <param name="_eDamage">elemental attack</param>
        /// <param name="_eDefenses">elemental defence</param>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public Weapon(float _minDamage, float _maxDamage, ElementMix _eDamage, Dictionary<EElement, float> _eDefenses)
        {
            if (_maxDamage < _minDamage) throw new ArgumentOutOfRangeException();
            AddElementAttack(_eDamage);
            foreach (KeyValuePair<EElement, float> kv in _eDefenses) ElementValueDefence.Add(kv.Key, kv.Value);
            MinDamage = _minDamage;
            MaxDamage = _maxDamage;
        }

        public virtual float MinDamage { get; protected set; }
        public virtual float MaxDamage { get; protected set; }
        public float MidPoint { get { return (MinDamage + MaxDamage) / 2; } }

        /// <summary>Set Max Damage of weapon</summary>
        /// <param name="_newMaxDamage">new max value</param>
        public void SetMaxDamage(float _newMaxDamage) => MaxDamage = _newMaxDamage;
        /// <summary>Set Min Damage of weapon</summary>
        /// <param name="_newMinDamage">new min value</param>
        public void SetMinDamage(float _newMinDamage) => MinDamage = _newMinDamage;
        /// <summary>
        /// Calculate normal Damage
        /// </summary>
        /// <returns>Damage (without enemy Defence)</returns>
        public float CalculateDamage()
        {
            int tempMin = (int)(MinDamage * 10000);
            int tempMax = (int)(MaxDamage * 10000);
            int toFloat = r.Next(tempMin, tempMax);
            return (float)toFloat / 10000f;
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;

            Weapon other = (Weapon)obj;

            // check damage
            if (this.MinDamage != other.MinDamage ||
                this.MaxDamage != other.MaxDamage)
                return false;

            // if elementattack- and elementdefence count is not equal return false
            if (((this.ElementValueAttack.Count != other.ElementValueAttack.Count)) ||
                ((this.ElementValueDefence.Count != other.ElementValueAttack.Count)))
                return false;

            // check attack
            foreach (KeyValuePair<EElement, float> kv1 in this.ElementValueAttack)
            {
                bool check = false;

                foreach (KeyValuePair<EElement, float> kv2 in other.ElementValueAttack)
                {
                    if(kv1.Key == kv2.Key)
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

            // check defence
            foreach (KeyValuePair<EElement, float> kv1 in this.ElementValueDefence)
            {
                bool check = false;

                foreach (KeyValuePair<EElement, float> kv2 in other.ElementValueDefence)
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


            return true;
        }
    }
}
