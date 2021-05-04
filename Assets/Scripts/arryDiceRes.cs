//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class arryDiceRes : MonoBehaviour
//{
//    private Sprite[] NumSides;
//    private List<int> res;
//    private bool coroutineAllowed = true;
//    private int placeArr = 0;
//    private int newNum=0;
//    // Start is called before the first frame update
//    private void Start()
//    {
//        res = new List<int>();
//        NumSides = Resources.LoadAll<Sprite>("NumRes/");//הוסיף תקיה ב resourcesלתמונות המספרים

//    }
//    private void OnMouseDown()
//    {

//        if (coroutineAllowed)
//        {
//            StartCoroutine("delteNumArr");
//        }

//    }
//    // Update is called once per frame
//    private IEnumerator NumFromTheDice(int num)
//    {
//        coroutineAllowed = false;
//        int randomDiceSide = 0;
//        res.Add(num); //array of results

//    }
//    private int delteNumArr()
//    {
//        coroutineAllowed = false;
//        int randomDiceSide = 0;
//        newNum=res.Remove; //array of results

//    }
//}
