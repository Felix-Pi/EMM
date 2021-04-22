using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float offset_vertical = 4;
    public float offset_horizontal = 8;
    public float cam_player_distance;

    void Start()
    {
    }

    // Update is called once per frame
    /*void Update()
    {
        var cam = transform;
        var player = target;


        float x = player.position.x;
        float y = player.position.y + offset_vertical;
        float z = player.position.z - offset_horizontal;

        Vector3 offsetVector = new Vector3(x, y, z);

        //transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, 1);
        //transform.position = Vector3.Slerp(transform.position, target.position + offsetVector, 1);


        cam.rotation = player.rotation;
        
        
        //cam.position = player.position.normalized + offsetVector;
        
        cam.Translate(player.rotation * offsetVector);

        cam_player_distance = Vector3.Distance(transform.position, target.position);
        //transform.LookAt(target);
    }*/

    //transform.Translate(offsetRotated);


    private void Update()
    {
        var cam = transform;
        var player = target;


        
        float x = player.position.x;
        float y = player.position.y + offset_vertical;
        float z = player.position.z - offset_horizontal;

        Vector3 offsetVector = new Vector3(x, y, z);
        
        
        float offsetDistance = 5f;

        Vector3 positionForCamera = player.transform.position - player.transform.forward * offsetDistance;
        cam.position = positionForCamera;
        cam.rotation = Quaternion.LookRotation(player.transform.position - cam.position, Vector3.up);
    }
}