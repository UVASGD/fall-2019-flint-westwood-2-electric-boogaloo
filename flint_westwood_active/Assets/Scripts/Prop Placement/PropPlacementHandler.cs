using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropPlacementHandler : MonoBehaviour
{
    private GameObject _equippedProp;
    private bool _isPropPlaced;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        
    }

    void EquipProp(GameObject prop)
    {
        _isPropPlaced = false;
        this._equippedProp = Instantiate(prop);
    }

    void PlaceProp()
    {
        if (_equippedProp && !_isPropPlaced)
        {
            _equippedProp.transform.position = GetPlacementPosiion();
            if (Input.GetMouseButtonDown(0))
            {
                if (isValidPlacementLocation()) _isPropPlaced = true;
            }
            else
            {
                CancelPropPlacement();
            }
        }
        else
        {
            Debug.Log("You don't have any props to place!");
        }
    }

    Vector3 GetPlacementPosiion()
    {
        Vector3 placementPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(placementPosition.x, placementPosition.y, _equippedProp.transform.position.z);
    }

    void CancelPropPlacement()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isPropPlaced = false;
            Destroy(_equippedProp);
        }
    }

    bool isValidPlacementLocation()
    {
        return true;
    }
}
