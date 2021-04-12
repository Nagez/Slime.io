using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Transform[] StartRock;
    public Transform[] Rocks;
    public Transform[] PathRocks;

    [SerializeField]
    private float moveSpeed = 1f;

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
            MoveC();
    }

    void MoveC()
    {
        if(RockNumber <= Rocks.Length -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Rocks[RockNumber].transform.position, moveSpeed * Time.deltaTime);

            if(transform.position == Rocks[RockNumber].transform.position)
            {
                RockNumber +=1;
            }
        }
    }
}
