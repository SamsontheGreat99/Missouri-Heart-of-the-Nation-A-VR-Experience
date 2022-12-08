using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Linq;

public class MagnifyingGlass : MonoBehaviour
{
    [SerializeField]
    private XRNode xrNodeL = XRNode.LeftHand;
    private InputDeviceRole inputDevice;
    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device;
    private bool triggerValue;
    public Transform leftHandAnchor = null;
    bool primaryButton;
    public GameObject mag;
    bool tempState = false;
    private bool lastButtonState = false;


    // Start is called before the first frame update
    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xrNodeL, devices);
        device = devices.FirstOrDefault();
    }
    void Start()
    {
        if (!device.isValid)
        {
            GetDevice();
        }
        //Debug.Log(device);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (device.TryGetFeatureValue(CommonUsages.primaryButton , out primaryButton) && primaryButton)
        {
            //Debug.Log(primaryButton);
            if (tempState != primaryButton)
            {
                mag.SetActive(true);
            }
            else if (tempState == primaryButton)
            {
                mag.SetActive(false);
            }
        }
    }
    
}
