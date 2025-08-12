using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableItems : MonoBehaviour
{
    public float flightHeight;
    public float flightSpeed;
    public int itemValue;

    public Vector3 startPosition;

    public abstract void itemMovement();
    public abstract void itemCollect();


}
