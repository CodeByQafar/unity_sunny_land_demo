using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GemFeatures : CollectableItems
{


    private void Start()
    {
        startPosition = transform.position;
        flightHeight = 0.4f;
        flightSpeed = 5f;
        itemValue = 10;

    }


    public override void itemCollect()
    {

    }

    public override void itemMovement()
    {
        float y = startPosition.y + Mathf.Sin(Time.time * flightSpeed) * flightHeight;
        transform.position = new Vector3(startPosition.x, y, startPosition.z);
    }

    private void Update()
    {
        itemMovement();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
             Destroy(gameObject);

        }
    }

}
