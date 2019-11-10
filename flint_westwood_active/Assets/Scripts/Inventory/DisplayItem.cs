using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayItem : MonoBehaviour
{
    [HideInInspector]
    public Image image;
    [HideInInspector]
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake()
    {
        image = transform.Find("Image").GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Set(Sprite sprite, string text)
    {
        image.sprite = sprite;
        this.text.text = text;
    }
}
