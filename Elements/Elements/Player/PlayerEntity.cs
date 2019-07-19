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
        public abstract PlayerType PlayerType { get; }
        public virtual float MaxHealth { get; protected set; }
        public float CurrentHealth { get; protected set; }
        public abstract Weapon Weapon { get; protected set; }
        public abstract Gear Gear { get; protected set; }
        public PlayerEntity GetEntity { get { return this; } }

        public Dictionary<EElement, float> GetAllElementBuff()
        {
            Dictionary<EElement, float> toResturn = new Dictionary<EElement, float>();

            // Weapon Resistance
            foreach (KeyValuePair<EElement, float> keyValue in Weapon.ElementValueAttack)
            {
                if (toResturn.ContainsKey(keyValue.Key)) toResturn[keyValue.Key] += keyValue.Value;
                else toResturn.Add(keyValue.Key, keyValue.Value);
            }

            // Gear
            // Top
            foreach (KeyValuePair<EElement, float> keyValue in Gear.Top.ElementValueAttack)
            {
                if (toResturn.ContainsKey(keyValue.Key)) toResturn[keyValue.Key] += keyValue.Value;
                else toResturn.Add(keyValue.Key, keyValue.Value);
            }

            // Shirt
            foreach (KeyValuePair<EElement, float> keyValue in Gear.Shirt.ElementValueAttack)
            {
                if (toResturn.ContainsKey(keyValue.Key)) toResturn[keyValue.Key] += keyValue.Value;
                else toResturn.Add(keyValue.Key, keyValue.Value);
            }

            // Pants
            foreach (KeyValuePair<EElement, float> keyValue in Gear.Pants.ElementValueAttack)
            {
                if (toResturn.ContainsKey(keyValue.Key)) toResturn[keyValue.Key] += keyValue.Value;
                else toResturn.Add(keyValue.Key, keyValue.Value);
            }

            return toResturn;
        }
        public ElementMix GetResistance(EElement _elementToLook)
        {
            float multiplier = 0;

            // Weapon Resistance
            foreach (KeyValuePair<EElement, float> keyValue in Weapon.ElementValueDefence)
            {
                if (keyValue.Key == _elementToLook)
                {
                    multiplier += keyValue.Value;
                    break;
                }
            }

            // Gear
            // Top
            foreach (KeyValuePair<EElement, float> keyValue in Gear.Top.ElementValueDefence)
            {
                if (keyValue.Key == _elementToLook)
                {
                    multiplier += keyValue.Value;
                    break;
                }
            }

            // Shirt
            foreach (KeyValuePair<EElement, float> keyValue in Gear.Shirt.ElementValueDefence)
            {
                if (keyValue.Key == _elementToLook)
                {
                    multiplier += keyValue.Value;
                    break;
                }
            }

            // Pants
            foreach (KeyValuePair<EElement, float> keyValue in Gear.Pants.ElementValueDefence)
            {
                if (keyValue.Key == _elementToLook)
                {
                    multiplier += keyValue.Value;
                    break;
                }
            }

            return new ElementMix(_elementToLook, multiplier);

        }
        public Dictionary<EElement, float> GetAllResistances()
        {
            Dictionary<EElement, float> toResturn = new Dictionary<EElement, float>();

            // Weapon Resistance
            foreach (KeyValuePair<EElement, float> keyValue in Weapon.ElementValueDefence)
            {
                if (toResturn.ContainsKey(keyValue.Key)) toResturn[keyValue.Key] += keyValue.Value;
                else toResturn.Add(keyValue.Key, keyValue.Value);
            }

            // Gear
            // Top
            foreach (KeyValuePair<EElement, float> keyValue in Gear.Top.ElementValueDefence)
            {
                if (toResturn.ContainsKey(keyValue.Key)) toResturn[keyValue.Key] += keyValue.Value;
                else toResturn.Add(keyValue.Key, keyValue.Value);
            }

            // Shirt
            foreach (KeyValuePair<EElement, float> keyValue in Gear.Shirt.ElementValueDefence)
            {
                if (toResturn.ContainsKey(keyValue.Key)) toResturn[keyValue.Key] += keyValue.Value;
                else toResturn.Add(keyValue.Key, keyValue.Value);
            }

            // Pants
            foreach (KeyValuePair<EElement, float> keyValue in Gear.Pants.ElementValueDefence)
            {
                if (toResturn.ContainsKey(keyValue.Key)) toResturn[keyValue.Key] += keyValue.Value;
                else toResturn.Add(keyValue.Key, keyValue.Value);
            }

            return toResturn;
        }
    }

    public enum PlayerType
    {
        PLAYER,
        ENEMY
    }
}
