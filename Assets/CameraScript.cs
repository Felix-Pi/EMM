using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemeraScript : MonoBehaviour
{
    public Transform target;
    public float offset_vertical = 10;
    public float offset_horizontal = 10;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       /* var position = target.position;
        
        float x = position.x + offset_horizontal;
        float y = position.y + offset_vertical;
        float z = position.z + offset_horizontal;

        transform.position = new Vector3(x, y, z);*/
    }
}