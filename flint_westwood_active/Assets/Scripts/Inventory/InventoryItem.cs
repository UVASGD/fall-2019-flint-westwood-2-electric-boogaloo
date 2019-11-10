﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [HideInInspector]
    public bool weapon;

    [HideInInspector]
    public Image image;
    [HideInInspector]
    public TextMeshProUGUI text;
    [HideInInspector]
    public Button button;

    [HideInInspector]
    public GameObject game_item;

    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>(); 
        button = GetComponentInChildren<Button>();
    }

    // Update is called once per frame
    public void OnClick()
    {
        // tell the workbench to select me!
        Workbench.Instance.SelectItem(this);
    }

    public bool HasTag(UpgradeType upgradeType)
    {
        return true;
    }

    public void ApplyUpgrade(Upgrade upgrade)
    {
        // apply upgrade to game item
    }
}
