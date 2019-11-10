using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    public static Workbench Instance;

    List<GameObject> upgrades = new List<GameObject>();
    InventoryItem selected_item;
    DisplayItem displayed_item;

    Transform upgrade_content;

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

        upgrade_content = transform.FindDeepChild("UpgradeContent");
    }

    private void Start()
    {
        displayed_item = GetComponentInChildren<DisplayItem>();
        displayed_item.Set(default_sprite, default_text);
        Deselect();
    }

    public void SelectItem(InventoryItem item)
    {
        Deselect();
        selected_item = item;
        displayed_item.Set(item.image.sprite, item.text.text);
        foreach (GameObject u in upgrades)
        {
            // enable applicable upgrades
            Upgrade upgrade = u.GetComponent<Upgrade>();
            if (selected_item.HasTag(upgrade.UpgradeType)) 
            {
                upgrade.Activate();
            }
        }
        // play sfx
    }

    public void Deselect()
    {
        // play sfx
        selected_item = null;
        displayed_item.Set(default_sprite, default_text);
        DeactivateUpgrades();
    }

    public void DeactivateUpgrades()
    {
        foreach (GameObject u in upgrades)
        {
            // enable applicable upgrades
            Upgrade upgrade = u.GetComponent<Upgrade>();
            upgrade.Deactivate();
        }
    }

    public void Sell()
    {
        if (selected_item)
        {
            selected_item.Sell();
        }
        Deselect();
    }

    public void AddUpgrade(GameObject item)
    {
        GameObject spawned_item = Instantiate(item, transform.position, Quaternion.identity);
        spawned_item.transform.parent = upgrade_content;
        Upgrade upgrade = spawned_item.GetComponent<Upgrade>();
        if (selected_item && selected_item.HasTag(upgrade.UpgradeType))
            upgrade.Activate();
        else
            upgrade.Deactivate();
        upgrades.Add(spawned_item);
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
