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
                if ((SlimeMovment.position.x == transform.position.x) && (SlimeMovment.position.y == transform.position.y))
                {
                    Player.GetComponent<PlayerScript>().DiceMoves[0]--;
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
                    else if ((PlayerPosition == 24))
                    {
                        PlayerPosition = 14;
                    }

                    //Fourth Path
                    //out
                    else if ((PlayerPosition == 22) && (DiceNum == 0))
                    {
                        PlayerPosition = 27;
                    }

                    //End
                    else if ((PlayerPosition == 19) || (PlayerPosition == 29))
                    {
                        PlayerPosition = 29;
                    }

                }

            }
            if (DiceRoll == 0)
            {
                if (Player.GetComponent<PlayerScript>().FirstMove)
                    DiceNum--;
                //Player.GetComponent<PlayerScript>().DiceMoves[0] = -1;

                Player.GetComponent<PlayerScript>().DiceMoves[0] = 0;
                Player.GetComponent<PlayerScript>().FirstMove = true;

                ////GetComponent<BoxCollider2D>().isTrigger = true;
                ///


            }
            if (DiceRoll == -1)
            {
                CollisionChacking();
                moveAllowed = false;
                Player.GetComponent<PlayerScript>().DiceMoves[0] = -1;
                Player.GetComponent<PlayerScript>().FirstMove = true;
                //GetComponent<BoxCollider2D>().isTrigger = true;
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

    public void CollisionChacking()
    {
        Rigidbody2D CurrentSlime = GetComponent<Rigidbody2D>();

        for(int i=0;i<4;i++)//add mex players
        {
            GameObject GameControlsP = GameObject.Find("GameControls");//GetComponent<GameControl>().Players[i];
            GameObject PlayerS = GameControlsP.GetComponent<GameControl>().Players[i];

            for (int j=0;j< PlayerS.GetComponent<PlayerScript>().Slimes.Count ; j++)
            {
                GameObject testSlime = PlayerS.GetComponent<PlayerScript>().Slimes[j];

                if(CurrentSlime.GetComponent<keyMove>().PlayerPosition == testSlime.GetComponent<keyMove>().PlayerPosition)
                {
                    if (CurrentSlime.GetComponentInParent<PlayerScript>().playerNum == testSlime.GetComponentInParent<PlayerScript>().playerNum)
                    {
                        if(CurrentSlime.name == testSlime.name)
                        {
                            
                        }
                        else
                        {
                            Debug.Log("levelUp");
                            Debug.Log("Destroy " + testSlime.name);

                            Destroy(testSlime);
                            PlayerS.GetComponent<PlayerScript>().Slimes.RemoveAt(j);
                            //myItems.RemoveAt(myIndex);
                            break;
                        }
                        
                    }
                    else
                    {
                        Debug.Log("Destroy "+ testSlime.name);
                        Destroy(testSlime);

                        PlayerS.GetComponent<PlayerScript>().Slimes.RemoveAt(j);
                        break;
                    }
                }
            }
        }
    }



    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("collision!");
    //    if (this.PlayerPosition == collision.gameObject.GetComponent<keyMove>().PlayerPosition)
    //    {
    //        if (collision.gameObject.name == this.name)
    //        {
    //            Debug.Log("Upgrade!");
    //        }
    //        else
    //        {
    //            Debug.Log("Del " + collision.gameObject.name);
    //        }
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (this.PlayerPosition == collision.gameObject.GetComponent<keyMove>().PlayerPosition)
    //    {
    //        if (collision.name == this.name)
    //        {
    //            Debug.Log("Upgrade!");
    //        }
    //        else
    //        {
    //            Debug.Log("Del " + collision.name);
    //        }
    //    }


    //    //Rigidbody2D SlimeMovment = GetComponent<Rigidbody2D>();
    //    //if ((SlimeMovment.position.x == transform.position.x) && (SlimeMovment.position.y == transform.position.y))
    //    //{
    //    //    if ((DiceNum == 0) && (Player.GetComponent<PlayerScript>().PTurn == true))
    //    //        if (collision.name == this.name)
    //    //        {
    //    //            Debug.Log("Upgrade!");
    //    //        }
    //    //        else
    //    //        {
    //    //            Debug.Log("Del " + collision.name);
    //    //        }
    //    //    GetComponent<BoxCollider2D>().isTrigger = false;
    //    //}


    //}



}
