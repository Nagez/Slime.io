using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HudScript : MonoBehaviour
{

    private static int score;  //  A new Static variable to hold our score.

    void Update()
    {
        score = LifePoints.playerScore;  //  Update our score continuously.
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Score: " + score);  //  Display the score on a label.
    }
}
