using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Waypoint
{
    public Vector2 _waypoint;

    public Waypoint(float x, float y)
    {
        _waypoint = new Vector2(x, y);
    }


}
