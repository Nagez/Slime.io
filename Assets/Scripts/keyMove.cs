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
    int Path = 0;

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
        if (DiceRoll > 0)
        {
            
            int newRock = FrogPosition + 1;

           
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
                
                //in
                else if((FrogPosition == 24) )
                {
                    FrogPosition = 14;
                }

                //Fourth Path
                //out
                else if((FrogPosition == 22) && (DiceNum == 0))
                {
                    FrogPosition = 27;
                }
                
                //End
                else if((FrogPosition == 19) || (FrogPosition == 29))
                {
                    FrogPosition = 29;
                }


            }

        }

        FirstRollMove = false;
    }
    
}
