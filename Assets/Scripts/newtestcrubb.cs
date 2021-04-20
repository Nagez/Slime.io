using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newtestcrubb : MonoBehaviour
{
    private Sprite[] dicesides;
    private int[] results;
    private SpriteRenderer rend;//to change sides of dice images
    //private int whosTurn = 1;//who play-כהתחלה 1 הוא משתמש 1
    //private int numOfPlayers;
    private bool coroutineAllowed = true;
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        dicesides = Resources.LoadAll<Sprite>("dice/");
        rend.sprite = dicesides[1];//to be in the begining of the game the num 6 n th dice side
    }

    private void OnMouseDown()
    {
        Debug.Log("pressed1");

        //if (!game.gameOver && coroutineAllowed)
        if (coroutineAllowed)
        {
            Debug.Log("pressed");
            StartCoroutine("RollTheDice");//אם המשחק לא נגמר  אז זורקים קוביה מפעלים פונקציה
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
                randomDiceSide = Random.Range(0, 6);//בחירת מספר אקראי
                rend.sprite = dicesides[randomDiceSide];//the new side on dice(קוביה)
                yield return new WaitForSeconds(0.05f);//?
            }
            results[numofThrown] = randomDiceSide; //array of results
            numofThrown++;
        }
    }
}