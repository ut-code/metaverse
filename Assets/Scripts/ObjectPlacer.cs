using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObjectPlacer : MonoBehaviourPunCallbacks 
{   
    public new Camera camera;
    private float distance = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   

        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, distance))
            {
                PhotonNetwork.Instantiate("sphere", hit.point, Quaternion.identity);
            }
        }
    }
}
