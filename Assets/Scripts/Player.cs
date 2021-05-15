using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    private Vector3 target_direction = new Vector3(0, 0, 0);
    public float angle;
    public float movement;

    private int game_object_collision_counter = 0;

    private float moving_speed;
    private Transform parent;


    private void Start()
    {
        moving_speed = speed * Time.deltaTime;
        parent = transform.parent;
        
        Vector3 parentPos = parent.localPosition;
        Vector3 parentScale = parent.localScale;


        transform.position = new Vector3(parentPos.x, parentPos.y + parentScale.y, parentPos.z);
    }

    public void Move(float z)
    {
        transform.Translate(0, 0, z * moving_speed);
    }

    public void Rotate(float angle)
    {
        float _angle = angle * moving_speed * 0.25f;
        target_direction = new Vector3(Mathf.Sin(_angle), 0, Mathf.Cos(_angle));
        transform.rotation = Quaternion.Slerp(Quaternion.identity, Quaternion.LookRotation(target_direction), 1);
    }

    private void FixedUpdate()
    {
        movement = 0;
        movement = Input.GetAxis("Vertical");
        angle += Input.GetAxis("Horizontal");

        Rotate(angle);
        Move(movement);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);

            game_object_collision_counter += 1;

            Debug.Log("game_object_collision_counter = " + game_object_collision_counter);
        }
    }
}