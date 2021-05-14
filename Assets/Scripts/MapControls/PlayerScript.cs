using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public List<GameObject> Slimes = new List<GameObject>();
    public int SlimesPerTPlayer;//slime lives per player
    public int playerNum;//player ID //player1

    //public int[] DiceMoves = new int[5];
    public bool PTurn = false;//player turn
    public bool FirstMove = false;

    public GameObject GameControlPlayer;

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
        if (GamePrefrences.instance) //take from lobby
        {
            SlimesPerTPlayer = GamePrefrences.instance.numberOfSlimes;
        }
        else //take from gamecontrol
        {
            SlimesPerTPlayer = GameControlPlayer.GetComponent<GameControl>().SlimesPerPlayer;
        }
    }

    void PlayersTurn(bool moveAllowed)
    {
        if (moveAllowed)
        {
            
            if(FirstMove==false)
            {
                
            }

            SlimeSpawnNeeded();

        }
    }
    
    public void SlimeSpawnNeeded()
    {
        if (Slimes.Count < SlimesPerTPlayer)
        {
            bool SlimeE = false;
            int slimeCount = 0;
            for (int i = 0; i < this.Slimes.Count; i++)
            {
                if (this.Slimes[i].GetComponent<Slime>().PlayerPosition == 0)
                    SlimeE = true;
                slimeCount= slimeCount+this.Slimes[i].GetComponent<Slime>().slimeLevel;
            }

            if (!SlimeE && (slimeCount<=5))
            {
                GameObject NewSlime = Instantiate(Slimes[0], Slimes[0].GetComponent<Slime>().StartRock[0].transform.position, Slimes[0].GetComponent<Slime>().StartRock[0].transform.rotation);
                var newSlime=NewSlime.GetComponent<Slime>();
                newSlime.InitNewSlime(playerNum, Slimes.Count);
                Slimes.Add(NewSlime);

            }
            
 
        }
    }

    
}
