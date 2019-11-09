using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Transform healthBarContainer;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetHealthBar(float size)
    {
        healthBarContainer.localScale = new Vector3(size, 1f);
    }
}
