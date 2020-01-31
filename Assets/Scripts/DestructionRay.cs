using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sends a ray from the given object that destroys an object on click
public class DestructionRay : MonoBehaviour
{

	public int layerNum;
	int layerMask;
	RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
		if (layerNum == null)
		{
			layerMask = Physics.DefaultRaycastLayers;
		} else {
			layerMask = 1 << layerNum;
		}
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 dir = transform.TransformDirection(Vector3.forward);

		// Raycast
		bool touched = Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity, layerMask);

		// Display Ray
		Debug.DrawRay(transform.position, dir * 5 /* distance */);
		
		// Highlight target ? TODO

		// Destroy on click
		if (touched && true /* FIXME click */) {
			Object.Destroy(hit.transform); /* .parent maybe ? */

			// Explosions
		}
        
    }
}
