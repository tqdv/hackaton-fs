using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;

public class PdfLoaderish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Touchpad))
		{
            CreatePdfQuad(0);
		}
    }

	private void CreatePdfQuad (int pagenum)
	{
		// If the texture doesn't exist, it won't change display
		string texturePath = string.Format("outa-large-{0}", pagenum);

		GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

		// A4 paper = 21cm x 29.7cm
		quad.transform.localScale = new Vector3(0.21f, 0.297f, 1f);
        quad.transform.position = WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_HMD).transform.pos + (WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_HMD).transform.rot * Vector3.forward) ;
        quad.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(texturePath);
	}
}
