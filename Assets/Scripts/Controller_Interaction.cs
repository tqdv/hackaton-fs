//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using wvr;


//public class Controller_Interaction : MonoBehaviour
//{
//    public WaveVR_Controller.Device device;

//    protected GameObject selected;
//    protected GameObject pivot;
//    protected Transform startParent;
//    protected float startDistance;

//    void Start()
//    {
//        //device = WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_Controller_Right);
//        device = WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_HMD);
//        pivot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//        pivot.transform.localScale = 0.005f * Vector3.one;
//        pivot.name = "Pivot";
//        pivot.SetActive(false);
//        // WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_Controller_Right).GetAxis(WaveVR_ButtonList.EButtons.Touchpad);
//    }

    


//    // Update is called once per frame
//    void Update()
//    {
//        //GameObject.Find("Debug").GetComponent<TMPro.TextMeshPro>().text = (device.transform.pos).ToString();

//        if (device.GetPress(WVR_InputId.WVR_InputId_Alias1_Trigger))
//        {
            
//            Vector3 direction = device.transform.rot * Vector3.forward;
//            RaycastHit hit;
//            LayerMask layer = 0 << 8;

//            Debug.DrawRay(device.transform.pos, 10.0f * direction);
            

//            //if (Physics.Raycast(device.transform.pos, direction, out hit,Mathf.Infinity,layer))
//            if (Physics.Raycast(device.transform.pos, 10.0f * direction))
//            {
//                //GameObject.Find("Debug").GetComponent<TMPro.TextMeshPro>().text = "touche";
//                // Grab(hit);
//                //Destroy(hit.collider.gameObject);
//            }
//            else
//            {
//                GameObject.Find("Debug").GetComponent<TMPro.TextMeshPro>().text = "";
//            }
//        }
//        else
//        {
//            GameObject.Find("Debug").GetComponent<TMPro.TextMeshPro>().text = "";
//        }

//        if (device.GetPressUp(WVR_InputId.WVR_InputId_Alias1_Trigger) && selected != null)
//        {
//            Release();
//        }


//    }

//    protected void Grab(RaycastHit hit)
//    {
//        selected = hit.collider.gameObject;
//        selected.GetComponent<Rigidbody>().isKinematic = true;

//        pivot.transform.position = hit.point;
//        pivot.SetActive(true);

//        startParent = selected.transform.parent;
//        selected.transform.SetParent(pivot.transform);

//        startDistance = hit.distance;


//    }

//    protected void Release()
//    {
//        selected.transform.SetParent(startParent);
//        pivot.SetActive(false);
//        selected = null;
//    }

//}
