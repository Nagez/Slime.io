using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeScript : MonoBehaviour
{
    int testnum = 3333;
    //public GameObject SlimePrefab;
    //public GameObject num1;
    //public GameObject position0;

    public Sprite[] dicesides;//Dice images
    public List<int> results;//Dice results max 5
    private SpriteRenderer rend;//to change sides of dice images
    public GameObject CubeArray;


    //private int whosTurn = 1;//who play-כהתחלה 1 הוא משתמש 1
    //private int numOfPlayers;

    public bool coroutineAllowed = false;

    

    //public Sprite[] NumSides;

    private SpriteRenderer rendSquare;//to add image of num in the arrRes
    private void Start()
    {
        results = new List<int>();
        rend = GetComponent<SpriteRenderer>();
        dicesides = Resources.LoadAll<Sprite>("dice/");

        //NumSides = Resources.LoadAll<Sprite>("NumRes/");
        //for (int i = 0; i < 5; i++) { Debug.Log(dicesides[i]); }
        //rend.sprite = dicesides[1];//to be in the begining of the game the num 2 n th dice side
    }

    private void OnMouseDown()
    {
        //rend.sprite = dicesides[1];//to be in the begining of the game the num 2 n th dice side
        //if (!game.gameOver && coroutineAllowed)
        if (coroutineAllowed)
        {
            StartCoroutine("RollTheDice");//אם המשחק לא נגמר  אז זורקים קוביה מפעלים פונקציה
            
        }
        //testnum = 555;
        //Debug.Log(testnum.ToString());
        
        
        //updateArr(results);
        
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
            //To array


            //rendSquare.sprite = NumSides[randomDiceSide];
            // numofThrown++;
        }
        
        this.gameObject.SetActive(false);
        //foreach (var x in results)//לראות את הlist
        //{
        //    Debug.Log(x.ToString());
        //}

        //Debug.Log(testnum.ToString());
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

    public void AddImageToArray(List<int> results,int Num)
    { 
        CubeArray.GetComponent<CubeArrayPosition>().ArStepNums[Num].GetComponent<SpriteRenderer>().sprite = dicesides[results[Num]-1];
        CubeArray.GetComponent<CubeArrayPosition>().ArStepNums[Num].GetComponent<ClickOnCube>().inumberStep = results[Num];
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


    //No need
    private IEnumerator updateArr(List<int> results)
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

        //List<int> result;

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


