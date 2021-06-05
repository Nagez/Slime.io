using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviourPunCallbacks , IPunObservable
{

    public int SlimesPerPlayer; 
    public int PlayersAmount;
    private int maxPlayersAllowed = 4;

    public List<GameObject> Players = new List<GameObject>();

    public int[] DiceMoves = new int[5];
    public int DicePICKED = 0;
    public int DicePICKEDArr = 0;
    public bool firstDiceThrown = false;

    PhotonView myPV;
    Player[] allPlayers;

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
            myPV = GetComponent<PhotonView>();
            SlimesPerPlayer = int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["NumOfSlimes"].ToString());
            PlayersAmount = PhotonNetwork.CurrentRoom.PlayerCount;
            initPlayerOwnerships();
        }
        setActivePlayers();
        initHUD();

        Dice.GetComponent<CubeScript>().coroutineAllowed = true;
        Players[0].GetComponent<PlayerScript>().PTurn = true;
        GameObject.Find("dice6").GetComponent<AlinasDice>().coroutineAllowed = true;

       // initPrefrences();

    }

    // Update is called once per frame    
    void Update()
    {
        if (CheckEndTurn() && firstDiceThrown)
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

    [PunRPC]
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
    [PunRPC]
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

    [PunRPC]
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

        SceneManager.LoadScene(0);
    }

    private void initPlayerOwnerships()
    {
        int myNumberInRoom=0;
        myPV = GetComponent<PhotonView>();
        allPlayers = PhotonNetwork.PlayerList;
        foreach (Player p in allPlayers)
        {
            myNumberInRoom++;
            Debug.Log(myNumberInRoom);
            Debug.Log(p);
            if (p == PhotonNetwork.LocalPlayer)
            {
                Players[myNumberInRoom-1].GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
                Players[myNumberInRoom - 1].transform.GetChild(0).GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
            }
        }
    }

    private void setActivePlayers()
    {
        int maximumPlayers = maxPlayersAllowed - 1;
        for (int i = maximumPlayers; i >= PlayersAmount; i--) 
        {
            Players[maximumPlayers].gameObject.SetActive(false);
            maximumPlayers--;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(whosTurnT);
        }else
        {
            whosTurnT = (int)stream.ReceiveNext();
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
