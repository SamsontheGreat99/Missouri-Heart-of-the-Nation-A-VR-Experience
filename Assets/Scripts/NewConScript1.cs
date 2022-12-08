using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;
using UnityEngine.AI;

public class NewConScript1 : MonoBehaviour
{
    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device;
    public Transform leftHandAnchor = null;
    public Transform rightHandAnchor = null;
    public Transform centerEyeAnchor = null;
    private XRNode xrNodeL = XRNode.LeftHand;
    private XRNode xrNodeR = XRNode.RightHand;
    public float maxRayDistance = 500f;
    public LayerMask excludeLayers;
    private char[] codex = { 'K', 'S', 'R', 'A', 'I', 'P', 'T', 'L' };
    bool primaryButton;
    public Transform xrRig;
    public GameObject glassFade;
    bool idk = false;
    bool idk2 = false;

    private Transform camera;
    private bool fading;
    void GetDevice()
    {
        //Add InputDevices here
        InputDevices.GetDevicesAtXRNode(xrNodeL, devices);
        InputDevices.GetDevicesAtXRNode(xrNodeR, devices);
        device = devices.FirstOrDefault();

    }

    void OnEnable()
    {
        //Check if devices is enabled then enable it
        if (!device.isValid)
        {
            GetDevice();
        }

    }

    //In the awake we will find the left and right hand controllers and assign them to anchors
    private void Awake()
    {


        if (leftHandAnchor == null)
        {
            Debug.LogWarning("Assign LeftHandAnchor in the inspector!");
            GameObject left = GameObject.Find("LeftHand Controller");
            if (left != null)
            {
                leftHandAnchor = left.transform;
            }
        }
        if (rightHandAnchor == null)
        {
            Debug.LogWarning("Assign RightHandAnchor in the inspector!");
            GameObject right = GameObject.Find("RightHand Controller");
            if (right != null)
            {
                rightHandAnchor = right.transform;
            }
        }
        if (centerEyeAnchor == null)
        {
            Debug.LogWarning("Assign CenterEyeAnchor in the inspector!");
            GameObject center = GameObject.Find("CenterEyeAnchor");
            if (center != null)
            {
                centerEyeAnchor = center.transform;
            }
        }
    }
    Transform Pointer
    {
        get
        {
            if (rightHandAnchor == null)
            {
                return leftHandAnchor;
            }

            return rightHandAnchor;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        fading = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!device.isValid)
        {
            GetDevice();
        }

        Transform pointer = Pointer;
        if (pointer == null)
        {
            return;
        }


        Ray ray = new Ray(pointer.position, pointer.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, maxRayDistance, ~excludeLayers))
        {
            if(hit.collider.gameObject.tag == "NewRoom" && device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButton) && primaryButton)
            {
                Debug.Log("hello");
                GameObject tpPoint = hit.collider.gameObject.transform.GetChild(0).gameObject;
                StartCoroutine("cor");
                if (idk == true)
                {
                    xrRig.transform.position = new Vector3(tpPoint.transform.position.x, tpPoint.transform.position.y + 1.9f, tpPoint.transform.position.z);
                    xrRig.transform.localEulerAngles = new Vector3(0, tpPoint.transform.parent.gameObject.transform.localEulerAngles.y, 0);
                    StartCoroutine("notCor");
                }

            }
        }
    }
    public CanvasGroup csGrp;
    IEnumerator cor()
    {
        csGrp = glassFade.GetComponent<CanvasGroup>();
        //Debug.Log("first alpha" + csGrp.alpha);
        csGrp.alpha = 0;
        float time = 1f;
        
        //Debug.Log(idk);

        while (csGrp.alpha < 1)
        {
            csGrp.alpha += Time.deltaTime / time;
            //Debug.Log(csGrp.alpha);
            yield return null;
        }
        if (csGrp.alpha == 1)
        {
            idk = true;
        }
    }
    IEnumerator notCor()
    {
        csGrp = glassFade.GetComponent<CanvasGroup>();
        csGrp.alpha = 1;
        float time = 1f;

        while (csGrp.alpha > 0)
        {
            csGrp.alpha -= Time.deltaTime / time;
            // Debug.Log(csGrp.alpha);
            yield return null;
            //Debug.Log(time);
        }
        if(csGrp.alpha == 0)
        {
            idk = false;
        }
    }
}
