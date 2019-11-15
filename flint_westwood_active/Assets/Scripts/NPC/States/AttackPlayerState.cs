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
        // if npc  has bullets in weapon (checked by previous state)
        // npc takes aim at player (over a certain time period) using Coroutine?
        // npc fires after a certain time period (player is alerted that they're being aimed at)
        Vector3 playerPos = player.transform.position, npcPos = currentNpc.transform.position;
        float attackRange = 5f;
        
        float distToPlayer = Vector3.Distance(npcPos, playerPos);
        if (distToPlayer < attackRange)
        {
            Vector3 dirToPlayer = playerPos - npcPos;
            float angleToPlayer = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg;
            Quaternion toTurn = Quaternion.AngleAxis(angleToPlayer, Vector3.forward);
            currentNpc.transform.rotation =
                Quaternion.RotateTowards(currentNpc.transform.rotation, toTurn, 90 * Time.deltaTime);
            
        }
        
    }
}
