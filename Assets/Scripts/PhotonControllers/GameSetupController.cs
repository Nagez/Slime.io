using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class GameSetupController : MonoBehaviour
{
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

        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","greenplayer"),Vector3.zero,Quaternion.identity);//params(file location for photon plyaer prefab,position to start, rotation) 
    }
}
