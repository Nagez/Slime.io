using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public int SlimesPerPlayer = 1;
    public int PlayersAmount = 0;

    private static GameObject PlayerMoving, Player1Move, Player2Move, Player3Move, Player4Move;
    private static GameObject Player1, Player2, Player3, Player4;
    private static GameObject TextGreen, TextBlue, TextRed, TextYellow;

    public static int player1Rock = 0, player2Rock = 0;

    public static int whosTurn = 1;

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
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        Player3 = GameObject.Find("Player3");
        Player4 = GameObject.Find("Player4");

        //Playes moving

        Player1.GetComponent<PlayerScript>().PTurn = false;
        Player2.GetComponent<PlayerScript>().PTurn = false;
        Player3.GetComponent<PlayerScript>().PTurn = false;
        Player4.GetComponent<PlayerScript>().PTurn = false;

        TextGreen.gameObject.SetActive(false);
        TextBlue.gameObject.SetActive(false);
        TextRed.gameObject.SetActive(false);
        TextYellow.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(whosTurn);
    }

    public static void MovePlayer(int PlayerMoving)
    {
        TextGreen.gameObject.SetActive(false);
        TextBlue.gameObject.SetActive(false);
        TextRed.gameObject.SetActive(false);
        TextYellow.gameObject.SetActive(false);

        switch (PlayerMoving)
        {
            case 1:
                Player1.GetComponent<PlayerScript>().PTurn = true;
                TextGreen.gameObject.SetActive(true);
                break;
            case 2:
                Player2.GetComponent<PlayerScript>().PTurn = true;
                TextBlue.gameObject.SetActive(true);
                break;
            case 3:
                Player3.GetComponent<PlayerScript>().PTurn = true;
                TextRed.gameObject.SetActive(true);
                break;
            case 4:
                Player4.GetComponent<PlayerScript>().PTurn = true;
                TextYellow.gameObject.SetActive(true);
                break;

        }
    }
    public static void turnSwitch()
    {
        if (whosTurn < 4)
            whosTurn++;
        else
            whosTurn = 1;
    }


}