using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newnumstep : MonoBehaviour
{
    private Sprite[] dicesides;
    private SpriteRenderer rend;//to change sides of dice images
    private int whosTurn = 1;//who play-כהתחלה 1 הוא משתמש 1
    private bool coroutineAllowed = true;
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        dicesides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = dicesides[5];//to be in the begining of the game the num 6 n th dice side
    }
    private void onMouseDown()
    {
        if (!game.gameOver && coroutineAllowed)
            StrartCoroutine("RollTheDice");//אם המשחק לא נגמר  אז זורקים קוביה
    }
    private IEnumerator RollThDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);//בחירת מספר אקראי
            rend.sprite = dicesides[randomDiceSide];//the new side on dice(קוביה)
            yield return new WaitForSECONDS(0.05f);

        }
        game.diceSideThrown = randomDiceSide + 1;
        if (whosTurn == 1)
        {
            game.MovePlayer(1);
        }else if(whosTurn==-1)
        {
            game.MovePlayer(2);
        }
        whosTurn *= -1;
        coroutineAllowed = true;
    }
}

