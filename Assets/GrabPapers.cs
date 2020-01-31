using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPapers : MonoBehaviour
{
    protected bool isGrabbing;
    protected GameObject contact;

    // Start is called before the first frame update
    void Start()
    {
        isGrabbing = false;
    }

    // Update is called once per frame
    void Update()
    {

        print(contact);

        if (!isGrabbing && Input.GetButton("RightTrigger") )
        {
            Grab();
        }

        if (isGrabbing && Input.GetButtonUp("RightTrigger"))

        {
            print(contact);
            Release();
        }

    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            contact = other.gameObject;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        contact = null;
    }

    protected void Grab()
    {
        if (contact != null)
        {
            contact.transform.SetParent(gameObject.transform);
            isGrabbing = true;
            contact.transform.GetComponent<Rigidbody>().isKinematic = true;
            

        }
        
    }

    protected void Release()
    {
        contact.transform.parent = null;
        isGrabbing = false;
        contact.transform.GetComponent<Rigidbody>().isKinematic = false;
        
    }
}
