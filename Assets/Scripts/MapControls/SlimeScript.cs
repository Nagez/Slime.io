using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public GameObject Player;

    public GameObject StartingRockPossition;
    public Transform[] MainMapPath;
    public int SlimePosition = 0;
    [SerializeField] public int CurrentDice = 0;
    [SerializeField] private float SlimeSpeed = 4f;
    public bool SlimeMovmentAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartingRockPossition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (GetComponentInParent<PlayerScript>().PTurn)
        {
            CurrentDice = GetComponentInParent<PlayerScript>().DiceMoves[0];
            SlimeMovmentAllowed = true;
        }
    }
}
