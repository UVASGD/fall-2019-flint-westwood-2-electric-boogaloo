using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    private KeyCode propCycleKey = KeyCode.E;
    private PropPlacementHandler _propPlacementHandler;
    // private List<BaseProp> ownedProps;
    // private BaseProp equippedProp;
    private int _propIndex;
    private bool _isPropAvailable;
    
    void Start()
    {
        _propIndex = 0;
    }

    void Update()
    {
        /*
         * if (ownedProps.count > 0) {
         *    _isPropAvailable = true
         * } else {
         *     _isPropAvailable = false
         * }
         *
         * _isPropAvailable = ownedProps.count > 0 ? true : false;
         *
         */
    }

    void EquipProp()
    {
        if (_isPropAvailable)
        {
            /*
             * equippedProp = ownedProps(_propIndex);
             * 
             */
        }
    }

    void CycleProp()
    {
        // if (// ownedProps.count > 1 && Input.GetKeyDown(propCycleKey))
        // _propIndex++;
        // _propIndex = _propIndex % ownedProps.count;
    }
}
