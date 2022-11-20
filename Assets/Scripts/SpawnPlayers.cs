using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class SpawnPlayers : MonoBehaviour
{
    private PhotonView pv;
    [SerializeField] private GameObject player;
    private GameObject[] playerList;
    private int playerCount;
    private bool added;
    private GameObject thisPlayer;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        thisPlayer = PhotonNetwork.Instantiate(player.name, transform.position, quaternion.identity);
        //pv.RPC("AddToPlayerList", RpcTarget.AllBuffered, thisPlayer);
    }

    /*[PunRPC]
    void AddToPlayerList(GameObject thisGameObjPlayer)
    {
        playerCount++;
        while (!added)
        {
            playerList[]
        }
    }*/
}
