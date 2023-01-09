using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObjectPlacer : MonoBehaviourPunCallbacks
{
    //アタッチするゲームオブジェクト
    public new Camera camera;
    public GameObject clone;

    public float jumpPower;
    public Rigidbody rb;

    private float distance = 20.0f;
    private GameObject previewClone;

    private bool isCreative = false;
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

            if (Input.GetKeyUp(KeyCode.C))
            {
                if (isCreative)
                {
                    Destroy(previewClone);
                    isCreative = false;
                }
                else
                {
                    previewClone = Instantiate(clone);

                    isCreative = true;

                }
            }

            if (isCreative)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, distance))
                {

                    Vector3 movement = Vector3.Scale(previewClone.transform.localScale, hit.normal) / 2;
                    previewClone.transform.position = new Vector3(hit.point.x + movement.x, hit.point.y + movement.y, hit.point.z + movement.z);

                    if (Input.GetMouseButtonUp(0))
                    {

                        PhotonNetwork.Instantiate("sphere", previewClone.transform.position, Quaternion.identity);

                    }

                }
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
