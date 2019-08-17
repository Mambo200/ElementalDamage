using System.Collections;
using System.Collections.Generic;
using Elements.Player;
using UnityEngine;

public class Golem : MainEntity
{
    public override string Name => "Golem";

    public override Enemy Enemy { get ; protected set; }

    public override void DoTurn()
    {
        throw new System.NotImplementedException("No Turn Content");
    }

    // Start is called before the first frame update
    public override void Start()
    {
        Enemy = Init(10, 20, Name, 150);

        Elements.ElementalMix[] defence = new Elements.ElementalMix[]
        {
            new Elements.ElementalMix(Elements.EElementalTypes.STONE, 0.5f),
            new Elements.ElementalMix(Elements.EElementalTypes.GROUND, 0.5f),
            new Elements.ElementalMix(Elements.EElementalTypes.ELECTRICITY, 1),
            new Elements.ElementalMix(Elements.EElementalTypes.ICE, -0.5f),
            new Elements.ElementalMix(Elements.EElementalTypes.WATER, 0.3f)
        };

        bool work = Enemy.Gear.AddElementDefence(out Elements.ElementalMix[] noAdd, defence);
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
}
