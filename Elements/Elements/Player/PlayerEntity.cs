using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements.Clothings;

namespace Elements.Player
{
    public abstract class PlayerEntity
    {
        public virtual string Name { get; protected set; }
        public abstract PlayerType PlayerType { get; }
        public virtual float MaxHealth { get; protected set; }
        private float currentHealth;
        public float CurrentHealth
        {
            get { return currentHealth; }

            set
            {
                if (value >= MaxHealth)
                    currentHealth = MaxHealth;
                else if (value <= 0)
                    currentHealth = 0;
                else
                    currentHealth = value;
            }
        }
        public virtual Weapon Weapon { get; protected set; }
        public virtual Gear Gear { get; protected set; }
        public PlayerEntity GetEntity { get { return this; } }

        public Dictionary<EElementalTypes, float> TotalResistance
        {
            get
            {
                Dictionary<EElementalTypes, float> toReturn = new Dictionary<EElementalTypes, float>();

                // Gear
                // Top
                foreach (ElementalMix kv in Gear.Top.ElementDefence)
                {
                    if (!toReturn.ContainsKey(kv.ElementalType))
                        toReturn.Add(kv.ElementalType, kv.Percentage);
                    else
                        toReturn[kv.ElementalType] += kv.Percentage;
                }

                // Shirt
                foreach (ElementalMix kv in Gear.Shirt.ElementDefence)
                {
                    if (!toReturn.ContainsKey(kv.ElementalType))
                        toReturn.Add(kv.ElementalType, kv.Percentage);
                    else
                        toReturn[kv.ElementalType] += kv.Percentage;
                }

                // Pants
                foreach (ElementalMix kv in Gear.Pants.ElementDefence)
                {
                    if (!toReturn.ContainsKey(kv.ElementalType))
                        toReturn.Add(kv.ElementalType, kv.Percentage);
                    else
                        toReturn[kv.ElementalType] += kv.Percentage;
                }

                // Weapon
                foreach (KeyValuePair<EElementalTypes, float> kv in Weapon.Resistance)
                {
                    if (!toReturn.ContainsKey(kv.Key))
                        toReturn.Add(kv.Key, kv.Value);
                    else
                        toReturn[kv.Key] += kv.Value;
                }

                return toReturn;

            }
        }

        /// <summary>
        /// Init Playerentity
        /// </summary>
        /// <param name="_name">name of Playerentity</param>
        /// <param name="_currentHP">current hp of Playerentity</param>
        /// <param name="_maxHP">max hp of Playerentity</param>
        /// <param name="_gear">Gear of Playerentity</param>
        /// <param name="_weapon">Weapon of Playerentity</param>
        protected void Init(string _name, float _currentHP, float _maxHP, Gear _gear, Weapon _weapon)
        {
            Name = _name;
            MaxHealth = _maxHP;
            CurrentHealth = _currentHP;
            Gear = _gear;
            Weapon = _weapon;
        }

        public float TakeDamage(Weapon _damage)
        {
            float totalDamage = 0;
            float tmpDamage;
            Dictionary<EElementalTypes, float> tmpTotalRes = TotalResistance;

            float damageDealt = _damage.Damage;

            foreach (KeyValuePair<EElementalTypes, float> kv in _damage.DamageBoost)
            {
                tmpDamage = kv.Value * damageDealt;
                if (tmpTotalRes.ContainsKey(kv.Key))
                    tmpDamage *= (1 - tmpTotalRes[kv.Key]);
                totalDamage += tmpDamage;
            }
            CurrentHealth -= totalDamage;
            return totalDamage;
        }

        public float TakeDamage(PlayerEntity _player) => TakeDamage(_player.Weapon);
    }


    public enum PlayerType
    {
        PLAYER,
        ENEMY
    }
}
