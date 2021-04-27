using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float cam_offset = 4.0f;
    public float cam_offset_height = 2.5f;

    private void Update()
    {
        var cam = transform;
        var player = target;
        
        cam.position = player.transform.position - player.transform.forward * cam_offset;
        cam.position += new Vector3(0, cam_offset_height, 0);
        
        cam.rotation = Quaternion.LookRotation(player.transform.position - cam.position, Vector3.up);
    }
}