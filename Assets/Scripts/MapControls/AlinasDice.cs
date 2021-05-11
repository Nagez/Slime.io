using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlinasDice : MonoBehaviour
{
    public static int randomDiceSide=-1;
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    //public int whosTurn = 1;
    public static bool coroutineAllowed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
            RollTheDice();
    }

    public static void RollTheDice()
    {
        coroutineAllowed = false;
        
        randomDiceSide = Random.Range(1, 6);

        //coroutineAllowed = true;
        

        //GameObject.Find("Player" + GameControl.whosTurn).GetComponent<PlayerScript>().DiceMoves[0] = randomDiceSide;
        GameObject.Find("Player" + GameControl.whosTurn).GetComponent<PlayerScript>().DiceMoves[0] = randomDiceSide;
        //;
        Debug.Log(randomDiceSide);
        
    }

}
