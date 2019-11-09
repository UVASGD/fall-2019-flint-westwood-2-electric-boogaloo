using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FWState
{
    protected Dictionary<NPCStateTransition, NPCState>
        StateTransitions = new Dictionary<NPCStateTransition, NPCState>();

    protected NPCState npcState;

    public NPCState NpcState => npcState;

    public void AddStateTransition(NPCStateTransition transitionType, NPCState newState)
    {
        if (!FWStateUtility.IsTransitionDefined(transitionType) || !FWStateUtility.IsStateDefined(newState))
            return; // can't be a non-existing state
        // state can only move down a path, no single transition can map to multiple states (yet)

        if (TransitionExists(transitionType)) return;
        StateTransitions.Add(transitionType, newState);
    }

    public void RemoveStateTransition(NPCStateTransition transitionToRemove)
    {
        if (!FWStateUtility.IsTransitionDefined(transitionToRemove)) return;
        RemoveTransitionFromDictionary(transitionToRemove);
    }

    public NPCState GetStateFromTransition(NPCStateTransition transitionType)
    {
        if (StateTransitions.ContainsKey(transitionType))
            return StateTransitions[transitionType]; // if transition for the state exists
        return NPCState.DefaultState; // otherwise return base state
    }


    private void RemoveTransitionFromDictionary(NPCStateTransition transitionToRemove)
    {
        if (StateTransitions.ContainsKey(transitionToRemove))
        {
            StateTransitions.Remove(transitionToRemove);
        }
        else
        {
            Debug.LogError("Dictionary does not contain this transition, cannot remove..");
        }
    }

    private bool TransitionExists(NPCStateTransition transitionType)
    {
        return StateTransitions.ContainsKey(transitionType);
    }

    public virtual void InitializeNewState()
    {
    }

    public virtual void CleanupOldState()
    {
    }

    public abstract void ShouldStateChange(GameObject player, GameObject currentNpc);

    public abstract void ExecuteCurrentStateBehavior(GameObject player, GameObject currentNpc);
}