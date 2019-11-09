using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWStateManager
{
    private List<FWState> _states;

    public NPCState CurrentStateType { get; private set; }
    public FWState CurrentState { get; private set; }

    public FWStateManager()
    {
        this._states = new List<FWState>();
    }

    public void AddNewState(FWState newState)
    {
        if (!FWStateUtility.IsValidState(newState)) return;
        if (_states.Count == 0) // if there are no states, add state as first
        {
            InitializeState(newState);
            return;
        }

        for (int i = 0; i < _states.Count; i++)
        {
            if (_states[i].NpcState == newState.NpcState)
            {
                Debug.LogError("The state being added already exists in the list");
                return;
            }
        }

        _states.Add(newState);
    }

    public void RemoveExistingState(NPCState stateToRemove)
    {
        if (!FWStateUtility.IsValidNpcState(stateToRemove)) return;
        for (int i = 0; i < _states.Count; i++)
        {
            if (_states[i].NpcState == stateToRemove)
            {
                _states.Remove(_states[i]);
                return;
            }
        }
    }

    public void HandleTransition(NPCStateTransition transitionType)
    {
        if (!FWStateUtility.IsTransitionDefined(transitionType)) return;
        NPCState newNpcState = CurrentState.GetStateFromTransition(transitionType);
        if (!FWStateUtility.IsValidNpcState(newNpcState)) return;
        CurrentStateType = newNpcState;
    }

    private void InitializeState(FWState newState)
    {
        _states.Add(newState);
        this.CurrentState = newState;
        this.CurrentStateType = newState.NpcState;
        for (int i = 0; i < _states.Count; i++)
        {
            if (_states[i].NpcState == CurrentStateType)
            {
                CurrentState.CleanupOldState();
                CurrentState = _states[i];
                CurrentState.InitializeNewState();
                break;
            }
        }
    }
}