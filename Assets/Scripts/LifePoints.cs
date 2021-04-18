using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifePoints : MonoBehaviour
{
    public static int playerScore;  //  Static keyword makes this variable a LifePoints of the class, not of any particular instance.
    //
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            playerScore++;
            Debug.Log(playerScore);

        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}

