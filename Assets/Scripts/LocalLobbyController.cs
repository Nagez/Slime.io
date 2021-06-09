using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalLobbyController : MonoBehaviour
{

    public void BackToMain()
    {
        SceneManager.LoadScene(0); //main menue index is 0
    }
    public void LoadMap()
    {
        SceneManager.LoadScene(3); //map index is 3
    }
}
