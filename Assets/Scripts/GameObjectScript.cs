using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectScript : MonoBehaviour
{
    public Transform enemy;
    public Transform board;

    public int amount;
    public float rotation_speed = 20.0f;
    public LinkedList<Transform> prefabs = new LinkedList<Transform>();


    private float board_size;
    private int board_offset = 2;

    // Start is called before the first frame update


    void Start()
    {
        Vector3 spawn_vector;

        for (int i = 0; i < amount; i++)
        {
            
            
            float offsetX = board.localScale.x / 2f;
            float offsetZ = board.localScale.z / 2f;

            float x = UnityEngine.Random.Range(board.localPosition.x + offsetX - 1,
                board.localPosition.x - offsetX + 1);
            float z = UnityEngine.Random.Range(board.localPosition.z + offsetZ - 1,
                board.localPosition.z - offsetZ + 1);
            
            spawn_vector = new Vector3(x, board.localPosition.y + board.localScale.y, z);
            

            Transform spawned = Instantiate(enemy, spawn_vector, Quaternion.identity);
            spawned.transform.parent = board.transform;


            prefabs.AddLast(spawned);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moving_rotation_speed = Time.deltaTime * rotation_speed;

        foreach (var prefab in prefabs)
        {
            prefab.transform.position =
                new Vector3(prefab.position.x, board.position.y + board.localScale.y, prefab.position.z);
            prefab.transform.rotation *= Quaternion.Euler(0, moving_rotation_speed + 1, 0);
        }
    }
}