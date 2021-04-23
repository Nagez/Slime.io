using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //remove // to connect to network
        PhotonNetwork.ConnectUsingSettings(); //Connects to Photon master servers
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server"); //tell us which server we are connected to
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
