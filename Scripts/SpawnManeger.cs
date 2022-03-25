using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManeger : MonoBehaviour
{
    public GameObject[] obstaclesPrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private IEnumerator couroutine;
    //public float startDelay = 2f;
    //public float repeatRate = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        couroutine = SpawnObstacles();
        StartCoroutine(couroutine);
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if (!GameController.gameOver) CreateObstacle();
            yield return new WaitForSeconds(GameController.TimeToSpawn);
        }
    }

    private void CreateObstacle()
    {
        GameObject obstacle = obstaclesPrefab[Random.Range(0, obstaclesPrefab.Length-1)];
        Instantiate(obstacle, spawnPos, obstacle.transform.rotation);

    }
}
