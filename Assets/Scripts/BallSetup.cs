using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BallSetup : MonoBehaviourPunCallbacks
{   



    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine)
        {
            transform.GetComponent<MovementController>().enabled = true;
        }

        else
        {
            transform.GetComponent<MovementController>().enabled = false;
        }

    }

}

