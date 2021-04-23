using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class RoomButton : MonoBehaviour
{
    [SerializeField]
    private Text nameText; //display room name
    [SerializeField]
    private Text sizeText; //display room size

    private string roomName; //string for saving room name
    private int roomSize; //int for saving room size
    private int playerCount; 

    public void JoinRoomOnClick()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void SetRoom(string nameInput, int sizeInput, int countInput)
    {
        roomName = nameInput;
        roomSize = sizeInput;
        playerCount = countInput;
        nameText.text = nameInput;
        sizeText.text = countInput + "/" + sizeInput;
    }

}
