using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum UpgradeType { Light, Heavy }

public class Upgrade : MonoBehaviour
{
    public UpgradeType UpgradeType;

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

    public void Activate()
    {
        button.enabled = true;
    }

    public void Deactivate()
    {
        button.enabled = false;
    }

    public void OnClick()
    {
        // tell the workbench to select me!
        Workbench.Instance.UpgradeItem(this);
    }
}
