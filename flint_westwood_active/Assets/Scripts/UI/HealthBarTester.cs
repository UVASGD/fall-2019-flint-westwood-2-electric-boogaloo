using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTester : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;

    private float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 1f;
        StartCoroutine(SetHealthBar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetHealthBar()
    {
        while (health > 0f)
        {
            health -= 0.1f;
            healthBar.SetHealthBar(health);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
