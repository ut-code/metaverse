using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObjectPlacer : MonoBehaviourPunCallbacks 
{   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 litteHigh = new Vector3(0,1,0);

        if(Input.GetKeyDown("space")) {
            PhotonNetwork.Instantiate("sphere", transform.position + litteHigh, Quaternion.identity);
        }
    }
}
