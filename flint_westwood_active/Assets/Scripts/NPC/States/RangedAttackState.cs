using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : FWState
{

    private GameObject projectile;

    private float baseReloadTime = 1f;
    private float reloadTime = 0f;

    public RangedAttackState(GameObject projectile)
    {
        this.projectile = projectile;
        this.npcState = NPCState.RangedAttack;
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
        if(reloadTime <= 0)
        {
            Fire(player, currentNpc);
            reloadTime = baseReloadTime;
        
        }
        else
        {
            reloadTime -= .1f;
        }
        // Pseudocode
        // if player exists, is in range and is visible (checked by previous state)
        // if npc has bullets in weapon (checked by previous state)
        // npc takes aim at player (over a certain time period) using Coroutine?
        // npc fires after a certain time period (player is alerted that they're being aimed at)
        
        throw new System.NotImplementedException();
    }

    private void Fire(GameObject player, GameObject currentNpc){
        GameObject newProjectile = GameObject.Instantiate(projectile, currentNpc.transform.position, Quaternion.identity) as GameObject;
        
        //change bullet to travel towards player
        newProjectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(player.transform.position.y - currentNpc.transform.position.y, player.transform.position.x - currentNpc.transform.position.x) * Mathf.Rad2Deg - 90));

    }
}
