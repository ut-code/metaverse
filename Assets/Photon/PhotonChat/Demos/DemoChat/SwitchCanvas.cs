using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chatCanvas;
    public GameObject sidechatCanvas;
    void Start()
    {
        chatCanvas.SetActive(true);
        sidechatCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            chatCanvas.SetActive(false);
            sidechatCanvas.SetActive(true);
        }
        if(Input.GetKey(KeyCode.L)){
            chatCanvas.SetActive(true);
            sidechatCanvas.SetActive(false);
        }
    }
}
