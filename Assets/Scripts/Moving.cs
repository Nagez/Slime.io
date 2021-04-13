using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    int StartWin = 0;
    int FrogPosition = 0;
    bool arrived = false;
    Vector3 RockPosition;
    Collider2D colliderFrog;
    Rigidbody2D rigidbody2D;

    
    public Transform[] StartRock;

    public Transform[] MainPath;

    public Transform[] PathRocks;

    public Transform[] Path1;

    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private int DiceNum = 3;


    [HideInInspector]
    public int RockNumber = 0;

    public bool moveAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartRock[0].transform.position;
        //transform.position = Rocks[waypointIndex].transform.position;//first waypoint
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
        {
            moveFrog(DiceNum);
            
        }
            
    }

    void MoveC(int DiceNum, int Dicenum)
    {
        if( Dicenum <= DiceNum) 
        {
           
            transform.position = Vector2.MoveTowards(transform.position, MainPath[Dicenum].transform.position, moveSpeed * Time.deltaTime);//The moving to new position

            if (transform.position == MainPath[Dicenum].transform.position)//when on the same position
            {
                RockNumber += 1;
            }
            if((transform.position == PathRocks[0].transform.position)&&(Dicenum == DiceNum))
            {
                RockNumber += 1;
            }
        }

        //Check if on banch ->move to start button

        //from starting point -> Rock 0

        //Rock 3 -> path1

        //path 1-> Rock 16

    }

    void moveFrog(int DiceRoll)
    {
        if (DiceRoll>0)//3
        {
            //Check if on banch ->move to start button
            if (transform.position == StartRock[0].transform.position)
            {
                RockPosition = Vector3.MoveTowards(transform.position, MainPath[0].transform.position, moveSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, MainPath[0].transform.position, moveSpeed * Time.deltaTime);
                DiceRoll--;//2
                FrogPosition = 0;
            }
            else//from starting point -> Rock 0
            {
                FrogPosition++;
                RockPosition = Vector3.MoveTowards(transform.position, MainPath[FrogPosition].transform.position, moveSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, MainPath[FrogPosition].transform.position, moveSpeed * Time.deltaTime);
                
            }
            Wait();


        }
        
        //Rock 3 -> path1

        //path 1-> Rock 16
    }

    IEnumerable Wait()
    {
        yield return new WaitForSeconds(5);
    }

}
