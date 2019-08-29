using System.Collections;
using System.Collections.Generic;
using Elements.Player;
using UnityEngine;

public class Bush : MainEntity
{
    public override string Name => "Bush";

    public override Enemy Enemy { get; protected set; }

    public override void DoTurn()
    {
        throw new System.NotImplementedException();
    }

    public override Enemy Init(float _minDamage, float _maxDamage, string _name, float _health)
    {
        return InitBasic(_minDamage, _maxDamage, _name, _health);
    }

    public override void Awake()
    {
        base.Awake();

        Enemy = Init(2, 5, Name, 50);
        Enemy.Gear.AddElementDefence(out Elements.ElementalMix[] noAdd,
            new Elements.ElementalMix(Elements.EElementalTypes.FIRE, -2),
            new Elements.ElementalMix(Elements.EElementalTypes.ICE, -0.5f),
            new Elements.ElementalMix(Elements.EElementalTypes.WIND, -0.5f),
            new Elements.ElementalMix(Elements.EElementalTypes.ELECTRICITY, 0.2f),
            new Elements.ElementalMix(Elements.EElementalTypes.STONE, -0.5f)
            );

        if (noAdd.Length != 0) Debug.LogWarning(noAdd.Length + " Elements could not be added to " + Name);

    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
}
