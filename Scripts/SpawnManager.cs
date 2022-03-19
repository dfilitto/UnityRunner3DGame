using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private Vector3 spawnBox = new Vector3(25, 0, 0);
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = SpawnObstacles();
        StartCoroutine(coroutine);
    }

    private IEnumerator SpawnObstacles()
    {   
        //GameController.gameOver == false   
        while (true)
        {
            CreateObstacle();
            yield return new WaitForSeconds(GameController.timeToSpawn);
        }
    }

    private void CreateObstacle()
    {
        GameObject obstacle = obstacles[Random.Range(0,obstacles.Length-1)];
        Instantiate(obstacle, spawnBox, obstacle.transform.rotation);
    }
}
