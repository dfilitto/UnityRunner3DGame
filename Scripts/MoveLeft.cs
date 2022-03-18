using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float LeftBound = -15;
    //private float speed = 10f;
    void Start()
    {
    }
    void Update()
    {
        if (GameController.gameOver) return;
        transform.Translate(Vector3.left * GameController.speed * Time.deltaTime);
        //destrói o obstáculo
        if (transform.position.x < LeftBound && gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }
    }
}
