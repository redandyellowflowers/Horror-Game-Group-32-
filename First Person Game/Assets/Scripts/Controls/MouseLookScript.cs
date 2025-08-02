using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLookScript : MonoBehaviour
{
    /*
    Title: FIRST PERSON MOVEMENT in Unity - FPS Controller
    Author: Asbjørn Thirslund / Brackeys
    Date: 28 July 2025
    Code version: 1
    Availability: https://www.youtube.com/watch?v=_QajrabyTJc
    */

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private Vector2 lookInput;

    float xRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void HandleMovement()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//"can never over rotate and look behind the player"

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//Quaternions are responsible for rotation
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
