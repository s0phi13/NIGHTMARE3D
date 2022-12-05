using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed = 10.0f;
    public float sprintSpeed = 20.0f;

    float rotation = 0.0f;
    public   float speed = 1.0f;
    float camRotation = 0.0f;
   public  float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;
    GameObject cam;
    Rigidbody myRigidBody;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 6.0f;

    bool doubleJump = true;

    public AudioClip backgroundMusic;

    public AudioSource musicPlayer;
    public AudioSource sfxPlayer;



    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            SceneManager.LoadScene(0
         );
        }
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cam = GameObject.Find("Main Camera");
        myRigidBody = GetComponent<Rigidbody>();

        musicPlayer.clip = backgroundMusic;
        musicPlayer.loop = true;
        musicPlayer.Play();
    }

  

    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);

        //transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical") * maxSpeed);
        //transform.position = transform.position + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * speed) + (transform.right * Input.GetAxis("Horizontal") * speed);
        myRigidBody.velocity = new Vector3(newVelocity.x, myRigidBody.velocity.y, newVelocity.z);


        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-camRotation, 0.0f, 0.0f));
        camRotation = Mathf.Clamp(camRotation, -30.0f, 30f);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = normalSpeed;
        }


        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            doubleJump = true;
            myRigidBody.AddForce(transform.up * jumpForce);
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround)
        {
            if (doubleJump == true)
            {
                 myRigidBody.AddForce(transform.up * jumpForce);
                 doubleJump = false;
            }
        }


    }
   

}
