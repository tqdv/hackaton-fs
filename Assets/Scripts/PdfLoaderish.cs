using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PdfLoaderish : MonoBehaviour
{

	private int count = 0;
	public GameObject page;
    public XRNode node;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0)
			 || Input.GetButtonDown("LeftTrigger"))
		{
			// Print the next page (and loop)
			CreatePdfQuad(count);
			count = (count + 1) % 21; // 21 pages
		}
	}

	// Create a new page from prefab an texture it
	// Place it in front of the HMD
	private void CreatePdfQuad (int pagenum)
	{
		GameObject aPage = GameObject.Instantiate(page);
		aPage.name = string.Format("Page {0}", pagenum);

		// If the texture doesn't exist, it won't change display
		string texturePath = string.Format("Images/outa-large-{0}", pagenum);

		// Add texture
		Transform front = aPage.transform.GetChild(0).Find("Front");
		front.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(texturePath);

        // Set pose
        Quaternion vrRot = InputTracking.GetLocalRotation(node);
        Vector3 vrPos = InputTracking.GetLocalPosition(node);
		aPage.transform.position = vrPos + (vrRot * Vector3.forward)*0.7f;
		aPage.transform.rotation = vrRot;
	}
}
