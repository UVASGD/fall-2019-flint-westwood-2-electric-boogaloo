using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    Transform weapon_content, placeable_content;

    List<GameObject> items = new List<GameObject>();

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
    }

    public void AddItem(GameObject item)
    {
        GameObject spawned_item = Instantiate(item, transform.position, Quaternion.identity);
        spawned_item.transform.parent = weapon_content;
        items.Add(spawned_item);
    }

    public void RemoveItem(GameObject item)
    {
        items.Remove(item);
        Destroy(item);
    }
}
