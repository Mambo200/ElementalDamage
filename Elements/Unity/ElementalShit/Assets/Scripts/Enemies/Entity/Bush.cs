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
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Enemy = Init(2, 5, Name, 50);
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
}
