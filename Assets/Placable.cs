using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placable : MonoBehaviour
{
    public GameObject pointer;
    public bool beingPlaced = true;
    public float yOffset;
    public GameObject httpHandler;
    public string typeName;

    // Start is called before the first frame update
    void Start()
    {
        httpHandler = GameObject.Find("HttpHandler");
    }

    // Update is called once per frame
    void Update()
    {
        if (beingPlaced)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger | OVRInput.Button.SecondaryIndexTrigger))
            {
                beingPlaced = false;
                GetComponent<Collider>().enabled = true;
                httpHandler.GetComponent<httptest>().makeRequest(this.gameObject.transform.position.x, this.gameObject.transform.position.z, typeName);
            }

            if (pointer == null)
                return;
            transform.position = pointer.transform.position + transform.up * yOffset; // object origin might not be in center of object, so place it a bit higher
        }
    }
}
