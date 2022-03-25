using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        if(inputField.text.Length > 0)
        {
            GameController.playerName = inputField.text;
            SceneManager.LoadScene("Main");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
