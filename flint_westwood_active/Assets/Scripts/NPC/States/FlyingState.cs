using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingState : FWState
{
    private Vector2 _targetToCircle;
    private float _angle;
    
    private float _rotateSpeed = 5f;
    private float radius = 0.5f;
    
    // The point we are going around in circles
    private Vector2 basestartpoint;

    // Destination of our current move
    private Vector2 destination;

    // Start of our current move
    private Vector2 start;

    // Current move's progress
    private float progress = 0.0f;
    public float speed = 2.0f;
    
    private float alpha = 0f;
    private float alphaChange = 0f;

    private float tilt = 65f;

    
    public FlyingState(GameObject player, GameObject npc)
    {
        this.npcState = NPCState.Patrol;
        tilt = Random.Range(0f, 90f);
        alphaChange = Random.Range(0.5f, 1f);
//        start = npc.transform.localPosition;
//        basestartpoint = player.transform.localPosition;
//        progress = 0.0f;
//    
//        PickNewRandomDestination();
    }
    
    public void SetRadius(float newRadius)
    {
        this.radius = newRadius;
    }

    public override void ShouldStateChange(GameObject player, GameObject currentNpc)
    {
        return;
    }

    public override void ExecuteCurrentStateBehavior(GameObject player, GameObject currentNpc)
    {
        
        var position = player.transform.position;
        currentNpc.transform.position = new Vector2(position.x + (2.5f * MCos(alpha) * MCos(tilt)) - ( 1.25f * MSin(alpha) * MSin(tilt)),
            position.y + (2.5f * MCos(alpha) * MSin(tilt)) + ( 1.25f * MSin(alpha) * MCos(tilt)));
        alpha += alphaChange;
//        Vector3 whereToGo = player.transform.position;
//        currentNpc.GetComponent<Rigidbody2D>().velocity = whereToGo;
    }

    void WhatTheFuck(GameObject currentNpc)
    {
        bool reached = false;

        progress += speed * Time.deltaTime;

        if (progress >= 1.0f)
        {
            progress = 1.0f;
            reached = true;
        }

        currentNpc.transform.localPosition = (destination * progress) + start * (1 - progress);

        if (reached)
        {
            start = destination;
            PickNewRandomDestination();
            progress = 0.0f;
        }
    }
    
    float MCos(float value)
    {
        return Mathf.Cos(Mathf.Deg2Rad * value);
    }

    float MSin(float value)
    {
        return Mathf.Sin(Mathf.Deg2Rad * value);
    }

    void PickNewRandomDestination()
    {
        destination = Random.insideUnitCircle * radius + basestartpoint;
    }
}
