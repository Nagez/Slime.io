using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class newtestcrubb : MonoBehaviour
{
    int testnum = 3333;
    public GameObject SlimePrefab;
    public GameObject num1;
    //public GameObject num2;
    //public GameObject num3;
    //public GameObject num4;
    //public GameObject num5;
    //public GameObject num6;
    public GameObject position0;
    private Sprite[] dicesides;
    private List<int> results;
    private SpriteRenderer rend;//to change sides of dice images
    //private int whosTurn = 1;//who play-כהתחלה 1 הוא משתמש 1
    //private int numOfPlayers;
    private bool coroutineAllowed = true;
    private Sprite[] NumSides;
    private SpriteRenderer rendSquare;//to add image of num in the arrRes
    private void Start()
    {
        results = new List<int>();
        rend = GetComponent<SpriteRenderer>();
        dicesides = Resources.LoadAll<Sprite>("dice/");
        NumSides = Resources.LoadAll<Sprite>("NumRes/");
        //for (int i = 0; i < 5; i++) { Debug.Log(dicesides[i]); }
        //rend.sprite = dicesides[1];//to be in the begining of the game the num 2 n th dice side
    }

    private void OnMouseDown()
    {
        rend.sprite = dicesides[1];//to be in the begining of the game the num 2 n th dice side
        //if (!game.gameOver && coroutineAllowed)
        if (coroutineAllowed)
        {
            StartCoroutine("RollTheDice");//אם המשחק לא נגמר  אז זורקים קוביה מפעלים פונקציה
        }
        //testnum = 555;
        //Debug.Log(testnum.ToString());
        results.Add(4);
        results.Add(1);
        updateArr(results);
        
    }


    private void Instantiate(int v, Vector3 position, Quaternion rotation)
    {
        throw new NotImplementedException();
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
                //randomDiceSide = Random.Range(0, 5);//צריך להכניס calcDiceResult=====בחירת מספר אקראי
                randomDiceSide = calcDiceResult();
                rend.sprite = dicesides[randomDiceSide - 1];//the new side on dice(קוביה)
                //results.Add(randomDiceSide); //array of results

                //rendSquare.sprite = NumSides[randomDiceSide];
                //Debug.Log("pressed");
                yield return new WaitForSeconds(0.05f);//?
            }
             results.Add(randomDiceSide); //array of results
            // numofThrown++;
        }
        foreach (var x in results)//לראות את הlist
        {
            Debug.Log(x.ToString());
        }

        Debug.Log(testnum.ToString());
       // updateArr(results);

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
    private IEnumerator updateArr(List<int>results)
    {
        testnum = 6666;
        Debug.Log(testnum.ToString());

        //float x1 = -6;
        //float y1 = -6;
        //float z1 = 0;
        //float x2 = 1.05;
        //float y2 = 0;
        //float z2 = 0;
        //float x3 = 2.1;
        //float y3 = 0.0017;
        //float z3 = 0;
        //float x4 = 3.16;
        //float y4 = -0.02;
        //float z4 = 0;
        //float x5 = 4.28;
        //float y5 = -0.01;
        //float z5 = 0;
        //int j = 0;
        //int num = 0;//if there is num on the list
        //for (int i = 0; i < 5; i++)
        //{
        //    results.RemoveAt(i);
        //    num = results.Count;//number in the list
        //    if (num !=0)//is not the end of list
        //    {
        //        j++;//to know for who place to ad the num in the array
        //        if (j == 1)
        //        {
        //            if (results[i] == 1)
        //            {
        //               // position0.transform.position.Set(x1, y1, z1);
        //                Instantiate(SlimePrefab, position0.transform.position, position0.transform.rotation);
        //            }
        //            else
        //            {
        //                if (results[i] == 2)
        //                {
        //                    //position0.transform.position.Set(x1, y1, z1);
        //                    Instantiate(SlimePrefab, position0.transform.position, position0.transform.rotation);
        //                }
        //                else
        //                {
        //                    if (results[i] == 3)
        //                    {
        //                       // position0.transform.position.Set(x1, y1, z1);
        //                        Instantiate(num3, position0.transform.position, position0.transform.rotation);
        //                    }
        //                    else
        //                    {
        //                        if (results[i] == 4)
        //                        {
        //                           // position0.transform.position.Set(x1, y1, z1);
        //                            Instantiate(num4, position0.transform.position, position0.transform.rotation);
        //                        }
        //                        else
        //                        {
        //                            if (results[i] == 5)
        //                            {
        //                                position0.transform.position.Set(x1, y1, z1);
        //                                Instantiate(num5, position0.transform.position, position0.transform.rotation);
        //                            }
        //                            else
        //                            {
        //                                if (results[i] == 6)
        //                                {
        //                                    position0.transform.position.Set(x1, y1, z1);
        //                                    Instantiate(num6, position0.transform.position, position0.transform.rotation);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if (j == 1)
        //        {
        //            if (results[i] == 1)
        //            {
        //                position0.transform.position.Set(x2, y2, z2);
        //                Instantiate(num1, position0.transform.position, position0.transform.rotation);
        //            }
        //            else
        //            {
        //                if (results[i] == 2)
        //                {
        //                    position0.transform.position.Set(x2, y2, z2);
        //                    Instantiate(num2, position0.transform.position, position0.transform.rotation);
        //                }
        //                else
        //                {
        //                    if (results[i] == 3)
        //                    {
        //                        position0.transform.position.Set(x2, y2, z2);
        //                        Instantiate(num3, position0.transform.position, position0.transform.rotation);
        //                    }
        //                    else
        //                    {
        //                        if (results[i] == 4)
        //                        {
        //                            position0.transform.position.Set(x2, y2, z2);
        //                            Instantiate(num4, position0.transform.position, position0.transform.rotation);
        //                        }
        //                        else
        //                        {
        //                            if (results[i] == 5)
        //                            {
        //                                position0.transform.position.Set(x2, y2, z2);
        //                                Instantiate(num5, position0.transform.position, position0.transform.rotation);
        //                            }
        //                            else
        //                            {
        //                                if (results[i] == 6)
        //                                {
        //                                    position0.transform.position.Set(x2, y2, z2);
        //                                    Instantiate(num6, position0.transform.position, position0.transform.rotation);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (j == 1)
        //        {
        //            if (results[i] == 1)
        //            {
        //                position0.transform.position.Set(x3, y3, z3);
        //                Instantiate(num1, position0.transform.position, position0.transform.rotation);
        //            }
        //            else
        //            {
        //                if (results[i] == 2)
        //                {
        //                    position0.transform.position.Set(x3, y3, z3);
        //                    Instantiate(num2, position0.transform.position, position0.transform.rotation);
        //                }
        //                else
        //                {
        //                    if (results[i] == 3)
        //                    {
        //                        position0.transform.position.Set(x3, y3, z3);
        //                        Instantiate(num3, position0.transform.position, position0.transform.rotation);
        //                    }
        //                    else
        //                    {
        //                        if (results[i] == 4)
        //                        {
        //                            position0.transform.position.Set(x3, y3, z3);
        //                            Instantiate(num4, position0.transform.position, position0.transform.rotation);
        //                        }
        //                        else
        //                        {
        //                            if (results[i] == 5)
        //                            {
        //                                position0.transform.position.Set(x3, y3, z3);
        //                                Instantiate(num5, position0.transform.position, position0.transform.rotation);
        //                            }
        //                            else
        //                            {
        //                                if (results[i] == 6)
        //                                {
        //                                    position0.transform.position.Set(x3, y3, z3);
        //                                    Instantiate(num6, position0.transform.position, position0.transform.rotation);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (j == 1)
        //        {
        //            if (results[i] == 1)
        //            {
        //                position0.transform.position.Set(x4, y4, z4);
        //                Instantiate(num1, position0.transform.position, position0.transform.rotation);
        //            }
        //            else
        //            {
        //                if (results[i] == 2)
        //                {
        //                    position0.transform.position.Set(x4, y4, z4);
        //                    Instantiate(num2, position0.transform.position, position0.transform.rotation);
        //                }
        //                else
        //                {
        //                    if (results[i] == 3)
        //                    {
        //                        position0.transform.position.Set(x4, y4, z4);
        //                        Instantiate(num3, position0.transform.position, position0.transform.rotation);
        //                    }
        //                    else
        //                    {
        //                        if (results[i] == 4)
        //                        {
        //                            position0.transform.position.Set(x4, y4, z4);
        //                            Instantiate(num4, position0.transform.position, position0.transform.rotation);
        //                        }
        //                        else
        //                        {
        //                            if (results[i] == 5)
        //                            {
        //                                position0.transform.position.Set(x4, y4, z4);
        //                                Instantiate(num5, position0.transform.position, position0.transform.rotation);
        //                            }
        //                            else
        //                            {
        //                                if (results[i] == 6)
        //                                {
        //                                    position0.transform.position.Set(x4, y4, z4);
        //                                    Instantiate(num6, position0.transform.position, position0.transform.rotation);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (j == 1)
        //        {
        //            if (results[i] == 1)
        //            {
        //                position0.transform.position.Set(x5, y5, z5);
        //                Instantiate(num1, position0.transform.position, position0.transform.rotation);
        //            }
        //            else
        //            {
        //                if (results[i] == 2)
        //                {
        //                    position0.transform.position.Set(x5, y5, z5);
        //                    Instantiate(num2, position0.transform.position, position0.transform.rotation);
        //                }
        //                else
        //                {
        //                    if (results[i] == 3)
        //                    {
        //                        position0.transform.position.Set(x5, y5, z5);
        //                        Instantiate(num3, position0.transform.position, position0.transform.rotation);
        //                    }
        //                    else
        //                    {
        //                        if (results[i] == 4)
        //                        {
        //                            position0.transform.position.Set(x5, y5, z5);
        //                            Instantiate(num4, position0.transform.position, position0.transform.rotation);
        //                        }
        //                        else
        //                        {
        //                            if (results[i] == 5)
        //                            {
        //                                position0.transform.position.Set(x5, y5, z5);
        //                                Instantiate(num5, position0.transform.position, position0.transform.rotation);
        //                            }
        //                            else
        //                            {
        //                                if (results[i] == 6)
        //                                {
        //                                    position0.transform.position.Set(x5, y5, z5);
        //                                    Instantiate(num6, position0.transform.position, position0.transform.rotation);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
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
                    Instantiate(SlimePrefab, position0.transform.position, position0.transform.rotation);
                    if (results[i] == 1)
                    {
                        Instantiate(num1, position0.transform.position, position0.transform.rotation);
                    }

                }
                yield return new WaitForSeconds(0.05f);

            }
        }
       
    }
    public int ChooseNumSteps(List<int> results,int Placenumber)//קריאה לפונקציה מסקריבת חדש בפונקציה שךו onMouse
    {
        int numSteps;
        results.RemoveAt(Placenumber);
        numSteps = results.Count;
        return numSteps;
    }
    public IEnumerator DeletNumStepsFommArr(List<int> results, int Placenumber)//קריאה לפונקציה מסקריבת חדש בפונקציה שךו onMouse
    {
        int numSteps;
        results.RemoveAt(Placenumber);
        numSteps = results.Count;
        updateArr(results);
        yield return new WaitForSeconds(0.05f);//?
    }
}


