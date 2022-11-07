using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNameInoutManager : MonoBehaviour
{
    public void setPlayerName(string PlayerName)
    {
        if(string.IsNullOrEmpty(PlayerName))
        {
            Debug.Log("PlayerName is empty.");
            return;
        }

        PhotonNetwork.NickName = PlayerName;
    }

}

