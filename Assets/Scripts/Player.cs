using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Move Speeds")]
    public float runSpeed = 8f;
    public float walkSpeed = 6f;
    public float gravity = -10f;
    public float jumpHeight = 15f;
    public float groundRayDistance = 1.1f;

    private CharacterController controller; //Reference to Character Controller
    private Vector3 motion; // is the movement offset per frame

    private void OnDrawGizmos()
    {
        Ray groundRay = new Ray(transform.position, -transform.up);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * groundRayDistance);
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Move(inputH, inputV);
        //is the player grounded
        if (IsGrounded())
        {
            motion.y = 0f;
            //if the jump button has been pressed
            if (Input.GetButtonDown("Jump"))
            {
                //player jumps
                motion.y = jumpHeight;
            }
        }
        //Apply Gravity
        motion.y += gravity * Time.deltaTime;
        //Move the controller with motion
        controller.Move(motion * Time.deltaTime);
    }
    //Check if the player is touching the ground
    bool IsGrounded()
    {
        return controller.isGrounded;
        ////Raycast below the player
        //Ray groundRay = new Ray(transform.position, -transform.up);

        ////if hitting something
        //return Physics.Raycast(groundRay, groundRayDistance);

    }
    //Move characters motion in direction of input
    void Move(float inputH, float inputV)
    {
        //Generate direction from input
        Vector3 direction = new Vector3(inputH, 0f, inputV);

        //Convert local space to world space direction
        direction = transform.TransformDirection(direction);

        //Apply motion to only x and z
        motion.x = direction.x * walkSpeed;
        motion.z = direction.z * walkSpeed;
        

    }
}
