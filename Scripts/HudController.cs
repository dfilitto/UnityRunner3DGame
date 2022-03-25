using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public Text score;
    public Text scoreBackground;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (score != null)
        {
            score.text = "SCORE: " + GameController.score.ToString();
            scoreBackground.text = "SCORE: " + GameController.score.ToString();

        }
    }
}
