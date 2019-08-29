using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Elements.Clothings;
using Elements.Player;

public class Slime : MainEntity
{
    public override string Name => "Slime";

    public override Enemy Enemy { get; protected set; }

    public override void Awake()
    {
        base.Awake();
        Enemy = Init(2, 5, Name, 100);
        Enemy.Gear.AddElementDefence(out Elements.ElementalMix[] noAdd,
            new Elements.ElementalMix(Elements.EElementalTypes.FIRE, 0.5f),
            new Elements.ElementalMix(Elements.EElementalTypes.ICE, -1f),
            new Elements.ElementalMix(Elements.EElementalTypes.STONE, -0.5f)    
            );
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        Debug.Log(m_Arrow, m_Arrow.gameObject);
    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override void DoTurn()
    {
        throw new System.NotImplementedException("No Turn Content");
    }

    public override Enemy Init(float _minDamage, float _maxDamage, string _name, float _health)
    {
        Top t = new Top();
        Shirt s = new Shirt();
        Pants p = new Pants();

        Elements.Weapon weapon = new Elements.Weapon(_minDamage, _maxDamage, Elements.ElementalMix.Zero(), Elements.ElementalMix.ZeroOne());
        return new Elements.Player.Enemy(_name, _health, _health, new Gear(t, s, p), weapon);

    }
}
