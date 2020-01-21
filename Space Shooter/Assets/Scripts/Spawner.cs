using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject rock;
    public GameObject enemyshipNormal;
    public GameObject enemyshipStraightBullets;

    
    float x1, x2;
    Vector2 spawnPoint;
    
	// Use this for initialization
	void Start () {
        float randomNumberNormalBullets = Random.Range(1.5f, 2.5f);
        float randomNumberStraightBullets = Random.Range(3, 4.5f);

        InvokeRepeating("SpawnRock", 0, 2);
        InvokeRepeating("SpawnEnemy", 0, randomNumberNormalBullets);
        InvokeRepeating("SpawnOtherEnemy", 0, randomNumberStraightBullets);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnRock()
    {
        x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x / 2;
        x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x / 2;
        spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        Instantiate(rock, spawnPoint, Quaternion.identity);

    }

    void SpawnEnemy()
    {
        x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x / 2;
        x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x / 2;
        spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        Instantiate(enemyshipNormal, spawnPoint, Quaternion.identity);
    }

    void SpawnOtherEnemy()
    {
        x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x / 2;
        x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x / 2;
        spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        Instantiate(enemyshipStraightBullets, spawnPoint, Quaternion.identity);
    }
}
