using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerState : FWState
{
    private float _visionAngle;

    private float _rayDistance;
    private float _range;

    private Weapon _currentWeapon;

    public TargetPlayerState(float visionAngle, float range, Weapon currentWeapon)
    {
        // initialize the npc state
        npcState = NPCState.Track;
        _visionAngle = visionAngle;
        _rayDistance = 2f;
        _range = range;
        _currentWeapon = currentWeapon;
    }
    
    public override void ShouldStateChange(GameObject player, GameObject currentNpc)
    {
        if (PlayerInRange(player, currentNpc) && _currentWeapon.ammoCount > 0) // we have ammo and we are in range
        {
            currentNpc.GetComponent<FWStateController>().SwitchState(NPCStateTransition.TargetedPlayer); // tell stat machine player has been targeted (so we can transition to the attack state)
        }
        Debug.Log("Target State: Should Change?");
    }

    public override void ExecuteCurrentStateBehavior(GameObject player, GameObject currentNpc)
    {
        if (PlayerInView(player, currentNpc)) // todo: and if player is HOSTILE or AGGRESSIVE
        {
            // move until in range
            
            TargetPlayer(player, currentNpc);
        }
    }

    private void MoveToRange(GameObject player, GameObject currentNpc)
    {
        while(!PlayerInRange(player, currentNpc)) // and there are no obstacles in the way (or view obstructed)
        {
            
        }
    }
    private bool PlayerInView(GameObject player, GameObject currentNpc)
    {
        Vector2 vecToPlayer = player.transform.position - currentNpc.transform.position;
        return Vector2.Angle(vecToPlayer, currentNpc.transform.up) < _visionAngle;
    }

    private bool PlayerInRange(GameObject player, GameObject currentNpc)
    {
        return Vector2.Distance(currentNpc.transform.position, player.transform.position) <= _range; // checks if the distance between npc position and player position is in range of currently equipped weapon's range
    }

    private void TargetPlayer(GameObject player, GameObject currentNpc)
    {
        var position = currentNpc.transform.position;
        Vector2 vecToPlayer = player.transform.position - position;
        vecToPlayer = vecToPlayer.normalized;
        RaycastHit2D hit = Physics2D.Raycast(position, vecToPlayer.normalized);
        Debug.DrawRay(position, vecToPlayer * _rayDistance, Color.red);
    }
}
