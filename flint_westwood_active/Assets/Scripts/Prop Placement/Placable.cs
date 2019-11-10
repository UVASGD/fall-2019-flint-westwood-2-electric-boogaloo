using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Placable : MonoBehaviour
{
    [HideInInspector] private List<Collider2D> propColliders;
    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        propColliders = new List<Collider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Prop"))
        {
            propColliders.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Prop"))
        {
            propColliders.Remove(other);
        }
    }
}
