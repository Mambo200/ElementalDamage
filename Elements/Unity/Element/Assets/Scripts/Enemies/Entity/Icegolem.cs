using System.Collections;
using System.Collections.Generic;
using Elements.Player;
using UnityEngine;

public class Icegolem : MainEntity
{
    public override string Name => "Icegolem";

    public override Enemy Enemy { get; protected set; }

    public override void DoTurn()
    {
        throw new System.NotImplementedException();
    }

    public override void Awake()
    {
        base.Awake();
        Enemy = Init(10, 30, Name, 200);
    }

    public override Enemy Init(float _minDamage, float _maxDamage, string _name, float _health)
    {
        Enemy = MainEntity.InitBasic(_minDamage, _maxDamage, _name, _health);

        Elements.ElementalMix[] defence = new Elements.ElementalMix[]
        {
             new Elements.ElementalMix(Elements.EElementalTypes.STONE, -0.5f),
             new Elements.ElementalMix(Elements.EElementalTypes.WIND, -1f),
             new Elements.ElementalMix(Elements.EElementalTypes.ICE, -0.5f),
             new Elements.ElementalMix(Elements.EElementalTypes.WATER, -2f),
             new Elements.ElementalMix(Elements.EElementalTypes.FIRE, -2),
        };

        bool work = Enemy.Gear.AddElementDefence(out Elements.ElementalMix[] noAdd, defence);

        return Enemy;

    }

    // Start is called before the first frame update
    public override void Start()
    {
    }

    // Update is called once per frame
    public override void Update()
    {

    }
}
