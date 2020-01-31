//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using wvr;

//public class PdfLoaderish : MonoBehaviour
//{

//	private int count = 0;

//	// Start is called before the first frame update
//	void Start()
//	{
		
//	}

//	// Update is called once per frame
//	void Update()
//	{
//		if (Input.GetKeyDown(KeyCode.Mouse0)
//			|| WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Touchpad))
//		{
//			// Print the next page (and loop)
//			CreatePdfQuad(count);
//			count = (count + 1) % 21; // 21 pages
//		}
//	}

//	private void CreatePdfQuad (int pagenum)
//	{
//		// If the texture doesn't exist, it won't change display
//		string texturePath = string.Format("Images/outa-large-{0}", pagenum);

//		// HMD properties
//		Quaternion wvrRot = WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_HMD).transform.rot;
//		Vector3 wvrPos = WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_HMD).transform.pos;

//		// Create object root
//		GameObject page = new GameObject(string.Format("Page {0}", pagenum));

//		// NB: A4 paper = 21cm x 29.7cm
//		// Create front side
//		GameObject front = GameObject.CreatePrimitive(PrimitiveType.Quad);
//		front.name = "Front";
//		front.transform.parent = page.transform;
//		front.transform.localScale = new Vector3(0.21f, 0.297f, 1f);
//		front.transform.position = wvrPos + (wvrRot * Vector3.forward);
//		front.transform.rotation = wvrRot;
//		// Add texture
//		front.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(texturePath);

//		// Create backside by creating the same object, and flipping it
//		GameObject back = GameObject.CreatePrimitive(PrimitiveType.Quad);
//		back.name = "Back";
//		back.transform.parent = page.transform;
//		back.transform.localScale = new Vector3(0.21f, 0.297f, 1f);
//		back.transform.position = wvrPos + (wvrRot * Vector3.forward);
//		back.transform.rotation = wvrRot * Quaternion.Euler(0f, 180f, 0f);
//	}
//}
