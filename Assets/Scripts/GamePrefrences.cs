using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class will pass to the game scene values from the lobby
public class GamePrefrences : MonoBehaviour
{
    public static GamePrefrences instance;

    public int numberOfSlimes; //how many slime lives to start with, default is 5
    public int numberOfPlayers; //how many player are connected when starting the game

    public GameObject controller;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void UpdatePrefrencess(int numberOfSlimesIn, int numberOfPlayersIn)
    {
        numberOfSlimes = numberOfSlimesIn;
        numberOfPlayers = numberOfPlayersIn;
    }
}
