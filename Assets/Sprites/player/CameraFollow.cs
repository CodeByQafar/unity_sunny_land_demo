using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private Vector3 cameraPosition;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        cameraPosition = transform.position;
  
        cameraPosition.x = player.position.x;
        if( 4.7<player.position.y && player.position.y<14){
             cameraPosition.y = player.position.y;
        }
  
        transform.position = cameraPosition;

    }
    void Update()
    {

    }
}
