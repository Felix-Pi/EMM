using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectScript : MonoBehaviour
{
    public Transform myPrefab;
    public int amount;
    public float speed = 20.0f;
    public LinkedList<Transform> prefabs = new LinkedList<Transform>();

    private int board_size = 25;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawn_vector;

        for (int i = 0; i < amount; i++)
        {
            int board_coords = board_size / 2; //todo rename
            int x = UnityEngine.Random.Range(-board_coords, board_coords);
            int z = UnityEngine.Random.Range(-board_coords, board_coords);

            spawn_vector = new Vector3(x, 1f, z);

            Transform spawned = Instantiate(myPrefab, spawn_vector, Quaternion.identity);

            prefabs.AddLast(spawned);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moving_speed = Time.deltaTime * speed;

        foreach (var prefab in prefabs)
        {
            prefab.transform.rotation *= Quaternion.Euler(0, moving_speed + 1, 0);
        }
    }
}