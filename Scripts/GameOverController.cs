using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text score;
    public Text scoreBackground;

    public Text highScore;
    public Text highScoreBackground;
    // Start is called before the first frame update
    void Start()
    {
        //salvar os dados do jogo
        GameController.SaveData();
        //atualizar itens de tela
        score.text = "Player:. "+ GameController.playerName + " scored " + GameController.score.ToString() + " points";
        scoreBackground.text = "Player:. " + GameController.playerName + " scored " + GameController.score.ToString() + " points";

        highScore.text = "Last High Score:. " + GameController.highScoreName + " scored " + GameController.highScore.ToString() + " points";
        highScoreBackground.text = "Last High Score:. " + GameController.highScoreName + " scored " + GameController.highScore.ToString() + " points";

        //ir para a tela de menu
        Invoke("GoMenu", 15f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
