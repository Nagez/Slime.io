using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public int SlimesPerPlayer; 
    public int PlayersAmount;
    private int maxPlayersAllowed = 4;

    public List<GameObject> Players = new List<GameObject>();

    public int[] DiceMoves = new int[5];
    public int DicePICKED = 0;
    public int DicePICKEDArr = 0;
    public bool firstDiceThrown = false;
    public bool CubeClicked = false;

    PhotonView myPV;
    Player[] allPlayers;

    public int whosTurnT = 1;
    public GameObject Dice;

    public static int diceSide = 0;//check if using

    [Header("HUD")]
    public GameObject HudPanel;
    public GameObject PlayerHud;
    private Color[] colorsArr = new Color[] { Color.green, Color.blue, Color.red, Color.yellow };
    private Color[] outerColorsArr = new Color[] { new Color32(88, 180, 74, 255), new Color32(62, 146, 221, 255), new Color32(245, 89, 75, 255), new Color32(250, 224, 63, 255) };
    private Color[] innerColorsArr = new Color[] { new Color32(45, 130, 0, 255), new Color32(16, 84, 144, 255), new Color32(156, 21, 8, 255), new Color32(173, 153, 32, 255) };
    public Sprite[] DefaultSlimeSprites;
    public List<GameObject> HudArr = new List<GameObject>();
    public GameObject GameOverPanel;
    public GameObject settingPanel;


    // Start is called before the first frame update
    void Start()
    {
        initLocalPrefrences();
        if (PhotonNetwork.IsConnected) //check how many players are connected if connected online
        {
            SlimesPerPlayer = int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["NumOfSlimes"].ToString());
            PlayersAmount = PhotonNetwork.CurrentRoom.PlayerCount;
            initPlayerOwnerships();
        }
        initHUD();       
        setActivePlayers();
        
        Dice.GetComponent<CubeScript>().coroutineAllowed = true;
        Players[0].GetComponent<PlayerScript>().PTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckEndTurn()&&firstDiceThrown)
        {
            SwitchTurns();
        }
        updateTurnHUD(whosTurnT);       
    }

    //updates the your turn in hud when turns switches
    private void updateTurnHUD(int whosTurnT)
    {
        for (int i = 0; i < PlayersAmount; i++) //for each loop add corresponding player HUD
        {
            HudArr[i].transform.GetChild(4).gameObject.SetActive(false);
            HudArr[i].transform.GetChild(5).gameObject.SetActive(false);
        }
        HudArr[whosTurnT-1].transform.GetChild(4).gameObject.SetActive(true);
        HudArr[whosTurnT - 1].transform.GetChild(5).gameObject.SetActive(true);

    }

    //init HUD at start considering player amount
    public void initHUD()
    {
        for (int i = 0; i < PlayersAmount; i++) //for each loop add corresponding player HUD
        {
            HudArr.Add(Instantiate(PlayerHud, Vector3.zero, Quaternion.identity, HudPanel.transform)); //add each player hud to an array
            //access HUD prefab individual objects
            var outersquare = HudArr[i].transform.GetChild(0);
            var innerrsquare = HudArr[i].transform.GetChild(1);
            var namePlate = HudArr[i].transform.GetChild(2);
            var slimeImg = HudArr[i].transform.GetChild(1).GetChild(0);
            var healthBar = HudArr[i].transform.GetChild(3);
            //change each component to fit each player slime color and name
            outersquare.GetComponent<Image>().color = outerColorsArr[i];
            innerrsquare.GetComponent<Image>().color = innerColorsArr[i];
            namePlate.GetComponent<Image>().color = colorsArr[i];
            namePlate.GetComponentInChildren<TextMeshProUGUI>().text = "Player "+ (i+1);
            slimeImg.GetComponent<Image>().sprite = DefaultSlimeSprites[i];

            //gray out lives that are not needed
            for (int j = 0; j < 5 - SlimesPerPlayer; j++)
            {
                healthBar.transform.GetChild(j).GetComponent<Image>().color = Color.gray;
            }
            
        }
        //set nicknames in online
        if (PhotonNetwork.IsConnected)
        {
            int myNumberInRoom = 0;
            foreach (Player p in allPlayers)
            {
                var playerNametxt = HudArr[myNumberInRoom].transform.GetChild(2).GetChild(0);
                playerNametxt.GetComponentInChildren<TextMeshProUGUI>().text = p.NickName;
                myNumberInRoom++;
            }
        }
    }

    //update lives when function call using whosTurn to detect which player live was changed
    public void UpdatePlayerLivesHud() 
    {
        int newlife = Players[whosTurnT - 1].GetComponent<PlayerScript>().SlimesLeft;
        var healthBar = HudArr[whosTurnT - 1].transform.GetChild(3);
        for (int j = 0; j < 5 - newlife; j++)
        {
            healthBar.transform.GetChild(j).GetComponent<Image>().color = Color.gray;
        }
    }

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

    //display Game over panel and winner
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

    public void settingsPanelOn()
    {
        settingPanel.SetActive(true);
    }
    public void settingsPanelOff()
    {
        settingPanel.SetActive(false);
    }

    public void BackToMain()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }

        SceneManager.LoadScene(0); //back to main menue
    }

    //in online transfer the photon view ownership to the right players
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

    //init number of slimes and players for local play trough gamepreferences from the local lobby
    public void initLocalPrefrences()
    {
        if (GamePrefrences.instance)
        {
            SlimesPerPlayer = GamePrefrences.instance.getNumOfSlime();
            PlayersAmount = GamePrefrences.instance.getRoomSize();
        }
    }


}
