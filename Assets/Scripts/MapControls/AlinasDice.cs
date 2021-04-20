using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlinasDice : MonoBehaviour
{
    public int randomDiceSide=0;
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public int whosTurn = 1;
    private bool coroutineAllowed = true;

    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<SpriteRenderer>();
        //diceSides = Resources.LoadAll<Sprite>("dice/");
        //rend.sprite = diceSides[5];
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
            RollTheDice();
    }

    public void RollTheDice()
    {
        coroutineAllowed = false;
        
        randomDiceSide = Random.Range(1, 6);

        if(whosTurn == 1)
        {
            GameControl.MovePlayer(1);
            whosTurn = 2;
            GameObject.Find("GreenSlime").GetComponent<keyMove>().DiceNum = randomDiceSide;
        }
        else if (whosTurn == 2)
        {
            GameControl.MovePlayer(2);
            whosTurn = 3;
            GameObject.Find("BlueSlime").GetComponent<keyMove>().DiceNum = randomDiceSide;
        }
        else if(whosTurn == 3)
        {
            GameControl.MovePlayer(3);
            whosTurn = 4;
            GameObject.Find("RedSlime").GetComponent<keyMove>().DiceNum = randomDiceSide;
        }
        else if(whosTurn == 4)
        {
            GameControl.MovePlayer(4);
            whosTurn = 1;
            GameObject.Find("YellowSlime").GetComponent<keyMove>().DiceNum = randomDiceSide;
        }

        coroutineAllowed = true;

        Debug.Log(randomDiceSide);
        


    }

    
}
