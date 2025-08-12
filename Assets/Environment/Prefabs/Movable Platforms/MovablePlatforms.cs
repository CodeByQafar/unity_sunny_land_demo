using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatforms : MonoBehaviour
{
    // Start is called before the first frame update
   
   [SerializeField] private float flighDistance=3f;
   [SerializeField] private float flightSpeed=10f;
   private Vector3 startPosition;


    void Start()
    {
        startPosition=transform.position;
    }

    // Update is called once per frame
    private void platformMovement()
    {
        float x = startPosition.x + Mathf.Sin(Time.time * flightSpeed) * flighDistance;
        transform.position = new Vector3(x, startPosition.y, startPosition.z);
    }

     void Update()
    {
        platformMovement();
    }


}
