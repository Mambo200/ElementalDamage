using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements.Clothings;

namespace Elements.Player
{
    /// <summary>
    /// Player Entity for all Players
    /// </summary>
    public abstract class PlayerEntity
    {
        /// <summary>Name of Entity</summary>
        public virtual string Name { get; protected set; }
        /// <summary>Player Type. See <see cref="Elements.Player.PlayerType"/></summary>
        public abstract PlayerType PlayerType { get; }
        /// <summary>Max Health of Entity</summary>
        public virtual float MaxHealth { get; protected set; }
        /// <summary>Description of Enemy</summary>
        public virtual string Description { get; protected set; }
        /// <summary>Current Health. DO NOT USE!</summary>
        private float currentHealth;
        /// <summary>Current Health of Entity</summary>
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
        /// <summary>Weapon of Entity</summary>
        public virtual Weapon Weapon { get; protected set; }
        /// <summary>Complete Gear of Entity. See <see cref="Elements.Clothings.Pants"/>, <see cref="Elements.Clothings.Shirt"/> and <see cref="Elements.Clothings.Top"/>.</summary>
        public virtual Gear Gear { get; protected set; }
        /// <summary>Get Entity</summary>
        public PlayerEntity GetEntity { get { return this; } }

        /// <summary>Get total Resitiance of Entity</summary>
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

        /// <summary>
        /// Take damage. reduces <see cref="CurrentHealth"/>
        /// </summary>
        /// <param name="_damage">Weapon to deal damage with</param>
        /// <returns></returns>
        public float TakeDamage(Weapon _damage)
        {
            float totalDamage = 0;
            float tmpDamage;
            Dictionary<EElementalTypes, float> tmpTotalRes = TotalResistance;

            float damageDealt = _damage.Damage;

            foreach (KeyValuePair<EElementalTypes, float> kv in _damage.DamageBoost)
            {
                tmpDamage = kv.Value * damageDealt;
                if (kv.Key != EElementalTypes.NORMAL)
                    if (tmpTotalRes.ContainsKey(kv.Key))
                        tmpDamage *= (1 - tmpTotalRes[kv.Key]);
                totalDamage += tmpDamage;
            }
            CurrentHealth -= totalDamage;
            return totalDamage;
        }

        /// <summary>
        /// Take damage. reduces <see cref="CurrentHealth"/>
        /// </summary>
        /// <param name="_player">Entity who is attacking</param>
        /// <returns></returns>
        public float TakeDamage(PlayerEntity _player) => TakeDamage(_player.Weapon);

        /// <summary>
        /// Changes the name.
        /// </summary>
        /// <param name="_newName">The new name.</param>
        public void ChangeName(string _newName) => Name = _newName;
        /// <summary>
        /// Changes the maximum health.
        /// </summary>
        /// <param name="_newMaxHealth">The new maximum health.</param>
        public void ChangeMaxHealth(float _newMaxHealth) => MaxHealth = _newMaxHealth;
        /// <summary>
        /// Changes the current health.
        /// </summary>
        /// <param name="_newCurrentHealth">The new current health.</param>
        public void ChangeCurrentHealth(float _newCurrentHealth) => CurrentHealth = _newCurrentHealth;
        /// <summary>
        /// Changes the weapon.
        /// </summary>
        /// <param name="_newWeapon">The new weapon.</param>
        public void ChangeWeapon(Weapon _newWeapon) => Weapon = _newWeapon;
        /// <summary>
        /// Changes the gear.
        /// </summary>
        /// <param name="_newGear">The new gear.</param>
        public void ChangeGear(Gear _newGear) => Gear = _newGear;
        /// <summary>
        /// Changes the description.
        /// </summary>
        /// <param name="_newDescription">The new description.</param>
        public void ChangeDescription(string _newDescription) => Description = _newDescription;
    }

    /// <summary>
    /// Entity Type
    /// </summary>
    public enum PlayerType
    {
        /// <summary>Entity is Player</summary>
        PLAYER,
        /// <summary>Entity is Enemy</summary>
        ENEMY
    }
}
