using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public List<GameObject> Slimes = new List<GameObject>();
    //public GameObject[] Slimes=new GameObject[5];
    public int SlimesPerTPlayer = 0;//slime lives per player
    public int playerNum;//player ID //player1

    public int[] DiceMoves = new int[5];
    public bool PTurn = false;//player turn
    public bool FirstMove = false;

    public GameObject GameControlPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //locate Slimes per player
        //add function

        //GameObject GameControlPlayer = GameObject.Find("GameControls");
        SlimesPerTPlayer = GameControlPlayer.GetComponent<GameControl>().SlimesPerPlayer;
    }
    // Update is called once per frame
    void Update()
    {
        if(PTurn)
        {
            PlayersTurn(PTurn); 
        } 
    }

    void PlayersTurn(bool moveAllowed)
    {
        if (moveAllowed)
        {
            //DiceAllowed
            AlinasDice.coroutineAllowed = true;
            //Dice Rolls

            //dice pick
            if(FirstMove==false)
            {
                //DiceMoves[0] = AlinasDice.randomDiceSide;//wont do 0
            }
           
            //Pick The Slime
            //Enable Click only on players Slimes

            if ((DiceMoves[0] == -1) && (FirstMove == true))
            {
                PTurn = false;
                //whosTurn();

                
                GameControl.turnSwitch();

                FirstMove = false;
                SlimeSpawnNeeded();
            }
        }
    }

    void SlimeSpawnNeeded()
    {
        //add collishion check
        //if (Slimes.Length < SlimesPerTPlayer)
        if (Slimes.Count < SlimesPerTPlayer)
        {
            //add slime detector 
            if(true)
            { 

            }
            GameObject NewSlime = Instantiate(Slimes[0], Slimes[0].GetComponent<keyMove>().StartRock[0].transform.position, Slimes[0].GetComponent<keyMove>().StartRock[0].transform.rotation);
            NewSlime.transform.parent = GameObject.Find("Player"+ playerNum).transform;
            NewSlime.GetComponent<keyMove>().PlayerPosition = 0;
            Slimes.Add(NewSlime);
            
            Debug.Log("spawned2");
        }
    }
}
