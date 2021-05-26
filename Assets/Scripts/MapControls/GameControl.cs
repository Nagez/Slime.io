using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public int SlimesPerPlayer; //value is initialized at unity field if no gameprefence exists
    public int PlayersAmount;

    public List<GameObject> Players = new List<GameObject>();

    public GameObject HudPanel;
    public GameObject PlayerHud;
    
    public List<GameObject> HudArr = new List<GameObject>();

    public int[] DiceMoves = new int[5];
    public int DicePICKED = 0;
    public int DicePICKEDArr = 0;
    public bool firstDiceThrown = false;

    private static GameObject Player1, Player2, Player3, Player4;
    private static GameObject TextGreen, TextBlue, TextRed, TextYellow;//Playes turn text in hud

    public static int player1Rock = 0, player2Rock = 0; //not using

    //public static int whosTurn = 1;
    public int whosTurnT = 1;
    public GameObject Dice;

    /////////////////////////////////////////////////
    public static int diceSide = 0;//check if using

    
    // Start is called before the first frame update
    void Start()
    {

        if (PhotonNetwork.IsConnected) //check how many players are connected if connected online
        {
            PlayersAmount =PhotonNetwork.CurrentRoom.PlayerCount;
            CreatePlayer();
        }
        initHUD();
        //Player1 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "greenplayer"));//params(file location for photon plyaer prefab,position to start, rotation) 
        //Players.Add();

        Dice.GetComponent<CubeScript>().coroutineAllowed = true;
        Players[0].GetComponent<PlayerScript>().PTurn = true;
        GameObject.Find("dice6").GetComponent<AlinasDice>().coroutineAllowed = true;

       // initPrefrences();

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
        NoMoreSlimes();
        if (CheckEndTurn()&&firstDiceThrown)
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

    public void initHUD()
    {
        for (int i = 0; i < PlayersAmount; i++)
        {
            HudArr.Add(Instantiate(PlayerHud, Vector3.zero, Quaternion.identity, HudPanel.transform));
            //var namePlate = HudArr[i].transform.GetChild(2).gameObject.GetComponent<Image>().color;
            var namePlate = HudArr[i].transform.Find("nameTag").GetComponent<Image>().color;
        }
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

    public void SwitchTurns()
    {
        Players[whosTurnT - 1].GetComponent<PlayerScript>().PTurn = false;

        if (whosTurnT < PlayersAmount)
            whosTurnT++;
        else
            whosTurnT = 1;

        Players[whosTurnT - 1].GetComponent<PlayerScript>().PTurn = true;

        firstDiceThrown = false;

        GameObject.Find("Dice 1").GetComponent<CubeScript>().coroutineAllowed = true;
    }

    public void NoMoreSlimes()
    {
        if (Players[whosTurnT - 1].GetComponent<PlayerScript>().SlimesLeft == 0)
        {
            Debug.Log("Player " + whosTurnT + " Won the game");
        }
       
    }


    void CreatePlayer()
    {
        //file location name need to match actual location in unity case sensitive
        Debug.Log("creating player");
        int length = CountPlayerAmount();
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","greenplayer"),GameSetupController.GS, Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
        switch (length)
        {
            case 0:
                Player1 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player1"), new Vector3(0, 0, 0), Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
                Players.Add(Player1);
                break;
            case 1:
                Player2 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player2"), new Vector3(1, 1, 1), Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
                Players.Add(Player2);
                break;
            case 2:
                Player3 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player3"), new Vector3(2, 2, 2), Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
                Players.Add(Player3);
                break;
            case 3:
                Player4 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player4"), new Vector3(3, 3, 3), Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
                Players.Add(Player4);
                break;
        }

        
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "greenplayer"), new Vector3(0, 0, 0), Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","greenplayer"), position0.transform.position, Quaternion.identity);//params(file location for photon plyaer prefab,position to start, rotation) 
    }

    int CountPlayerAmount()
    {
        int amount = 0;
        for (int i = 0; i < Players.Count; i++)
            if (Players[i] != null)
                amount++;
            else break;
        return amount;
    }

    //Get slimes number
    //public void initPrefrences()
    //{
    //    if (GamePrefrences.instance)
    //    {
    //        SlimesPerPlayer = GamePrefrences.instance.numberOfSlimes;
    //        PlayersAmount = GamePrefrences.instance.numberOfPlayers;
    //    }
    //}


}
