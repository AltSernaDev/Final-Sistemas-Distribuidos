using System;
using System.Collections;
using System.Collections.Generic;
using KartGame.KartSystems;
using UnityEngine;
using Photon.Pun;

public class PunEnable : MonoBehaviour
{
    private PhotonView pView;
    private ArcadeKart thisCar;
    [SerializeField] private Camera camObj;
    [SerializeField] private GameObject red, yell;
    private bool canChange = true;
    
    void Start()
    {
        thisCar = GetComponent<ArcadeKart>();
        pView = GetComponent<PhotonView>();
        
        if (pView.IsMine)
        {
            thisCar.isMinePV = true;
        }
        else
        {
            thisCar.isMinePV = false;
            camObj.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && canChange && pView.IsMine)
        {
            pView.RPC("changeColor",RpcTarget.AllBuffered);
            canChange = false;
            Invoke("waitThis", 0.5f);
        }
        
    }

    [PunRPC]
    void changeColor()
    {
        red.SetActive(!red.activeSelf);
        yell.SetActive(!yell.activeSelf);
    }

    void waitThis()
    {
        canChange = true;
    }
}
