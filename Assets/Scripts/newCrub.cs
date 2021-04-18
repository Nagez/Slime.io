using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newnumstep : MonoBehaviour
{
    private Sprite[] dicesides;
    private int[] results;
    private SpriteRenderer rend;//to change sides of dice images
    private int whosTurn = 1;//who play-������ 1 ��� ����� 1
    private int numOfPlayers;
    private bool coroutineAllowed = true;

    public static int res;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        dicesides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = dicesides[5];//to be in the begining of the game the num 6 n th dice side
    }
    private void onMouseDown() //2Dcollider needed for that
    {
        if (!game.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");//�� ����� �� ����  �� ������ ����� ������ �������
    }
    
    private IEnumerator RollThDice() 
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        int numofThrown = 0;
        while (randomDiceSide != 1 && randomDiceSide != 2 && randomDiceSide != 3)
        {
            for (int i = 0; i <= 20; i++) 
            {
                randomDiceSide = Random.Range(0, 6);//����� ���� �����
                results[numofThrown] = randomDiceSide;
                numofThrown++;
                //rend.sprite = dicesides[randomDiceSide];//the new side on dice(�����)
                yield return new WaitForSeconds(0.05f);//?

            }
        }
        /*
        for(int i=0;i<=numofThrown;i++)
        {
            //game.diceSideThrown = randomDiceSide + 1;
            if (whosTurn == 1)
            {
                game.MovePlayer(1);
            }
            else if (whosTurn == -1)
            {
                game.MovePlayer(2);
            }
        }
        */
        whosTurn *= -1;
        coroutineAllowed = true;
    }

    //function for calculating the result of the dice with precentages
    public int calcDiceResult()
    {        
        res = Random.Range(1, 100);
        if (res <= 19) { res = 1; } //19% chance for 1 trough 5 result
        if (res >= 20 && res <= 38) { res = 2; } 
        if (res >= 39 && res <= 57) { res = 3; }
        if (res >= 58 && res <= 76) { res = 4; }
        if (res >= 77 && res <= 95) { res = 5; }
        if (res <= 96) { res = 6; } //5% chance to get a 6

        return res;
    }

 }

