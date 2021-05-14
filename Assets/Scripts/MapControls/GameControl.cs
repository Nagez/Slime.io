using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameControl : MonoBehaviour
{

    public int SlimesPerPlayer; //value is initialized at unity field if no gameprefence exists
    public int PlayersAmount;

    public List<GameObject> Players = new List<GameObject>();
    public int[] DiceMoves = new int[5];

    public bool firstDiceThrown = false;


    private static GameObject Player1, Player2, Player3, Player4;
    private static GameObject TextGreen, TextBlue, TextRed, TextYellow;//Playes turn text in hud

    public static int player1Rock = 0, player2Rock = 0; //not using

    public static int whosTurn = 1;
    public int whosTurnT = 1;
    /////////////////////////////////////////////////
    public static int diceSide = 0;//check if using

    
    // Start is called before the first frame update
    void Start()
    {
        //Player1 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "greenplayer"));//params(file location for photon plyaer prefab,position to start, rotation) 
        //Players.Add();

        Players[0].GetComponent<PlayerScript>().PTurn = true;
        GameObject.Find("dice6").GetComponent<AlinasDice>().coroutineAllowed = true;

        initPrefrences();

        //Whos Turn
        TextGreen = GameObject.Find("TextGreen");
        TextBlue = GameObject.Find("TextBlue");
        TextRed = GameObject.Find("TextRed");
        TextYellow = GameObject.Find("TextYellow");

        //Players match
        //Player1 = GameObject.Find("Player1");//can be problem
        //Player2 = GameObject.Find("Player2");
        //Player3 = GameObject.Find("Player3");
        //Player4 = GameObject.Find("Player4");

        //off turn text
        TextGreen.gameObject.SetActive(false);
        TextBlue.gameObject.SetActive(false);
        TextRed.gameObject.SetActive(false);
        TextYellow.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(CheckEndTurn()&&firstDiceThrown)
        {
            SwitchTurns();
            MovePlayer(whosTurnT);
        }
        MovePlayer(whosTurnT);
    }

    //TEMP only for display
    public static void MovePlayer(int whosTurnN)//2
    {
        TextGreen.gameObject.SetActive(false);
        TextBlue.gameObject.SetActive(false);
        TextRed.gameObject.SetActive(false);
        TextYellow.gameObject.SetActive(false);

        //Player1.GetComponent<PlayerScript>().PTurn = false;
        //Player2.GetComponent<PlayerScript>().PTurn = false;
        //Player3.GetComponent<PlayerScript>().PTurn = false;
        //Player4.GetComponent<PlayerScript>().PTurn = false;


        switch (whosTurnN)
        {
            case 1:
                //Player1.GetComponent<PlayerScript>().PTurn = true;
                TextGreen.gameObject.SetActive(true);
                break;
            case 2:
                //Player2.GetComponent<PlayerScript>().PTurn = true;
                TextBlue.gameObject.SetActive(true);
                break;
            case 3:
                //Player3.GetComponent<PlayerScript>().PTurn = true;
                TextRed.gameObject.SetActive(true);
                break;
            case 4:
                //Player4.GetComponent<PlayerScript>().PTurn = true;
                TextYellow.gameObject.SetActive(true);
                break;

        }
    }

    public void CollisionCheckingg()
    {
        
    }

 
    /////////////////////////////////////////Working
    //Is the player turn ended?

    //check if need to end turn
    public bool CheckEndTurn()
    {
    ///insode player    
    for(int i=0; i < DiceMoves.Length ;i++)
        {
            if (DiceMoves[i] != 0)
            {
                return false;
            }  
        }
        return true;
    }

    //Get slimes number
    public void initPrefrences()
    {
        if (GamePrefrences.instance)
        {
            SlimesPerPlayer = GamePrefrences.instance.numberOfSlimes;
            PlayersAmount = GamePrefrences.instance.numberOfPlayers;
        }
    }

    public void SwitchTurns()
    {
        Players[whosTurnT - 1].GetComponent<PlayerScript>().PTurn = false;

        if (whosTurnT < PlayersAmount)
            whosTurnT++;
        else
            whosTurnT = 1;

        whosTurn = whosTurnT;

        Players[whosTurnT - 1].GetComponent<PlayerScript>().PTurn = true;

        firstDiceThrown = false;

        GameObject.Find("dice6").GetComponent<AlinasDice>().coroutineAllowed = true;
    }

}
