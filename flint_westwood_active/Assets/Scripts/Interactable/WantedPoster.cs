using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WantedPoster : MonoBehaviour, IInteractable
{
    [SerializeField] private string wantedName;
    [SerializeField] private float wantedReward;
    [SerializeField] private GameObject wantedNPC;
    [SerializeField] private string wantedDescription;

    private BoxCollider2D _posterCollider;
    void Start()
    {
        _posterCollider = GetComponent<BoxCollider2D>();
        _posterCollider.isTrigger = true;
    }

    void Update()
    {
        
    }

    public void Interact()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
//        Debug.Log("hello");
//        if (other.gameObject.CompareTag("Player"))
//        {
//            if (Input.GetKeyDown(KeyCode.F))
//            {
//                Debug.Log("Interacting with Wanted Poster!");
//            }
//        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interacting with Wanted Poster!");
            }
        }
    }
}
