using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWStateController : MonoBehaviour
{
    public GameObject player;

    private FWStateManager _manager;

    private void InitializeStateManager()
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

    void Update()
    {
        if (player && this.gameObject)
        {
            _manager.CurrentState.ShouldStateChange(player, this.gameObject);
            _manager.CurrentState.ExecuteCurrentStateBehavior(player, this.gameObject);
        }
    }
}
