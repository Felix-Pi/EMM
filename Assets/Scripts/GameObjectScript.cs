using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectScript : MonoBehaviour
{
    public float rotation_speed = 20.0f;
    public Transform prefab;


    void FixedUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Collectable");

        float moving_rotation_speed = Time.deltaTime * rotation_speed;

        foreach (var enemie in enemies)
        {
            enemie.transform.rotation *= Quaternion.Euler(0, moving_rotation_speed + 1, 0);
        }
    }
}