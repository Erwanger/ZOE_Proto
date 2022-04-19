using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;


    public float speed = 6f;


    float horizontal, vertical, frontal;
    Vector3 direction;
    float targetAngle;
    float turnSmoothTime = 0.1f;
    float angle;
    float turnSmoothVelocity;


    public Transform cam;

    private void Start()
    {

        cam = Camera.main.transform;
        controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;


    }


    private void Update()
    {

        

        //Get inputs to move player with ZS, QD, AE
        horizontal = Input.GetAxisRaw("Horizontal");
        frontal = Input.GetAxisRaw("Frontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, vertical, frontal).normalized; 


        //Translate and rotate the player
        if(direction.magnitude >= 0.1f)
        {
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
    }































    /*Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 0.1f;


   
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")).normalized * moveSpeed);
    }*/
}
