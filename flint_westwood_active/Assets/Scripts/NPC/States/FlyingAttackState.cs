using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlyingAttackState : FWState
{
    private float npcSpeed;
    
    public override void ShouldStateChange(GameObject player, GameObject currentNpc)
    {
        throw new System.NotImplementedException();
    }

    public override void ExecuteCurrentStateBehavior(GameObject player, GameObject currentNpc)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendCoroutine(currentNpc.GetComponent<FWStateController>(), player, currentNpc);
        }
    }

    public IEnumerator RIPFlintWestwood(GameObject player, GameObject currentNpc)
    {
        Vector3 direction = player.transform.position - currentNpc.transform.position;
        direction.Normalize();
        currentNpc.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return new WaitForSeconds(5f);
        currentNpc.GetComponent<Rigidbody2D>().velocity = npcSpeed * direction;
    }

    public void SendCoroutine(MonoBehaviour monoBehaviour, GameObject player, GameObject npc)
    {
        monoBehaviour.StartCoroutine(RIPFlintWestwood(player, npc));
    }
}
