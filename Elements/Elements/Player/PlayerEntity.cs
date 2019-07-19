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
        public float CurrentHealth { get; protected set; }
        public virtual DamageMix Weapon { get; protected set; }
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

                return toReturn;

            }
        }


        public float TakeDamage(DamageMix _damage)
        {
            float totalDamage = 0;
            float tmpDamage;
            Dictionary<EElementalTypes, float> tmpTotalRes = TotalResistance;

            float damageDealt = _damage.Damage;

            foreach (KeyValuePair<EElementalTypes, float> kv in _damage.ElementMix)
            {
                tmpDamage = kv.Value * damageDealt;
                if (tmpTotalRes.ContainsKey(kv.Key))
                    tmpDamage *= (1 - tmpTotalRes[kv.Key]);
                totalDamage += tmpDamage;
            }
            CurrentHealth -= totalDamage;
            return totalDamage;
        }

    }

    public enum PlayerType
    {
        PLAYER,
        ENEMY
    }
}
