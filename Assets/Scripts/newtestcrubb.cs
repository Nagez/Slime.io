using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newtestcrubb : MonoBehaviour
{
    private Sprite[] dicesides;
    private List<int> results;
    private SpriteRenderer rend;//to change sides of dice images
    //private int whosTurn = 1;//who play-������ 1 ��� ����� 1
    //private int numOfPlayers;
    private bool coroutineAllowed = true;
    private void Start()
    {
        results = new List<int>();
        rend = GetComponent<SpriteRenderer>();
        dicesides = Resources.LoadAll<Sprite>("dice/");
        //for (int i = 0; i < 5; i++) { Debug.Log(dicesides[i]); }
        rend.sprite = dicesides[1];//to be in the begining of the game the num 2 n th dice side
    }

    private void OnMouseDown()
    {

        //if (!game.gameOver && coroutineAllowed)
        if (coroutineAllowed)
        {
            StartCoroutine("RollTheDice");//�� ����� �� ����  �� ������ ����� ������ �������
        }

    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        int numofThrown = 0;

        while (randomDiceSide != 1 && randomDiceSide != 2 && randomDiceSide != 3)
        {
            for (int i = 0; i <= 20; i++)
            {
                //randomDiceSide = Random.Range(0, 5);//���� ������ calcDiceResult=====����� ���� �����
                randomDiceSide = calcDiceResult();
                rend.sprite = dicesides[randomDiceSide-1];//the new side on dice(�����)
                //Debug.Log("pressed");
                yield return new WaitForSeconds(0.05f);//?
            }
            results.Add(randomDiceSide); //array of results
            // numofThrown++;
        }
       foreach( var x in results) {
        Debug.Log( x.ToString());
       }

       //Alinas Code
        
        //GameObject.Find("GreenSlime").GetComponent<keyMove>().DiceMoves = results.ToArray();
        

    }
    //function for calculating the result of the dice with precentages
    public int calcDiceResult()
    {
        int res;
        res = Random.Range(1, 101);
        if (res <= 19) { res = 1; } //19% chance for 1 trough 5 result
        if (res >= 20 && res <= 38) { res = 2; }
        if (res >= 39 && res <= 57) { res = 3; }
        if (res >= 58 && res <= 76) { res = 4; }
        if (res >= 77 && res <= 95) { res = 5; }
        if (res >= 96) { res = 6; } //5% chance to get a 6
        
        return res;//��� ����� ������ �� ������ ���� ����� ��� ������
    }

}


