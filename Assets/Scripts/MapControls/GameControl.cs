using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public int SlimesPerPlayer; 
    public int PlayersAmount;
    public List<GameObject> Players = new List<GameObject>();

    public int[] DiceMoves = new int[5];
    public int DicePICKED = 0;
    public int DicePICKEDArr = 0;
    public bool firstDiceThrown = false;

    private static GameObject Player1, Player2, Player3, Player4;
    //public static int player1Rock = 0, player2Rock = 0; //not using

    //public static int whosTurn = 1;
    public int whosTurnT = 1;
    public GameObject Dice;

    /////////////////////////////////////////////////
    public static int diceSide = 0;//check if using

    [Header("HUD")]
    public GameObject HudPanel;
    public GameObject PlayerHud;
    private Color[] colorsArr = new Color[] { Color.green, Color.blue, Color.red, Color.yellow };
    public Sprite[] DefaultSlimeSprites;
    public List<GameObject> HudArr = new List<GameObject>();
    public GameObject GameOverPanel;


    // Start is called before the first frame update
    void Start()
    {

        if (PhotonNetwork.IsConnected) //check how many players are connected if connected online
        {
            SlimesPerPlayer = int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["NumOfSlimes"].ToString());
            PlayersAmount = PhotonNetwork.CurrentRoom.PlayerCount;
            CreatePlayer();
        }
        initHUD();

        Dice.GetComponent<CubeScript>().coroutineAllowed = true;
        Players[0].GetComponent<PlayerScript>().PTurn = true;
        GameObject.Find("dice6").GetComponent<AlinasDice>().coroutineAllowed = true;
       // initPrefrences();

        //Players match
        //Player1 = GameObject.Find("Player1");//can be problem
        //Player2 = GameObject.Find("Player2");
        //Player3 = GameObject.Find("Player3");
        //Player4 = GameObject.Find("Player4");

    }

    // Update is called once per frame
    void Update()
    {
        //GameOverFunc();
        if (CheckEndTurn()&&firstDiceThrown)
        {
            SwitchTurns();
        }
        updateTurnHUD(whosTurnT);
        
    }

    private void updateTurnHUD(int whosTurnT)
    {
        for (int i = 0; i < PlayersAmount; i++) //for each loop add corresponding player HUD
        {
            HudArr[i].transform.GetChild(4).gameObject.SetActive(false);
        }
        HudArr[whosTurnT-1].transform.GetChild(4).gameObject.SetActive(true);
    }

    public void initHUD()
    {
        for (int i = 0; i < PlayersAmount; i++) //for each loop add corresponding player HUD
        {
            HudArr.Add(Instantiate(PlayerHud, Vector3.zero, Quaternion.identity, HudPanel.transform));
            var namePlate = HudArr[i].transform.GetChild(2);
            var slimeImg = HudArr[i].transform.GetChild(1).GetChild(0);
            var healthBar = HudArr[i].transform.GetChild(3);

            namePlate.GetComponent<Image>().color = colorsArr[i];
            //                PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");
            namePlate.GetComponentInChildren<TextMeshProUGUI>().text = "Player "+ (i+1);
            slimeImg.GetComponent<Image>().sprite = DefaultSlimeSprites[i];

            //gray out lives that are not needed
            for (int j = 0; j < 5 - SlimesPerPlayer; j++)
            {
                healthBar.transform.GetChild(j).GetComponent<Image>().color = Color.gray;
            }

        }
    }
    public void UpdatePlayerLivesHud() //update live when function call using whosTurn to detect player
    {
        int newlife = Players[whosTurnT - 1].GetComponent<PlayerScript>().SlimesLeft;
        var healthBar = HudArr[whosTurnT - 1].transform.GetChild(3);
        for (int j = 0; j < 5 - newlife; j++)
        {
            healthBar.transform.GetChild(j).GetComponent<Image>().color = Color.gray;
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

    //Game over
    public void GameOverFunc()
    {
        if (Players[whosTurnT - 1].GetComponent<PlayerScript>().SlimesLeft == 0)
        {
            Debug.Log("Player " + whosTurnT + " Won the game");
            GameOverPanel.SetActive(true);
            var winningSlimeIMG = GameOverPanel.transform.GetChild(4);
            var winningSlimeTXT = GameOverPanel.transform.GetChild(3);

            winningSlimeIMG.GetComponent<Image>().sprite = DefaultSlimeSprites[whosTurnT - 1];
            winningSlimeTXT.GetComponentInChildren<TextMeshProUGUI>().text = "Player " + (whosTurnT) + " WON!";
        }

    }
    public void BackToMain()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
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
                Player1.name = "Player1";
                Players.Add(Player1);
                firstUpdate("Green");
                break;
            case 1:
                Player2 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player2"), new Vector3(1, 1, 1), Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
                Player2.name = "Player2";
                Players.Add(Player2);
                firstUpdate("Blue");
                break;
            case 2:
                Player3 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player3"), new Vector3(2, 2, 2), Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
                Player3.name = "Player3";
                Players.Add(Player3);
                firstUpdate("Red");
                break;
            case 3:
                Player4 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player4"), new Vector3(3, 3, 3), Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
                Player4.name = "Player4";
                Players.Add(Player4);
                firstUpdate("Yellow");
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

    void firstUpdate(string color)
    {

        Transform moshe= GameObject.Find(color+"StartRock").transform;
        GameObject.Find(color+"Slime").GetComponent<Slime>().StartRock[0] = moshe;
        GameObject yossi = GameObject.Find("GameControls");
        GameObject.Find(color + "Slime").GetComponent<Slime>().GameControl = yossi;
        Animator kuku = GameObject.Find(color + "Slime").GetComponent<Animator>();
        GameObject.Find(color + "Slime").GetComponent<Slime>().anim = kuku;

        mapSet();
    }

    void mapSet()
    {
        GameObject ah = GameObject.Find("way");
        for(int i=0;i<32;i++)
        { 
        GameObject.Find("GreenSlime").GetComponent<Slime>().MainPath[i] = ah.transform.GetChild(i).transform;
        }

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
