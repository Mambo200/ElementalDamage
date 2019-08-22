using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Elements;

/// <summary>
/// Gives a Weapon. Max Level is 5.
/// </summary>
public static class PlayerWeapon
{
    // Min Damage
    // Max Damage
    // Buffs
    // Resistance

    /// <summary>
    /// Firebringer. Buff: Fire,1 | Resistance: Fire,0.2*level ||| Water,0.1*level ||| Ice,-0.2
    /// </summary>
    /// <param name="_level">Level of Item</param>
    /// <returns></returns>
    public static Weapon FireBringer(int _level)
    {
        LevelCheck(ref _level);

        // Min Damage
        float minD = (5f * 4f + _level) * (Mathf.Pow(_level, _level * 0.3f));
        // Max Damage
        float maxD = (5f * 4f + _level) * (Mathf.Pow(_level * 1.2f, _level * 0.32f));
        // Buffs
        ElementalMix[] buff = new ElementalMix[]
        {
            new ElementalMix(EElementalTypes.FIRE, 1)
        };
        // Resistance
        ElementalMix[] resistance = new ElementalMix[]
        {
            new ElementalMix(EElementalTypes.FIRE,  0.2f * _level),
            new ElementalMix(EElementalTypes.WATER, 0.1f * _level),
            new ElementalMix(EElementalTypes.ICE,  -0.2f)
        };

        return new Weapon(minD, maxD, buff, resistance);
    }

    /// <summary>
    /// Icicles. Buff: Ice,1 | Resistance: Ice,0.2*level ||| Water,0.1*level ||| Fire,-0.2
    /// </summary>
    /// <param name="_level">Level of Item</param>
    /// <returns></returns>
    public static Weapon Icicle(int _level)
    {
        LevelCheck(ref _level);

        // Min Damage
        float minD = (5f * 4 + _level) * (Mathf.Pow(_level, _level * 0.3f));
        // Max Damage
        float maxD = (5f * 5 + _level) * (Mathf.Pow(_level * 1.1f, _level * 0.33f));
        // Buffs
        ElementalMix[] buff = new ElementalMix[]
        {
            new ElementalMix(EElementalTypes.ICE, 1f)
        };
        // Resistance
        ElementalMix[] res = new ElementalMix[]
        {
            new ElementalMix(EElementalTypes.ICE,    0.2f *_level),
            new ElementalMix(EElementalTypes.WATER,  0.1f *_level),
            new ElementalMix(EElementalTypes.FIRE,  -0.2f)
        };

        return new Weapon(minD, maxD, buff, res);
    }

    /// <summary>
    /// Axe Weapon. Buff: Normal,1 | Resistance: Stone,0.1*level ||| Wind,0.2f*(_level-1) ||| Fire,-0.2 ||| Ice,-0.2
    /// </summary>
    /// <param name="_level">Level of Item</param>
    /// <returns></returns>
    public static Weapon Axe(int _level)
    {
        LevelCheck(ref _level);

        // Min Damage
        float minD = (6f * 5f + _level + _level) * (Mathf.Pow(_level, _level * 0.4f));
        // Max Damage
        float maxD = (6f * 6f + _level) * (Mathf.Pow(_level * 1.1f, _level * 0.44f));
        // Buffs
        ElementalMix[] buff = new ElementalMix[]
        {
            new ElementalMix(EElementalTypes.NORMAL, 1f)
        };
        // Resistance
        ElementalMix[] res = new ElementalMix[]
        {
            new ElementalMix(EElementalTypes.STONE,  0.1f *_level),
            new ElementalMix(EElementalTypes.WIND,  0.2f * (_level - 1)),
            new ElementalMix(EElementalTypes.FIRE,  -0.2f),
            new ElementalMix(EElementalTypes.ICE,   -0.2f)
        };

        return new Weapon(minD, maxD, buff, res);
    }

    /// <summary>
    /// check the Level and fix it
    /// </summary>
    /// <param name="_level">The level.</param>
    private static void LevelCheck(ref int _level)
    {
        if (_level < 1)
        {
            Debug.LogWarning("Level is " + _level + ". It will be set to 1.");
            _level = 1;
        }
        else if (_level > 5)
        {
            Debug.LogWarning("Level is " + _level + ". It will be set to 5.");
            _level = 5;
        }
    }
}

public static class EnemyWeapon
{
    /// <summary>
    /// Axe Weapon. Buff: Normal,1 | Resistance: Stone,0.1*level ||| Wind,0.2f*(_level-1) ||| Fire,-0.2 ||| Ice,-0.2
    /// </summary>
    /// <param name="_level">Level of Item</param>
    /// <returns></returns>
    public static Weapon Axe(int _level)
    {
        LevelCheck(ref _level);

        // Min Damage
        float minD = (6f * 5f + _level + _level) * (Mathf.Pow(_level, _level * 0.4f));
        // Max Damage
        float maxD = (6f * 6f + _level) * (Mathf.Pow(_level * 1.1f, _level * 0.44f));
        // Buffs
        ElementalMix[] buff = new ElementalMix[]
        {
            new ElementalMix(EElementalTypes.NORMAL, 1f)
        };
        // Resistance
        ElementalMix[] res = new ElementalMix[]
        {
            new ElementalMix(EElementalTypes.STONE,  0.1f *_level),
            new ElementalMix(EElementalTypes.WIND,  0.2f * (_level - 1)),
            new ElementalMix(EElementalTypes.FIRE,  -0.2f),
            new ElementalMix(EElementalTypes.ICE,   -0.2f)
        };

        return new Weapon(minD, maxD, buff, res);
    }

    /// <summary>
    /// check the Level and fix it
    /// </summary>
    /// <param name="_level">The level.</param>
    private static void LevelCheck(ref int _level)
    {
        if (_level < 1)
        {
            Debug.LogWarning("Level is " + _level + ". It will be set to 1.");
            _level = 1;
        }
        else if (_level > 5)
        {
            Debug.LogWarning("Level is " + _level + ". It will be set to 5.");
            _level = 5;
        }
    }

}
