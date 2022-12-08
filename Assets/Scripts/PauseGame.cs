using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Linq;

public class PauseGame : MonoBehaviour
{
    public class Callback : UnityEvent<Ray, RaycastHit> { }
    [SerializeField]
    private XRNode xrNodeL = XRNode.LeftHand;
    private XRNode xrNodeR = XRNode.RightHand;
    private InputDeviceRole inputDevice;
    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device;
    public Transform leftHandAnchor = null;
    public Transform rightHandAnchor = null;
    public Transform centerEyeAnchor = null;
    bool isPaused = false;

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

    //we can create a Pointer of type transform and assign the left or right to be active
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
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (!device.isValid)//checking again to make sure device is assigned
        //{
        //    GetDevice();
        //}
        //bool menuButtonState = false;
        //bool menu = false;
        //if(device.TryGetFeatureValue(CommonUsages.menuButton, out menuButtonState) && menuButtonState && !menu)
        //{
        //    Pause();
        //    menu = true;
        //}
        //if (device.TryGetFeatureValue(CommonUsages.menuButton, out menuButtonState) && menuButtonState && menu)
        //{
        //    Unpause();
        //    menu = false;
        //}

        

    }

    private void OnApplicationFocus(bool focus)
    {
        isPaused = !focus;
        if (isPaused)
        {
            Time.timeScale = 0;
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
            // Debug.Log(Time.timeScale);
        }
        else
        {
            Time.timeScale = 1;
            //  Debug.Log(Time.timeScale);

        }
        Debug.Log("focus event");
    }
    private void OnApplicationPause(bool pause)
    {
        isPaused = pause;
        if (isPaused)
        {
            Time.timeScale = 0;
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
            //AudioSource.pause = true;
            // Debug.Log(Time.timeScale);
        }
        else
        {
            Time.timeScale = 1;
            //  Debug.Log(Time.timeScale);

        }
        Debug.Log("pause event");
    }
    void Pause()
    {
        Debug.Log("Pause Button Pressed");
        Time.timeScale = 0;
        AudioListener.pause = true;
        Camera.main.enabled = false;

    }
    void Unpause()
    {
        Debug.Log("Unpause button pressed");
        Time.timeScale = 1;
        AudioListener.pause = false;
        Camera.main.enabled = true;
    }
}
