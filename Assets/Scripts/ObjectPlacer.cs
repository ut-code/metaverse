using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{   

    public GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 litteHigh = new Vector3(0,1,0);

        if(Input.GetKeyDown("space")) {
            Instantiate(ballPrefab, transform.position + litteHigh, Quaternion.identity);
        }
    }
}
