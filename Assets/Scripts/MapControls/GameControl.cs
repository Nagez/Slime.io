using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurns : MonoBehaviour
{

    private static GameObject PlayerMoving, Player1Move, Player2Move, Player3Move, Player4Move;
    private static GameObject Player1, Player2, Player3, Player4;
    private static GameObject TextGreen, TextBlue;

    public static int player1Rock = 0, player2Rock = 0;

    
    /////////////////////////////////////////////////
    public static int diceSide = 0;
    public static int player1StartRock = 0;
    public static int player2StartRock = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Hows Turn
        TextGreen = GameObject.Find("TextGreen");
        TextBlue = GameObject.Find("TextBlue");
        //add red
        //add yellow

        //Players match
        Player1 = GameObject.Find("GreenSlime");
        Player2 = GameObject.Find("BlueSlime");
        Player3 = GameObject.Find("RedSlime");
        Player4 = GameObject.Find("PinkSlime");

        //Playes moving
        Player1.GetComponent<keyMove>().moveAllowed = false;
        Player2.GetComponent<keyMove>().moveAllowed = false;
        Player3.GetComponent<keyMove>().moveAllowed = false;
        Player4.GetComponent<keyMove>().moveAllowed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Player1.GetComponent<keyMove>().FrogPosition == 0)
        {
            Player1.GetComponent<keyMove>().moveAllowed = false;
            TextGreen.gameObject.SetActive(false);
            TextBlue.gameObject.SetActive(true);
            
            player1StartRock = Player1.GetComponent<keyMove>().FrogPosition;
        }
    }

    public static void MovePlayer(int PlayerMoving)
    {
        switch(PlayerMoving)
        {
            case 1:
                Player1.GetComponent<keyMove>().moveAllowed = true;
                break;
            case 2:
                Player2.GetComponent<keyMove>().moveAllowed = true;
                break;
            case 3:
                Player3.GetComponent<keyMove>().moveAllowed = true;
                break;
            case 4:
                Player4.GetComponent<keyMove>().moveAllowed = true;
                break;

        }
    }
}
