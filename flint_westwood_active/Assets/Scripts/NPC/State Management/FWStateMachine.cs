using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWStateMachine : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    private Transform _playerLocation;

    protected virtual void InitializeState()
    {
        _playerLocation = player.transform;
    }
    protected virtual void StateUpdate() {}
    
    protected virtual void StateFixedUpdate() {}
    public virtual void Start()
    {
        InitializeState();
    }

    public virtual void Update()
    {
        StateUpdate();
    }

    public virtual void FixedUpdate()
    {
        StateFixedUpdate();
    }
    
    
}
