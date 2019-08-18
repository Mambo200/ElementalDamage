using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Elements.Clothings;

public abstract class MainEntity : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract Elements.Player.Enemy Enemy { get; protected set; }

    public virtual void Awake()
    {

    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        Enemy.ChangeDescription("ERROR");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public static Elements.Player.Enemy InitBasic(float _minDamage, float _maxDamage, string _name, float _health)
    {
        Top t = new Top();
        Shirt s = new Shirt();
        Pants p = new Pants();

        Elements.Weapon weapon = new Elements.Weapon(_minDamage, _maxDamage, Elements.ElementalMix.Zero(), Elements.ElementalMix.ZeroOne());
        return new Elements.Player.Enemy(_name, _health, _health, new Gear(t, s, p), weapon);
    }

    public abstract Elements.Player.Enemy Init(float _minDamage, float _maxDamage, string _name, float _health);

    public abstract void DoTurn();

}
