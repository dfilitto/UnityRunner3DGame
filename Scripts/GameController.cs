using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float speed = 13f; //velocidade dos itens
    public static float timeToSpawn = 3f; //tempo para criar novos inimigos 
    public static float score = 0f; //pontuação
    public static bool gameOver = false; // se o jogo acabou
    // Start is called before the first frame update
    void Start()
    {
        GameController.gameOver = false;
        InvokeRepeating("ChangeDificult", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeDificult()
    {
        GameController.speed += 1;
        GameController.timeToSpawn = Mathf.Clamp(GameController.timeToSpawn-0.5f,1.5f, 5f);
    }
}
