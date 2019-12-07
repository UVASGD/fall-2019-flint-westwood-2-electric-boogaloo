using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWStateController : MonoBehaviour
{
    public GameObject player;

    protected FWStateManager _manager;

    protected virtual void InitializeStateManager()
    {
        _manager = new FWStateManager();
    }
    
    public void SwitchState(NPCStateTransition transition)
    {
        _manager.HandleTransition(transition);
    }
    void Start()
    {
        InitializeStateManager();   
    }

    protected virtual void Update()
    {
        if (player && this.gameObject)
        {
            _manager.CurrentState.ShouldStateChange(player, this.gameObject);
            _manager.CurrentState.ExecuteCurrentStateBehavior(player, this.gameObject);
        }
    }

    public void StartStateCoroutine(IEnumerator coroutineToPlay)
    {
        StartCoroutine(coroutineToPlay);
    }
}
