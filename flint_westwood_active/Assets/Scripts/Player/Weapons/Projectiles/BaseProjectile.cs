using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    protected float Range;
    protected float ProjectileSpeed = 1f;
    void Start()
    {
        Destroy(this.gameObject, Range);

    }
    public virtual void Update()
    {
        transform.Translate(0, 0, ProjectileSpeed * Time.deltaTime);
    }

    public virtual void SetRange(float range)
    {
        this.Range = range;
    }
}
