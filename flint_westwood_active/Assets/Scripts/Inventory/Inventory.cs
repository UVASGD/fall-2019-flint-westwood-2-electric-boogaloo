using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    Transform weapon_content, prop_content;

    List<GameObject> weapons = new List<GameObject>();
    List<GameObject> props = new List<GameObject>();

    public GameObject base_inventory_item;

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
        if (item.GetComponent<BaseWeapon>())
        {
            GameObject spawned_item = Instantiate(base_inventory_item, transform.position, Quaternion.identity);
            spawned_item.transform.parent = weapon_content;
            Weapon weapon_profile = item.GetComponent<BaseWeapon>().weaponAttributes;
            InventoryItem inventory_item = spawned_item.GetComponent<InventoryItem>();
            inventory_item.image.sprite = weapon_profile.weaponSprite;
            inventory_item.text.text = weapon_profile.mame;
            inventory_item.game_item = item;
            weapons.Add(spawned_item);
        }
        else if (item.GetComponent<BaseProp>())
        {
            GameObject spawned_item = Instantiate(base_inventory_item, transform.position, Quaternion.identity);
            spawned_item.transform.parent = prop_content;
            Prop prop_profile = item.GetComponent<BaseProp>().propAttributes;
            InventoryItem inventory_item = spawned_item.GetComponent<InventoryItem>();
            inventory_item.image.sprite = prop_profile.propSprite;
            inventory_item.text.text = prop_profile.propName;
            inventory_item.game_item = item;
            props.Add(spawned_item);
        }
    }

    public void RemoveItem(GameObject item)
    {
        if (!item)
            return;
        weapons.Remove(item);
        props.Remove(item);
        item.GetComponent<InventoryItem>().Remove();
    }
}
