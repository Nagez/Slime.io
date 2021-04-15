using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoints : MonoBehaviour
{
    public static int playerScore;  //  Static keyword makes this variable a LifePoints of the class, not of any particular instance.

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
             playerScore++;  //  Increment when i press the "W" $$anonymous$$ey.
    }
}

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
