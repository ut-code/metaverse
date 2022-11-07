using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{   

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSensitivity = 3f;

    [SerializeField]
    GameObject fpsCamera;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    private float CameraUpDownRotaion = 0f;

    private float currentCameraUpDownRotation = 0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate movement velocity as a 3d vector

        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 movementHorizontal = transform.right * xMovement;
        Vector3 movementVertical = transform.forward * zMovement;

        //Final movement velocity

        Vector3 movementVelocity = (movementHorizontal + movementVertical).normalized * speed;

        //Applay movement
        Move(movementVelocity);

        //calculate rotation as a 3D vector for turning around.
        float yrotation = Input.GetAxis("Mouse X");
        Vector3 rotationVector = new Vector3(0, yrotation, 0) * lookSensitivity;

        //Applay rotation
        
        Rotate(rotationVector);

        //Calculate look up and down camera rotation
        float cameraUpDownRotaion = Input.GetAxis("Mouse Y") * lookSensitivity;

        //Applay rotation

        RotateCamera(cameraUpDownRotaion);
    }

    //runs per physics iteration
    private void FixedUpdate()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity* Time.fixedDeltaTime);

            
        }

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if(fpsCamera != null)
        {
            currentCameraUpDownRotation -= CameraUpDownRotaion;
            currentCameraUpDownRotation = Mathf.Clamp(currentCameraUpDownRotation, -85, 85);

            fpsCamera.transform.localEulerAngles = new Vector3(currentCameraUpDownRotation, 0, 0);
        }
    }

    void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;

    }

    void Rotate(Vector3 rotationvector)
    {
        rotation=rotationvector; 
    }

    void RotateCamera(float cameraUpDownRotaion)
    {
        CameraUpDownRotaion = cameraUpDownRotaion;
    }
}
