using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyMove : MonoBehaviour
{
 
    public GameObject Player;
    public Transform[] StartRock;
    public Transform[] MainPath;

    public int PlayerPosition = 0;
    public bool FirstRollMove = true;
    
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] public int DiceNum = 0;

    [HideInInspector]
    public int RockNumber = 0;
    public bool moveAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartRock[0].transform.position;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
            moveFrog(DiceNum);
    }

    public void moveFrog(int DiceRoll)
    {
        if (DiceRoll > 0)
        {
            
            int newRock = PlayerPosition + 1;
            Rigidbody2D SlimeMovment = GetComponent<Rigidbody2D>();
            
            transform.position = Vector3.MoveTowards(transform.position, MainPath[newRock].transform.position, moveSpeed * Time.deltaTime);

            //SlimeMovment = GetComponent<Rigidbody2D>();
            if ((SlimeMovment.position.x == transform.position.x)&& (SlimeMovment.position.y == transform.position.y))
            {
                DiceNum--;
                PlayerPosition++;
                
                //First Path
                //out
                if ((PlayerPosition == 5) && (DiceNum == 0))
                {
                    PlayerPosition = 19;
                    
                }

                //Secend Path
                //out
                else if ((PlayerPosition == 10) && (DiceNum == 0))
                {
                    PlayerPosition = 24;
                }

                //Third Path
                
                //in
                else if((PlayerPosition == 24) )
                {
                    PlayerPosition = 14;
                }

                //Fourth Path
                //out
                else if((PlayerPosition == 22) && (DiceNum == 0))
                {
                    PlayerPosition = 27;
                }
                
                //End
                else if((PlayerPosition == 19) || (PlayerPosition == 29))
                {
                    PlayerPosition = 29;
                }


            }

        }
        if(DiceRoll == 0)
        {
            moveAllowed = false;
            Player.GetComponent<PlayerScript>().DiceMoves[0] = 0;
            Player.GetComponent<PlayerScript>().FirstMove = true;

        }

        FirstRollMove = false;
    }

    private void OnMouseDown()
    {
        if(GetComponentInParent<PlayerScript>().PTurn)
        {
            DiceNum =GetComponentInParent<PlayerScript>().DiceMoves[0];
            moveAllowed = true;
        }
        
    }




}
