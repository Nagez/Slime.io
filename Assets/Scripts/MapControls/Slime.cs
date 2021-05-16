using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
 
    public GameObject Player;
    public GameObject GameControl;
    public Transform[] StartRock;
    public Transform[] MainPath;

    public int slimeLevel = 1;
    public int PlayerPosition = 0;
    public bool FirstRollMove = true;
    
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] public int DiceNum = 0;

    
    public bool moveAllowed = false;

    [SerializeField] ParticleSystem smokeParticles;
    [SerializeField] ParticleSystem starsParticles;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartRock[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
        {
            SlimeMovment(DiceNum);
        }   
    }
    
    public void CollisionChecking()
    {
        Rigidbody2D CurrentSlime = GetComponent<Rigidbody2D>();
        
        for (int i=0;i< 4 ; i++)//add mex players
        {
            GameObject GameControlsP = GameObject.Find("GameControls");//GetComponent<GameControl>().Players[i];
            GameObject PlayerS = GameControlsP.GetComponent<GameControl>().Players[i];

            for (int j=0;j< PlayerS.GetComponent<PlayerScript>().Slimes.Count ; j++)
            {
                GameObject testSlime = PlayerS.GetComponent<PlayerScript>().Slimes[j];

                if(CurrentSlime.GetComponent<Slime>().PlayerPosition == testSlime.GetComponent<Slime>().PlayerPosition)
                {
                    if (CurrentSlime.GetComponentInParent<PlayerScript>().playerNum == testSlime.GetComponentInParent<PlayerScript>().playerNum)
                    {
                        if(CurrentSlime.name == testSlime.name)
                        {
                            
                        }
                        else
                        {
                            Debug.Log("levelUp "+CurrentSlime.name);
                            LevelUP(CurrentSlime, testSlime);
                            CurrentSlime.GetComponent<Slime>().starsParticles.Play();

                            Debug.Log("Destroy " + testSlime.name);

                            
                            testSlime.GetComponentInParent<PlayerScript>().SlimeSpawnNeeded();
                            //SlimeSpawnNeeded();



                            Destroy(testSlime);
                            


                            PlayerS.GetComponent<PlayerScript>().Slimes.RemoveAt(j);
                            break;
                        }
                        
                    }
                    else
                    {
                        
                        Debug.Log("Destroy "+ testSlime.name);
                        CurrentSlime.GetComponent<Slime>().smokeParticles.Play();
                        
                        testSlime.GetComponentInParent<PlayerScript>().SlimesSpawned -= testSlime.GetComponent<Slime>().slimeLevel;

                        testSlime.GetComponentInParent<PlayerScript>().SlimeSpawnNeeded();
                        
                        Destroy(testSlime);
                        
                        //add cube if no 5 cubes
                        PlayerS.GetComponent<PlayerScript>().Slimes.RemoveAt(j);
                        break;
                    }
                }
            }
        }
    }


    //////FIXED FUNCS
    /////New Slime Generator
    public void InitNewSlime(int playerNum, int slimeNumber)
    {
        GameObject PlayerT = GameObject.Find("Player" + playerNum);
        transform.parent = PlayerT.transform;
        PlayerPosition = 0;
        slimeLevel = 1;
        DiceNum = 0;
        moveAllowed = false;
        int countN = PlayerT.GetComponent<PlayerScript>().Slimes.Count;//NewSlime.GetComponentsInParent<PlayerScript>().Length;
        name += slimeNumber;
    }

    //Slime selection for movment
    private void OnMouseDown()
    {
        if (GetComponentInParent<PlayerScript>().PTurn && !(GameObject.Find("dice6").GetComponent<AlinasDice>().coroutineAllowed))
        {
            //DiceNum = 
            DiceNum = GameControl.GetComponent<GameControl>().DiceMoves[0];
            moveAllowed = true;
        }

    }

    //Slime Fusion
    public void LevelUP(Rigidbody2D CurrentSlime, GameObject testSlime)
    {
        Debug.Log(CurrentSlime.GetComponent<Slime>().slimeLevel + "+" + testSlime.GetComponent<Slime>().slimeLevel);
        int addLevel = CurrentSlime.GetComponent<Slime>().slimeLevel + testSlime.GetComponent<Slime>().slimeLevel;
        Debug.Log("=" + addLevel);
        CurrentSlime.GetComponent<Slime>().slimeLevel = addLevel;
        
    }

    //slime movment
    public void SlimeMovment(int DiceRoll)
    {
        if (PlayerPosition == 31)
        {
            Player.GetComponent<PlayerScript>().SlimesLeft -= slimeLevel;
            Player.GetComponent<PlayerScript>().Slimes.Remove(this.gameObject);
            Destroy(this.gameObject);
            Destroy(this);
            Debug.Log("OK");
        }

        if (DiceRoll > 0)
        {
            int newRock = PlayerPosition + 1;

            Rigidbody2D SlimeMovment = GetComponent<Rigidbody2D>();

            try { transform.position = Vector3.MoveTowards(transform.position, MainPath[newRock].transform.position, moveSpeed * Time.deltaTime); }
            catch (System.IndexOutOfRangeException e) { Debug.Log("boom"+e); }
            

            if ((SlimeMovment.position.x == transform.position.x) && (SlimeMovment.position.y == transform.position.y))
            {
                //Player.GetComponent<PlayerScript>().DiceMoves[0]--;
                DiceNum--;
                PlayerPosition++;

                //if (PlayerPosition == 31)
                //{
                //    Player.GetComponent<PlayerScript>().SlimesLeft -= slimeLevel;
                //    Destroy(SlimeMovment);
                //}


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
            moveAllowed = false;
            CollisionChecking();

            GameControl.GetComponent<GameControl>().DiceMoves[0] = 0;
            Player.GetComponent<PlayerScript>().FirstMove = true;


        }
        //if (DiceRoll == -1)
        //{
        //    CollisionChecking();
        //    moveAllowed = false;
        //    GameControl.GetComponent<GameControl>().DiceMoves[0] = -1;
        //    Player.GetComponent<PlayerScript>().FirstMove = true;
        //}

        FirstRollMove = false;
    }

    
}
