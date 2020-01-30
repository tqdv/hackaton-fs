using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, 1000.0f))
        {
            GameObject.Find("Debug").GetComponent<TMPro.TextMeshPro>().text = "touche";
        }
        else
        {
            GameObject.Find("Debug").GetComponent<TMPro.TextMeshPro>().text = "rate";
        }
    }
}
