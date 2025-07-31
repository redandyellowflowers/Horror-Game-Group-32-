using UnityEngine;
using UnityEngine.InputSystem;

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

    private Vector2 moveInput;

    Vector3 velocity;
    bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    public void OnMovement(InputAction.CallbackContext context)//has this happened on the input action - that is what is being checked.
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void HandleMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//creates a sphere from the groundCheck gameObject which checks if the player is on the ground

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;//as to reset the velocity, which was before constantly building
        }

        Vector3 move = transform.right * moveInput.x + transform.forward *
        moveInput.y;

        controller.Move(move * speed * Time.deltaTime);//"Time.deltaTime" meaning the move speed is now framerate independent

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            //Debug.Log("Jump" + context.phase);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
