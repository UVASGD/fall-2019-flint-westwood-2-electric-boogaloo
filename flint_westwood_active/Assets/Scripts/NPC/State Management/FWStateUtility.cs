using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* class FWStateUtility
 
 Simple utility class that checks validity of states and transitions */
public class FWStateUtility
{
    public static bool IsValidState(FWState stateToCheck)
    {
        return (stateToCheck != null);
    }

    public static bool IsValidNpcState(NPCState npcStateToCheck)
    {
        return npcStateToCheck != NPCState.DefaultState;
    }
    
    public static bool IsTransitionDefined(NPCStateTransition transitionToCheck)
    {
        return transitionToCheck != NPCStateTransition.DefaultTransition;
    }

    public static bool IsStateDefined(NPCState stateToCheck)
    {
        return stateToCheck != NPCState.DefaultState;
    }
}
