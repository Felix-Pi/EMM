using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject player;
    public Transform enemy;

    public int amountOfEnemies = 10;


    public void SpawnEnemies(int amount)
    {
        Transform prefab = enemy.GetComponent<GameObjectScript>().prefab;
        Vector3 spawn_vector;

        for (int i = 0; i < amount; i++)
        {
            var board = transform;
            var localPosition = board.localPosition;
            var localScale = board.localScale;

            float offsetX = localScale.x / 2f;
            float offsetZ = localScale.z / 2f;

            float boarderX = enemy.localScale.x * 1.5f;
            float boarderZ = enemy.localScale.z * 1.5f;


            float x = UnityEngine.Random.Range(localPosition.x + offsetX - boarderX,
                localPosition.x - offsetX + boarderX);
            float z = UnityEngine.Random.Range(localPosition.z + offsetZ - boarderZ,
                localPosition.z - offsetZ + boarderZ);


            prefab.localScale = enemy.localScale;
            spawn_vector = new Vector3(x, localPosition.y + localScale.y, z);


            Transform spawned = Instantiate(prefab, spawn_vector, Quaternion.identity);
            spawned.transform.parent = transform;
        }
    }


    public void SpawnPlayer()
    {
        player.SetActive(true);
        var board = transform;
        var localPosition = board.localPosition;
        var localScale = board.localScale;

        player.transform.position = new Vector3(localPosition.x, localPosition.y + localScale.y, localPosition.z);
    }

    void Start()
    {
        SpawnPlayer();
        SpawnEnemies(amountOfEnemies);
    }

    // Update is called once per frame
    void Update()
    {
    }
}