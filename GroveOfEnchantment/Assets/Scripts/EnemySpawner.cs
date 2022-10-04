using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{
    public GameObject enemy;
    private float randX;
    private float randY;
    private Vector2 whereToSpawn;
    public float spawnRate;
    private float timer;
    public GameObject[] spawnPoints;
    private int spawnIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, spawnPoints[0].transform.position, Quaternion.identity);
        Instantiate(enemy, spawnPoints[1].transform.position, Quaternion.identity);
        timer = Time.time + spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < Time.time) {
            timer = Time.time + spawnRate;
            Instantiate(enemy, spawnPoints[spawnIndex % 2].transform.position, Quaternion.identity);
            spawnIndex++;
            
        }
    }
}
