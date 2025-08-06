using UnityEngine;

public class ObjectivesScript : MonoBehaviour
{
    public Transform player;
    public Transform ob;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = ob.transform.position;
    }
}
