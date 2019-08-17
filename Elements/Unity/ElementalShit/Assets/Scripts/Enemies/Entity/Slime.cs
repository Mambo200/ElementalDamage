using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Elements.Clothings;
using Elements.Player;

public class Slime : MainEntity
{
    public override string Name => "Slime";

    public override Enemy Enemy { get; protected set; }

    // Start is called before the first frame update
    public override void Start()
    {
        Enemy = Slime.Init(5, 10, Name, 100);
    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override void DoTurn()
    {
        throw new System.NotImplementedException("No Turn Content");
    }
}
