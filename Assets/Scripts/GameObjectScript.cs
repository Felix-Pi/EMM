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
        board_size = board.localScale.x;
        Vector3 spawn_vector;

        for (int i = 0; i < amount; i++)
        {
            float board_border_lower = -(board_size / 2) + board_offset; //todo rename
            float board_border_upper = (board_size / 2) - board_offset; //todo rename

            float x = UnityEngine.Random.Range(board_border_lower, board_border_upper);
            float z = UnityEngine.Random.Range(board_border_lower, board_border_upper);

            spawn_vector = new Vector3(x, 1f, z);

            Transform spawned = Instantiate(enemy, spawn_vector, Quaternion.identity);

            prefabs.AddLast(spawned);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moving_rotation_speed = Time.deltaTime * rotation_speed;

        foreach (var prefab in prefabs)
        {
            prefab.transform.rotation *= Quaternion.Euler(0, moving_rotation_speed + 1, 0);
        }
    }
}