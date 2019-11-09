using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerState : FWState
{
    public AttackPlayerState()
    {
        npcState = NPCState.Attack;
    }

    public override void ShouldStateChange(GameObject player, GameObject currentNpc)
    {
        // if player is dead or out of range for a certain amount of time
        // or currentNPC is dead (killed by player)
        // stop attacking / dead
        throw new System.NotImplementedException();
    }

    public override void ExecuteCurrentStateBehavior(GameObject player, GameObject currentNpc)
    {
        // Pseudocode
        // if player exists, is in range and is visible (checked by previous state)
        // if npc has bullets in weapon (checked by previous state)
        // npc takes aim at player (over a certain time period) using Coroutine?
        // npc fires after a certain time period (player is alerted that they're being aimed at)
        
        
        throw new System.NotImplementedException();
    }
}
