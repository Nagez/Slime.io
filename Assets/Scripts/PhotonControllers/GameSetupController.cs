using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class GameSetupController : MonoBehaviour
{
    //public GameObject position0;
    // this script will be added to multiplayer scenes
    void Start()
    {
        CreatePlayer(); //create a networked player for each player connected
    }

    // Update is called once per frame
    void CreatePlayer()
    {
        //file location name need to match actual location in unity case sensitive
        Debug.Log("creating player");

        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","greenplayer"),GameSetupController.GS, Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","Player1"),new Vector3(0, 0, 0), Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "greenplayer"), new Vector3(0, 0, 0), Quaternion.identity, 0);//params(file location for photon plyaer prefab,position to start, rotation) 
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","greenplayer"), position0.transform.position, Quaternion.identity);//params(file location for photon plyaer prefab,position to start, rotation) 
    }
}
