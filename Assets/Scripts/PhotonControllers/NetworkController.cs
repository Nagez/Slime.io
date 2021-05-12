using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField] private bool AbleConnection = true;
    // Start is called before the first frame update
    void Start()
    {
        //if (AbleConnection == true)
        //{
            //remove // to connect to network
            PhotonNetwork.ConnectUsingSettings(); //Connects to Photon master servers
        //}
       
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server"); //tell us which server we are connected to
    }

    // Update is called once per frame
    //void Update()
    //{       
    //}
}
