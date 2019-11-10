using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    public static Workbench Instance;

    List<GameObject> upgrades = new List<GameObject>();
    InventoryItem selected_item;
    DisplayItem displayed_item;

    public Sprite default_sprite;
    public string default_text;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        displayed_item = GetComponentInChildren<DisplayItem>();
        displayed_item.Set(default_sprite, default_text);
    }

    public void SelectItem(InventoryItem item)
    {
        Deselect();
        selected_item = item;
        displayed_item.Set(item.image.sprite, item.text.text);
        /*
        foreach (GameObject u in upgrades)
        {
            // enable applicable upgrades
            Upgrade upgrade = u.GetComponent<Upgrade>();
            if (selected_item.HasTag(upgrade.UpgradeType)) 
            {
                upgrade.Activate();
            }
            else
            {
                upgrade.Deactivate();
            }
        }
        */
        // play sfx
    }

    public void Deselect()
    {
        // play sfx
        selected_item = null;
        displayed_item.Set(default_sprite, default_text);
    }

    public void Sell()
    {
        if (selected_item)
        {
            // give player monies
            // play sfx
            Inventory.Instance.RemoveItem(selected_item.gameObject);
        }
        Deselect();
    }

    public void AddUpgrade(GameObject item)
    {
        GameObject spawned_item = Instantiate(item, transform.position, Quaternion.identity);
        upgrades.Add(item);
    }

    public void RemoveUpgrade(GameObject item)
    {
        if (!item)
            return;
        upgrades.Remove(item);
        Destroy(item);
    }

    public void UpgradeItem(Upgrade upgrade)
    {
        if (selected_item)
        {
            selected_item.ApplyUpgrade(upgrade);
        }
    }
}
