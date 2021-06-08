using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public List<GameObject> Slimes = new List<GameObject>();
    public int SlimesLeft;//slime lives per player
    public int SlimesSpawned;//THe slimes spawned in game
    public int playerNum;//player ID //player1
    public int TotalSlimesSpawned=0;
    //public int[] DiceMoves = new int[5];
    public bool PTurn = false;//player turn
    public bool FirstMove = false;

    public GameObject GameControlPlayer;

    public GameObject SlimePrefab;

    public GameObject StartRock;

    PhotonView MyPv;

    // Start is called before the first frame update
    void Start()
    {
        
        //locate Slimes per player
        //add function

        //GameObject GameControlPlayer = GameObject.Find("GameControls");
        //SlimesPerTPlayer = GameControlPlayer.GetComponent<GameControl>().SlimesPerPlayer;
        getSlimePerPlayer();
    }
    // Update is called once per frame
    void Update()
    {
        if(PTurn)
        {
            PlayersTurn(PTurn); 
        } 
    }
    public void getSlimePerPlayer()
    {
        if (PhotonNetwork.IsConnected) //take from lobby if connected online
        {
            SlimesLeft = int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["NumOfSlimes"].ToString());
        }
        else //take from gamecontrol
        {
            SlimesLeft = GameControlPlayer.GetComponent<GameControl>().SlimesPerPlayer;
        }
    }

    void PlayersTurn(bool moveAllowed)
    {
        if (moveAllowed)
        {            
            if(FirstMove==true)
            {
                //SlimeSpawnNeeded();
            }
            
            SlimeSpawnNeeded();
        }
    }
    
    public void SlimeSpawnNeeded()
    {
        if (SlimesSpawned < SlimesLeft)
        {
            bool slimeBenchPosition = false;
            //int slimeLevelCount = 0;
            for (int i = 0; i < this.Slimes.Count; i++)
            {
                if (this.Slimes[i].GetComponent<Slime>().PlayerPosition == 0)
                    slimeBenchPosition = true;
                //slimeLevelCount= slimeLevelCount+this.Slimes[i].GetComponent<Slime>().slimeLevel;
            }

            if (!slimeBenchPosition) //&& (slimeLevelCount< SlimesLeft))
            {
                if (PhotonNetwork.IsConnected)
                {
                    string SColor = SlimePrefab.name.Replace("Slime", "");
                    GameObject NewSlime = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", SColor + "Slime"), StartRock.transform.position, Quaternion.identity);//params(file location for photon plyaer prefab,position to start, rotation)

                    var newSlime = NewSlime.GetComponent<Slime>();
                    TotalSlimesSpawned++;
                    newSlime.InitNewSlime(playerNum, Slimes.Count, TotalSlimesSpawned);
                    Debug.Log(NewSlime.GetComponent<PhotonView>().ViewID);
                    Slimes.Add(NewSlime);
                    SlimesSpawned++;
                }
                else
                {
                    GameObject NewSlime = Instantiate(SlimePrefab, StartRock.transform.position, Slimes[0].GetComponent<Slime>().StartRock[0].transform.rotation);
                    //GameObject NewSlime = Instantiate(SlimePrefab, Slimes[0].GetComponent<Slime>().StartRock[0].transform.position, Slimes[0].GetComponent<Slime>().StartRock[0].transform.rotation);
                    //GameObject NewSlime = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "GreenSlime"), StartRock.transform.position, Quaternion.identity);//params(file location for photon plyaer prefab,position to start, rotation)
                    Destroy(NewSlime.GetComponent<PhotonView>());
                    var newSlime = NewSlime.GetComponent<Slime>();
                    TotalSlimesSpawned++;
                    newSlime.InitNewSlime(playerNum, Slimes.Count, TotalSlimesSpawned);
                    Debug.Log(NewSlime.GetComponent<PhotonView>().ViewID);
                    Slimes.Add(NewSlime);
                    SlimesSpawned++;
                }

               
            }
            
 
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

            stream.SendNext(PTurn);
           
        }
        else
        {
            PTurn = (bool)stream.ReceiveNext();
            
        }
    }

}
