using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JumpController : MonoBehaviourPunCallbacks
{   
    public float jumpPower;
    public Rigidbody rb;

    private float distance = 20.0f;

    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine) 
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                rb.velocity = Vector3.up * jumpPower;
                isJumping = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {   

        if(collision.gameObject.CompareTag("Floor"))
        {   
            isJumping = false;
        }
    }
}
