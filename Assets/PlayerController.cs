using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float rotation = 0.0f;
    public   float maxSpeed = 1.0f;
    float camRotation = 0.0f;
   public  float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;
    GameObject cam;
    Rigidbody myRigidBody;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical") * maxSpeed);
        //transform.position = transform.position + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);

        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed;
        myRigidBody.velocity = new Vector3(newVelocity.x, myRigidBody.velocity.y, newVelocity.z);


        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-camRotation, 0.0f, 0.0f));
    }
}
