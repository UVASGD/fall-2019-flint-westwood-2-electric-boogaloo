using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    Transform weapon_content, prop_content;

    List<GameObject> weapons = new List<GameObject>();
    List<GameObject> props = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        weapon_content = transform.FindDeepChild("WeaponContent");
        prop_content = transform.FindDeepChild("PropContent");
    }

    public void AddItem(GameObject item)
    {
        GameObject spawned_item = Instantiate(item, transform.position, Quaternion.identity);
        if (item.GetComponent<InventoryItem>().weapon)
        {
            spawned_item.transform.parent = weapon_content;
            weapons.Add(spawned_item);
        }
        else
        {
            spawned_item.transform.parent = prop_content;
            props.Add(spawned_item);
        }
    }

    public void RemoveItem(GameObject item)
    {
        if (!item)
            return;
        weapons.Remove(item);
        props.Remove(item);
        Destroy(item);
    }
}
