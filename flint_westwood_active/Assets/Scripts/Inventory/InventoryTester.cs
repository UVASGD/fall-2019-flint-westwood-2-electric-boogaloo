using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTester : MonoBehaviour
{
    public GameObject weapon, prop, upgrade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject w = Instantiate(weapon);
            Inventory.Instance.AddItem(w);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject p = Instantiate(prop);
            Inventory.Instance.AddItem(p);
        }
        if (Input.GetKeyDown(KeyCode.D) && upgrade)
        {
            GameObject u = Instantiate(upgrade);
            Workbench.Instance.AddUpgrade(u);
        }
    }
}