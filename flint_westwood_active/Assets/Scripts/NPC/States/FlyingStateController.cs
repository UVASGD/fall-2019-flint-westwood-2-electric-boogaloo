using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingStateController : FWStateController
{
    [SerializeField] private float flyingRadius;
    private FlyingState flyingState;
    private FlyingAttackState flyingAttackState;
    protected override void InitializeStateManager()
    {
        base.InitializeStateManager();
        flyingState = new FlyingState(player, this.gameObject);
        flyingAttackState = new FlyingAttackState();
        _manager.AddNewState(flyingState);
        _manager.AddNewState(flyingAttackState);
        
        
    }

    protected override void Update()
    {
        base.Update();
        flyingState.SetRadius(flyingRadius);
    }
    
}
