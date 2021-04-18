using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    public static int diceSideThrown = 0;//num move points
    public static bool gameOver = false;
    private static GameObject player1MoveText, player2MoveText;
    private static GameObject player1, player2;
    
    void Start()
    {
        player1.GetComponent<FollwThePath>().moveAllowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void MovePlayer(int playerToMove)
    {
        switch(playerToMove)
        {
            case 1:
                player1.GetComponent<FollwThePath>().moveAllowed = true;
                break;
        }
    }
}
