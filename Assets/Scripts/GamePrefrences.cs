using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//this class will pass to the game scene values from the lobby
public class GamePrefrences : MonoBehaviour
{
    public static GamePrefrences instance;

    List<int> Sizes = new List<int>() { 5, 4, 3, 2, 1 };

    private int roomSize = 4;  //how many player are connected when starting the game
    [SerializeField] private Dropdown roomSizeDropDownList;

    private int NumOfSlimes = 5; //int for saving Nummber Of Slimes available to each player
    [SerializeField] private Dropdown NumOfSlimesDropDownList;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void OnRoomSizeChanged(int sizeIn) //set room size aka number of alowed players
    {
        roomSize = Sizes[sizeIn + 1]; //did +1 because the list start with 5 but room sizes start in 4 (start in 5 because i use the array in slimeNumber also)
        Debug.Log("room size set to " + roomSize);

    }
    public void OnRoomNumOfSlimesChanged(int sizeIn) //set room size aka number of alowed players
    {
        //Debug.Log("NumOfSlimes before " + NumOfSlimes);
        NumOfSlimes = Sizes[sizeIn]; //droplist values start at 0, get actual value from array
        Debug.Log("NumOfSlimes set to " + NumOfSlimes);

    }

    public int getRoomSize()
    {
        return roomSize;
    }

    public int getNumOfSlime()
    {
        return NumOfSlimes;
    }
}
