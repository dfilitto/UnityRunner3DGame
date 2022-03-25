using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float speed = 10f; //Controlar a velocidade do jogo
    public static float TimeToSpawn = 3f; //controla o tempo de criar novos obstáculos
    public static float score = 0f; //pontuação do jogo
    public static string playerName = "Runner";
    public static string highScoreName = "Runner";
    public static float highScore = 0f;
    public static bool gameOver = false; //controla o estado do jogo
    //carrega os dados salvos do jogo
    public static void LoadData()
    {
        GameController.highScore = PlayerPrefs.GetFloat("HighScore",0f);
        GameController.highScoreName = PlayerPrefs.GetString("HighScoreName","Player");
    }

    //salva os dados salvos do jogo
    public static void SaveData()
    {
        if (GameController.score > GameController.highScore)
        {
            PlayerPrefs.SetFloat("HighScore", GameController.score);
            PlayerPrefs.SetString("HighScoreName", GameController.playerName);
            //Caso queira que mostre seu nome como maior pontuação da rodada atual
            GameController.highScore = GameController.score;
            GameController.highScoreName = GameController.playerName;
            PlayerPrefs.Save();
        }
    }


    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        GameController.LoadData(); //carrega os dados ho HighScore
        GameController.speed = 10f;
        GameController.TimeToSpawn = 3f;
        GameController.score = 0f;
        GameController.gameOver = false;
        InvokeRepeating("ChangeDificult", 1f, 5f);
    }

    //controlar a dificuldade do jogo
    private void ChangeDificult()
    {
        if (!GameController.gameOver)
        {
            //altera a dificuldade do jogo
            GameController.speed += 1;
            GameController.TimeToSpawn = Mathf.Clamp(GameController.TimeToSpawn - 0.5f, 1.5f, 5f);
            //incrementa a pontuação
            GameController.score += 5;
        }
    }
}
