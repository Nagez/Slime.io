using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    int StartWin = 0;

    public Transform[] StartRock;
    public Transform[] Rocks;
    public Transform[] PathRocks;

    public Transform[] Path1;

    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private int MoveNumber = 3;


    [HideInInspector]
    public int RockNumber = 0;

    public bool moveAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartRock[RockNumber].transform.position;
        //transform.position = Rocks[waypointIndex].transform.position;//first waypoint
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
            MoveC(MoveNumber);

    }

    void MoveC(int MoveNumber)
    {
        int Dice_num = 0;
        if (Dice_num <= MoveNumber)
        {
            //Check if on banch ->move to start button

            //from starting point -> Rock 0

            //Rock 3 -> path1

            //path 1-> Rock 16

            transform.position = Vector2.MoveTowards(transform.position, Rocks[RockNumber].transform.position, moveSpeed * Time.deltaTime);//The moving to new position

            if (transform.position == Rocks[RockNumber].transform.position)//when on the same position
            {
                RockNumber += 1;
            }
            if((transform.position == PathRocks[0].transform.position)&&(RockNumber == MoveNumber))
            {
                RockNumber += 1;
            }
        }


        
    }
}
