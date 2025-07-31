using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class InteractionRaycast : MonoBehaviour
{
    public float range = 100f;
    public Camera FirstPersonCamera;

    public TextMeshProUGUI ObjectInformation;
    public TextMeshProUGUI ObjectInformation2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;//this is where the information about the object hit will go

        if (Physics.Raycast(FirstPersonCamera.transform.position, FirstPersonCamera.transform.forward, out hitInfo, range)) //out hit means unity will put all the info about the object hit with the raycast into the hit above. and forward means the raycast is emmiting from where the camera/object is facing
        {
            Debug.Log(hitInfo.transform.name);
            ObjectInformation.text = hitInfo.transform.name.ToString();
        }
    }

    public void InteractionKey(InputAction.CallbackContext context)
    {
            ObjectInformation2.text = "this is an object about an object from an object who spoke about that object".ToString();
    }
}
