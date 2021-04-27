using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject[] Slimes;
    public int[] DiceMoves = new int[5];
    public bool PTurn = false;
    public bool FirstMove = false;

    // Start is called before the first frame update
    void Start()
    {
        //Slimes[0].GetComponent<keyMove>().moveAllowed = false;
        //GameControl.MovePlayer(1);
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
                DiceMoves[0] = AlinasDice.randomDiceSide;//wont do 0
            }
           


            //Pick The Slime
            //Enable Click only on players Slimes

            //Spwns


            //IsStagnant();
            //if (!transform.hasChanged)
            //{
            //    GameControl.WhoTurnItIs(GameObject.Find("dice6").GetComponent<AlinasDice>().whosTurn);
            //}

            if ((DiceMoves[0] == 0) && (FirstMove == true))
            {
                PTurn = false;
                //whosTurn();
                GameControl.turnSwitch();
                FirstMove = false;
            }
        }
    }
}
