using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    /*
    Title: FIRST PERSON MOVEMENT in Unity - FPS Controller
    Author: Asbjørn Thirslund / Brackeys
    Date: 28 July 2025
    Code version: 1
    Availability: https://www.youtube.com/watch?v=_QajrabyTJc
    */

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = .4f;//radius of Sphere to be used to check ground
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//creates a sphere from the groundCheck gameObject which checks if the player is on the ground

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;//as to reset the velocity, which was before constantly building
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);//"Time.deltaTime" meaning the move speed is now framerate independent

        /*
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        */

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
