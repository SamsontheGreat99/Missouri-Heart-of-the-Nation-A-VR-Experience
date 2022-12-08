using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Linq;

public class leftHandController : MonoBehaviour
{
    [SerializeField]
    private XRNode xrNodeL = XRNode.LeftHand;
    private InputDevice device;
    private List<InputDevice> devices = new List<InputDevice>();
    private bool triggerValue = false;
    public Transform leftHandAnchor = null;
    bool primaryButton;
    public GameObject mag;

    // Start is called before the first frame update
    void Start()
    {
        if (!device.isValid)
        {
            GetDevice();
        }
    }

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xrNodeL, devices);
        device = devices.FirstOrDefault();
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if(device.TryGetFeatureValue(CommonUsages.primaryButton , out primaryButton) && primaryButton)
        {
            if(primaryButton)
            {
                mag.SetActive(true);
            }

        }
        if (!primaryButton)
        {
            mag.SetActive(false);
        }
    }
}
