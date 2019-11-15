using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour, IInteractable
{
    public KeyCode workbenchBind;
    private bool isInventoryOpen;
    void Start()
    {
        isInventoryOpen = false;
    }

    void Update()
    {
        
    }

    public void Interact()
    {
        if (Input.GetKeyDown(workbenchBind))
        {
            isInventoryOpen = !isInventoryOpen;
        }
    }

    private void HandleWorkbenchInventory()
    {
        if (isInventoryOpen)
        {
            DisplayInventory();
        }
    }

    private void DisplayInventory()
    {
        throw new System.NotImplementedException();
    }
}