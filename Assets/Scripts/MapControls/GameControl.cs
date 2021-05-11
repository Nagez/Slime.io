using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public int SlimesPerPlayer = 1;
    public int PlayersAmount = 3;
    public List<GameObject> Players = new List<GameObject>();

    private static GameObject PlayerMoving, Player1Move, Player2Move, Player3Move, Player4Move;//not using
    private static GameObject Player1, Player2, Player3, Player4;
    private static GameObject TextGreen, TextBlue, TextRed, TextYellow;//Playes turn text in hud

    public static int player1Rock = 0, player2Rock = 0; //not using

    public static int whosTurn = 1;
    public int whosTurnT = 1;
    /////////////////////////////////////////////////
    public static int diceSide = 0;//check if using

    //player element 0 start
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
        Player1 = GameObject.Find("Player1");//can be problem
        Player2 = GameObject.Find("Player2");
        Player3 = GameObject.Find("Player3");
        Player4 = GameObject.Find("Player4");

        //off turn text
        TextGreen.gameObject.SetActive(false);
        TextBlue.gameObject.SetActive(false);
        TextRed.gameObject.SetActive(false);
        TextYellow.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //MovePlayer(whosTurn);
        MovePlayer(whosTurnT);
    }

    public static void MovePlayer(int whosTurnN)
    {
        TextGreen.gameObject.SetActive(false);
        TextBlue.gameObject.SetActive(false);
        TextRed.gameObject.SetActive(false);
        TextYellow.gameObject.SetActive(false);

        switch (whosTurnN)
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

    //not in use
    public static void turnSwitch()
    {
        if (whosTurn < 4)
            whosTurn++;
        else
            whosTurn = 1;
    }

    public void SwitchTurns()
    {
        if (whosTurnT < PlayersAmount)
            whosTurnT++;
        else
            whosTurnT = 1;

        whosTurn = whosTurnT;
    }

}
