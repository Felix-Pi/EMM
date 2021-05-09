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
            float x = UnityEngine.Random.Range(enemy.position.x + 1, board.position.x + board.localScale.x - 1);
            float z = UnityEngine.Random.Range(board.position.z + 1, board.position.z + board.localScale.z - 1);


            spawn_vector = new Vector3(x, board.position.y, z);

            Transform spawned = Instantiate(enemy, spawn_vector, Quaternion.identity);
            
            spawned.transform.position = spawn_vector;

            prefabs.AddLast(spawned);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        float moving_rotation_speed = Time.deltaTime * rotation_speed;

        Debug.Log(board.position);
        foreach (var prefab in prefabs)
        {
            prefab.transform.position = new Vector3(prefab.position.x, board.position.y, prefab.position.z);
            prefab.transform.rotation *= Quaternion.Euler(0, moving_rotation_speed + 1, 0);
        }
    }
}