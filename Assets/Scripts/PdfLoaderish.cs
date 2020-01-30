using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;

public class PdfLoaderish : MonoBehaviour
{

	private int count = 0;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Touchpad))
		{
			// Print the next page (and loop)
			CreatePdfQuad(count);
			count = (count + 1) % 21; // 21 pages
		}
	}

	private void CreatePdfQuad (int pagenum)
	{
		// If the texture doesn't exist, it won't change display
		string texturePath = string.Format("Images/outa-large-{0}", pagenum);

		// HMD properties
		Quaternion wvrRot = WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_HMD).transform.rot;
		Vector3 wvrPos = WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_HMD).transform.pos

		// Create object
		GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

		// NB: A4 paper = 21cm x 29.7cm
		quad.transform.localScale = new Vector3(0.21f, 0.297f, 1f);
		quad.transform.position = wvrPos + (wvrRot * Vector3.forward) ;
		quad.transform.rotation = wvrRot;
		quad.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(texturePath);

		// Create backside by creating the same object, and flipping it
		// Create object
		GameObject quadBack = GameObject.CreatePrimitive(PrimitiveType.Quad);
		quad.transform.localScale = new Vector3(0.21f, 0.297f, 1f);
		quad.transform.position = wvrPos + (wvrRot * Vector3.forward) ;
		quad.transform.rotation = wvrRot * Quaternion.Euler(0f, 90f, 0f);
	}
}
