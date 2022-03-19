using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
