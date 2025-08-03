using TMPro;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public float range = 100f;
    public Camera FirstPersonCamera;

    public TextMeshProUGUI ObjectInformation;
    public TextMeshProUGUI ObjectInformation2;
    [TextArea(2,2)] public string ObjInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;//this is where the information about the object hit will go

        if (Physics.Raycast(FirstPersonCamera.transform.position, FirstPersonCamera.transform.forward, out hitInfo, range)
            && hitInfo.transform.gameObject.CompareTag("Interactable"))
        {
            ObjectInformation.text = hitInfo.transform.name.ToString();

            //USING UNITYS OLD INPUT SYSTEM. GET HELP!!!//
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0f;
                ObjectInformation2.enabled = true;
                ObjectInformation2.text = ObjInfo.ToString();
            }
        }
        else
        {
            ObjectInformation.text = "".ToString();
        }
    }
}
