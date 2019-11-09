using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWaypointState : FWState
{
    private Waypoint[] _waypoints;
    private int _currentWaypointIndex;
    private float _patrolNPCRange = 10f;
    private float _patrolNPCSpeed = 10f;
    
    public PatrolWaypointState(Waypoint[] waypoints)
    {
        this._waypoints = waypoints;
        _currentWaypointIndex = 0;
        this.npcState = NPCState.Patrol;
    }

    public override void ShouldStateChange(GameObject player, GameObject currentNpc)
    {
        RaycastHit2D hit =
            Physics2D.Raycast(currentNpc.transform.position, currentNpc.transform.forward, _patrolNPCRange);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                currentNpc.GetComponent<FWStateController>().SwitchState(NPCStateTransition.SawPlayer);
            }
        }

    }

    public override void ExecuteCurrentStateBehavior(GameObject player, GameObject currentNpc)
    {
        var position = currentNpc.transform.position;
        Vector2 directionToWaypoint = _waypoints[_currentWaypointIndex]._waypoint - new Vector2(position.x, position.y);
        if (directionToWaypoint.magnitude < 1)
        {
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= _waypoints.Length) _currentWaypointIndex = 0;
        }
        else
        {
            float step =  _patrolNPCSpeed * Time.deltaTime; // calculate distance to move
            var npcPosition = currentNpc.transform.position;
            npcPosition = Vector3.MoveTowards(npcPosition, npcPosition, step);
            currentNpc.transform.position = npcPosition;
        }
    }
}
