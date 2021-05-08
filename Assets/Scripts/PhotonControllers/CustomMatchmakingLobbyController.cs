using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomMatchmakingLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject lobbyConnectButton; //button used for joining a Lobby
    [SerializeField]
    private GameObject lobbyPanel; //panel for displaying lobby.
    [SerializeField]
    private GameObject mainPanel; //panel for displaying the main menu
   // [SerializeField]
   // private InputField playerNameInput; //Input field so player can change their NickName
    [SerializeField]
    private TMP_InputField playerNameInput; //Input field so player can change their NickName

    private string roomName; //string for saving room name
    private int roomSize = 4; //int for saving room size
    List<int> Sizes = new List<int>() { 5, 4, 3, 2, 1 };
    [SerializeField]
    private Dropdown roomSizeDropDownList;

    private List<RoomInfo> roomListings; //list of current rooms
    [SerializeField]
    private Transform roomsContainer; //container for holding all the room listings
    [SerializeField]
    private GameObject roomListingPrefab; //prefab for displayer each room in the lobby

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        lobbyConnectButton.SetActive(true);
        roomListings = new List<RoomInfo>(); //initializing roomListing

        //check for player name saved to player prefs
        if(PlayerPrefs.HasKey("NickName"))
        {
            if(PlayerPrefs.GetString("NickName")=="")
            {
                PhotonNetwork.NickName = "Player " + Random.Range(0, 1000);
            }
            else
            {
                PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");
            }
        }
        else
        {
            PhotonNetwork.NickName = "Player " + Random.Range(0, 1000);
        }
        playerNameInput.text = PhotonNetwork.NickName;
    }

    public void PlayerNameUpdate(string nameInput)
    {
        PhotonNetwork.NickName = nameInput;
        PlayerPrefs.SetString("NickName", nameInput);
    }

    public void JoinLobbyOnClick()
    {
        mainPanel.SetActive(false);
        lobbyPanel.SetActive(true);
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("onroomlistupdate");
        int tempIndex;
        foreach(RoomInfo room in roomList)
        {
            if(roomListings != null)
            {
                tempIndex = roomListings.FindIndex(ByName(room.Name));
            }
            else
            {
                tempIndex = -1;
            }
            if (tempIndex != -1)
            {
                roomListings.RemoveAt(tempIndex);
                Destroy(roomsContainer.GetChild(tempIndex).gameObject);
            }
            if(room.PlayerCount>0)
            {
                roomListings.Add(room);
                ListRoom(room);
            }
        }
    }

    static System.Predicate<RoomInfo> ByName(string name)
    {
        return delegate (RoomInfo room)
        {
            return room.Name == name;
        };
    }

    void ListRoom(RoomInfo room)
    {
        Debug.Log("listrooms");

        if (room.IsOpen && room.IsVisible)
        {
            GameObject tempListing = Instantiate(roomListingPrefab, roomsContainer);
            RoomButton tempButton = tempListing.GetComponent<RoomButton>();
            tempButton.SetRoom(room.Name, room.MaxPlayers, room.PlayerCount);
        }
    }

    public void OnRoomNameChanged(string nameIn) //set the room name
    {
        Debug.Log("room name get " + nameIn);
        roomName = nameIn;
        Debug.Log("room name set to " + roomName);

    }
    public void OnRoomSizeChanged(int sizeIn) //set room size aka number of alowed players
    {
        Debug.Log("drop: " + sizeIn);
        roomSize = Sizes[sizeIn+1]; //did +1 because the list start with 5 but room sizes start in 4 (start in 5 because i use the array in slimeNumber also)
        //roomSize = int.Parse(sizeIn);
        Debug.Log("room size set to " + roomSize);

    }

    public void CreateRoom()
    {
        Debug.Log("Creating room now");
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom(roomName, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed, there must already be a room with the same name");
    }

    public void MatchmakingCancel()
    {
        mainPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        PhotonNetwork.LeaveLobby();
    }

}
