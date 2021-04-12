using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyMove : MonoBehaviour
{
    public Transform[] StartRock;
    public Transform[] MainPath;
    public Transform[] Path1;

    int FrogPosition = 0;
    bool FirstRollMove = true;
    int Path = 0;//0 main,1 pr, 2 pl, 3 pm

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] public int DiceNum = 0;

    [HideInInspector]
    public int RockNumber = 0;
    public bool moveAllowed = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = MainPath[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
        {
            moveFrog(DiceNum);
        }
    }

    void moveFrog(int DiceRoll)
    {
        if (DiceRoll > 0)//3
        {
            //if(FrogPosition==28)
            //{
            //    FrogPosition = 0;
            //}
            int newRock = FrogPosition + 1;

            //switch (Path)
            //{
            //    case 0:
            //        transform.position = Vector3.MoveTowards(transform.position, MainPath[newRock].transform.position, moveSpeed * Time.deltaTime);
            //        break;
            //    case 1:
            //        transform.position = Vector3.MoveTowards(transform.position, MainPath[newRock].transform.position, moveSpeed * Time.deltaTime);
            //        break;
            //    case 2:

            //        break;
            //    case 3:

            //        break;
            //}

            transform.position = Vector3.MoveTowards(transform.position, MainPath[newRock].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == MainPath[newRock].transform.position)
            {
                DiceNum--;
                FrogPosition++;

                //First Path
                //out
                if ((FrogPosition == 5) && (DiceNum == 0))
                {
                    FrogPosition = 19;
                    
                }

                //Secend Path
                //out
                else if ((FrogPosition == 10) && (DiceNum == 0))
                {
                    FrogPosition = 24;
                }

                //Third Path
                //out
                else if((FrogPosition == 15) && (DiceNum == 0))//delet 15
                {
                    FrogPosition = 15;
                }
                //in
                else if((FrogPosition == 24) )
                {
                    FrogPosition = 14;
                }

                //Fourth Path
                //out
                else if((FrogPosition == 22) && (DiceNum == 0))
                {
                    FrogPosition = 26;
                }
                //in
                else if((FrogPosition == 21) || (FrogPosition == 26))//delet 21
                {
                    FrogPosition = 21;
                }
                //End
                else if((FrogPosition == 19) || (FrogPosition == 28))
                {
                    FrogPosition = -1;
                }


            }


        }

        FirstRollMove = false;
    }
    
}
