using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    private static GameObject PlayerMoving, Player1Move, Player2Move, Player3Move, Player4Move;
    private static GameObject Player1, Player2, Player3, Player4;
    private static GameObject TextGreen, TextBlue, TextRed, TextYellow;

    public static int player1Rock = 0, player2Rock = 0;

    
    /////////////////////////////////////////////////
    public static int diceSide = 0;

    public static int player1StartRock = 0;
    public static int player2StartRock = 0;
    public static int player3StartRock = 0;
    public static int player4StartRock = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Hows Turn
        TextGreen = GameObject.Find("TextGreen");
        TextBlue = GameObject.Find("TextBlue");
        TextRed = GameObject.Find("TextRed");
        TextYellow = GameObject.Find("TextYellow");

        //Players match
        Player1 = GameObject.Find("GreenSlime");
        Player2 = GameObject.Find("BlueSlime");
        Player3 = GameObject.Find("RedSlime");
        Player4 = GameObject.Find("YellowSlime");

        //Playes moving
        Player1.GetComponent<keyMove>().moveAllowed = false;
        Player2.GetComponent<keyMove>().moveAllowed = false;
        Player3.GetComponent<keyMove>().moveAllowed = false;
        Player4.GetComponent<keyMove>().moveAllowed = false;

        TextGreen.gameObject.SetActive(false);
        TextBlue.gameObject.SetActive(false);
        TextRed.gameObject.SetActive(false);
        TextYellow.gameObject.SetActive(false);

        //Player1 turn
        TextGreen.gameObject.SetActive(true);
        Player1.GetComponent<keyMove>().moveAllowed = true;


    }

    // Update is called once per frame
    void Update()
    {
        //WhoTurnItIs(GameObject.Find("dice6").GetComponent<AlinasDice>().whosTurn);
    }

    public static void MovePlayer(int PlayerMoving)
    {
        Player1.GetComponent<keyMove>().moveAllowed = false;
        Player2.GetComponent<keyMove>().moveAllowed = false;
        Player3.GetComponent<keyMove>().moveAllowed = false;
        Player4.GetComponent<keyMove>().moveAllowed = false;


        switch (PlayerMoving)
        {
            case 1:
                Player1.GetComponent<keyMove>().moveAllowed = true;
                TextGreen.gameObject.SetActive(true);
                break;
            case 2:
                Player2.GetComponent<keyMove>().moveAllowed = true;
                TextBlue.gameObject.SetActive(true);
                break;
            case 3:
                Player3.GetComponent<keyMove>().moveAllowed = true;
                TextRed.gameObject.SetActive(true);
                break;
            case 4:
                Player4.GetComponent<keyMove>().moveAllowed = true;
                TextYellow.gameObject.SetActive(true);
                break;

        }
    }

    public static void WhoTurnItIs(int whosTurn)
    {
        TextGreen.gameObject.SetActive(false);
        TextBlue.gameObject.SetActive(false);
        TextRed.gameObject.SetActive(false);
        TextYellow.gameObject.SetActive(false);

        if (whosTurn == 1)
        {
            TextGreen.gameObject.SetActive(true);

        }
        else if (whosTurn == 2)
        {
            TextBlue.gameObject.SetActive(true);

        }
        else if (whosTurn == 3)
        {
            TextRed.gameObject.SetActive(true);

        }
        else if (whosTurn == 4)
        {
            TextYellow.gameObject.SetActive(true);

        }
    }
}
