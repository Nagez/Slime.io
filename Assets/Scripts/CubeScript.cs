using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeScript : MonoBehaviour
{

    public Sprite[] dicesides;//Dice images
    public List<int> results;//Dice results max 5
    private SpriteRenderer rend;//to change sides of dice images
    public GameObject CubeArray;
    public bool cubeStopedRoll = true;
    public int randomDiceSide = 0;
    public int numofThrown = 0;

    public bool coroutineAllowed = false;

    private SpriteRenderer rendSquare;//to add image of num in the arrRes
    private void Start()
    {
        results = new List<int>();
        rend = GetComponent<SpriteRenderer>();
        dicesides = Resources.LoadAll<Sprite>("dice/");

    }

    private void OnMouseDown()
    {

        if (coroutineAllowed)
        {
            
            StartCoroutine("RollTheDice");//אם המשחק לא נגמר  אז זורקים קוביה מפעלים פונקציה
            
        }
    }

    private IEnumerator RollTheDice()
    {
        cubeStopedRoll = false;
        coroutineAllowed = false;
        randomDiceSide = 0;
        numofThrown = 0;
        
        while (((randomDiceSide > 3) || (randomDiceSide == 0 && results.Count == 0)) && (results.Count<5))
        {
            for (int i = 0; i <= 20; i++)
            {
                randomDiceSide = calcDiceResult();
                rend.sprite = dicesides[randomDiceSide - 1];//the new side on dice(קוביה)//PICTER
                yield return new WaitForSeconds(0.05f);//time pause
            }
            results.Add(randomDiceSide); //array of results
            Debug.Log(randomDiceSide);
            AddImageToArray(results, numofThrown);
            numofThrown++;
        }
        
        GameObject GameAB = GameObject.Find("GameControls");
        for (int i = 0; i < results.Count; i++)
        {
            GameAB.GetComponent<GameControl>().DiceMoves[i] = results[i];
        }
        results.Clear();
        cubeStopedRoll = true;
    }
    //function for calculating the result of the dice with precentages
    public int calcDiceResult()
    {
        int res;
        res = UnityEngine.Random.Range(1, 101);
        if (res <= 19) { res = 1; } //19% chance for 1 trough 5 result
        if (res >= 20 && res <= 38) { res = 2; }
        if (res >= 39 && res <= 57) { res = 3; }
        if (res >= 58 && res <= 76) { res = 4; }
        if (res >= 77 && res <= 95) { res = 5; }
        if (res >= 96) { res = 6; } //5% chance to get a 6
        return res;//הוא המספר שמופיע על הקוביה אחרי לחיצה לפי אחוזים
    }

    public void AddImageToArray(List<int> results,int Num)
    { 
        CubeArray.GetComponent<CubeArrayPosition>().ArStepNums[Num].GetComponent<SpriteRenderer>().sprite = dicesides[results[Num]-1];
        CubeArray.GetComponent<CubeArrayPosition>().ArStepNums[Num].GetComponent<ClickOnCube>().inumberStep = results[Num];
    }
    public void resetToAddImageToArray()
    {
        for(int i=0;i<results.Count;i++)
        CubeArray.GetComponent<CubeArrayPosition>().ArStepNums[i].GetComponent<SpriteRenderer>().sprite = dicesides[results[i+1] - 1];
    }

    public int ChooseNumSteps(List<int> results)//קריאה לפונקציה מסקריבת חדש בפונקציה שךו onMouse
    {
        int numSteps;
        //results.RemoveAt();
        numSteps = results.Count;
        return numSteps;
    }
    public void DeletNumStepsFommArr()//קריאה לפונקציה מסקריבת חדש בפונקציה שךו onMouse
    {
        int numSteps;
        //results.RemoveAt();
        numSteps = results.Count;
        updateArr(results);
        
    }

    private IEnumerator updateArr(List<int> results)
    {
        List<int> ListNumStep;
        int j = 0;
        int num = 0;//if there is num on the list
        for (int i = 0; i < 5; i++)
        {
            results.RemoveAt(i);
            num = results.Count;//number in the list
            ListNumStep = new List<int>();
            ListNumStep.Add(num);
            if (num != 0)//is not the end of list
            {
                j++;//to know for who place to ad the num in the array
                if (j == 1)
                {
                    //Instantiate(SlimePrefab, position0.transform.position, position0.transform.rotation);
                    if (results[i] == 1)
                    {
                        // Instantiate(num1, position0.transform.position, position0.transform.rotation);
                    }

                }
                yield return new WaitForSeconds(0.05f);

            }
        }

    }
    
}


