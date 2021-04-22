using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    private Vector3 target_direction = new Vector3(0, 0, 0);
    private float angle;

    void Start()
    {
    }

    private void Update()
    {
        float moving_speed = speed * Time.deltaTime;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        angle += moveHorizontal * moving_speed * 0.25f;

        target_direction = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        transform.rotation = Quaternion.Slerp(Quaternion.identity, Quaternion.LookRotation(target_direction), 1);

        transform.Translate(0, 0, moveVertical * moving_speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            
            Debug.Log("test");
            Debug.Log("OnTriggerEnter");
        }
    }
}


//Aufgabe 13: player rotation auf Quernin.LookRotation setzen, wert von Input.GetAxis auf irgendwas raufiterieren