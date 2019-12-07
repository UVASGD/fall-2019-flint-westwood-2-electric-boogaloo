using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class   Attractor : MonoBehaviour 
{
    public Rigidbody2D rb;

    public static List<Attractor> Attractors;

    const float G = 667.4f;

    void FixedUpdate ()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
            Attract(attractor);
        }


    }

    void OnEnable ()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();
        Attractors.Add(this);
    }

    private void OnDisable()        
    {
        Attractors.Remove(this);
    }
    void Attract (Attractor objToAttract)
    {
        Vector2 origin = new Vector3(0, 0);
        Time.timeScale = 0.3f;

        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;
        if (distance > 10000)
        {
            transform.position = origin;
        }
        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / distance*20;

        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector2 newDirection = rb.velocity;

        rb.AddForce(newDirection * -8);
    }

}
