using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;

public class PdfLoaderish : MonoBehaviour
{

	private int count = 0;
	public GameObject page;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0)
			/* Fixme */ || WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Touchpad))
		{
			// Print the next page (and loop)
			CreatePdfQuad(count);
			count = (count + 1) % 21; // 21 pages
		}
	}

	// Create a 2 sided quad for image display
	// and attach a collider and an (custom) info class
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
		/* FIXME */
		Quaternion wvrRot = WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_HMD).transform.rot;
		Vector3 wvrPos = WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_HMD).transform.pos;
		aPage.transform.position = wvrPos + (wvrRot * Vector3.forward);
		aPage.transform.rotation = wvrRot;
	}
}
