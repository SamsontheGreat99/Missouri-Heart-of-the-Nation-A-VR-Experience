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
using UnityEngine.Audio;
public class ConScript : MonoBehaviour
    {
    private Transform camera;
    public Transform cameraOffset;
    private float timer;
    public GameObject cam;
    public float maxRayDistance = 500.0f;
    public LayerMask excludeLayers;
    public Button hitButton;
    private GameObject myObjectTeleport;
    public Button currentButton;
    public Button atButton = null;
    private float fadeTimer = 0;
    public Transform xrRig;
    public GameObject glassFade;
    private bool fading, fadedOut, fadedIn;
    public GameObject map;
    //public GameObject[] paintings;
    public GameObject visor;
    [System.Serializable]
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
    bool triggerValue;

    public Button LobbyButton;
    public Button STLButton;
    public Button RiversButton;
    public Button IndustryButton;
    public Button AgricultureButton;
    public Button KCButton;
    public Button PeopleButton;
    public Button TownsButton;

    public AudioClip STLAudio;
    public AudioClip RivAudio;
    public AudioClip IndAudio;
    public AudioClip AgAudio;
    public AudioClip KCAudio;
    public AudioClip PeoAudio;
    public AudioClip TowAudio;
    private AudioClip ToPlay = null;

    private bool STLPlayed = false;
    private bool RivPlayed = false;
    private bool IndPlayed = false;
    private bool AgPlayed = false;
    private bool KCPlayed = false;
    private bool PeoPlayed = false;
    private bool TowPlayed = false;

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
        //glassFade.canvasRenderer.SetAlpha(0.0f);
        camera = Camera.main.transform;
        fading = false;
        Vector3 temp = new Vector3(0, -.5f, 0);
        cameraOffset.position += temp;
    }
    // Update is called once per frame
    void FixedUpdate()
        {
        if (!device.isValid)//checking again to make sure device is assigned
            {
            GetDevice();
            }

        Transform pointer = Pointer;
        if (pointer == null)
            {
            return;
            }
        Ray rayPointer = new Ray(pointer.position, pointer.forward);
        Ray ray = new Ray(pointer.position, pointer.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRayDistance, ~excludeLayers))
            {
            if ((hit.transform.gameObject.tag == "Button") && !fading)
                {
                //create a timer using Time.delta
                hitButton = hit.transform.parent.gameObject.GetComponent<Button>();
                if (currentButton != null)
                    {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to
                    // turn off the highlights
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                currentButton = hitButton; // this asigns the Button that you are
                                           // currently using
                if ((currentButton != null) && !fading)
                    {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))
                    //  for the highlight when hovering
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    }

                if (timer >= 2)
                    {
                    //Fade();
                    timer = 0;
                    }
                }
            else if ((hit.transform.gameObject.tag == "STLButton") && !fading)
                {
       
                //create a timer using Time.delta
                if (currentButton != null)
                    {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to
                    // turn off the highlights
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                currentButton = STLButton; // this asigns the Button that you are
                                           // currently using

                if ((currentButton != null) && !fading)
                    {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))
                    //  for the highlight when hovering
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    }

                if (timer >= 2)
                    {
                    //Fade();
                    timer = 0;
                    if (!STLPlayed)
                        {
                        ToPlay = STLAudio;
                        STLPlayed = true;
                        }
                    else
                        {
                        ToPlay = null;
                        }
                    }
                }
            else if ((hit.transform.gameObject.tag == "RivButton") && !fading)
                {
                
                //create a timer using Time.delta
                if (currentButton != null)
                    {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to
                    // turn off the highlights
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                currentButton = RiversButton; // this asigns the Button that you are
                                              // currently using

                if ((currentButton != null) && !fading)
                    {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))
                    //  for the highlight when hovering
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    }

                if (timer >= 2)
                    {

                    //Fade();
                    timer = 0;
                    if (!RivPlayed)
                        {
                        ToPlay = RivAudio;
                        RivPlayed = true;
                        }
                    else
                        {
                        ToPlay = null;
                        }
                    }
                }
            else if ((hit.transform.gameObject.tag == "IndButton") && !fading)
                {
               
                //create a timer using Time.delta
                if (currentButton != null)
                    {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to
                    // turn off the highlights
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                currentButton = IndustryButton; // this asigns the Button that you are
                                                // currently using

                if ((currentButton != null) && !fading)
                    {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))
                    //  for the highlight when hovering
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    }

                if (timer >= 2)
                    {
                    StartCoroutine("Fade");
                    //Fade();
                    timer = 0;
                    if (!IndPlayed)
                        {
                        ToPlay = IndAudio;
                        IndPlayed = true;
                        }
                    else
                        {
                        ToPlay = null;
                        }
                    }
                }
            else if ((hit.transform.gameObject.tag == "AgButton") && !fading)
                {
               
                //create a timer using Time.delta
                if (currentButton != null)
                    {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to
                    // turn off the highlights
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                currentButton = AgricultureButton; // this asigns the Button that you are
                                                   // currently using

                if ((currentButton != null) && !fading)
                    {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))
                    //  for the highlight when hovering
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    }

                if (timer >= 2)
                    {

                    //Fade();
                    timer = 0;
                    if (!AgPlayed)
                        {
                        ToPlay = AgAudio;
                        AgPlayed = true;
                        }
                    else
                        {
                        ToPlay = null;
                        }
                    }
                }
            else if ((hit.transform.gameObject.tag == "KCButton") && !fading)
                {
               
                //create a timer using Time.delta
                if (currentButton != null)
                    {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to
                    // turn off the highlights
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                currentButton = KCButton; // this asigns the Button that you are
                                          // currently using

                if ((currentButton != null) && !fading)
                    {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))
                    //  for the highlight when hovering
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    }

                if (timer >= 2)
                    {

                    //Fade();
                    timer = 0;
                    if (!KCPlayed)
                        {
                        ToPlay = KCAudio;
                        KCPlayed = true;
                        }
                    else
                        {
                        ToPlay = null;
                        }
                    }
                }
            else if ((hit.transform.gameObject.tag == "PeoButton") && !fading)
                {
                
                //create a timer using Time.delta
                if (currentButton != null)
                    {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to
                    // turn off the highlights
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                currentButton = PeopleButton; // this asigns the Button that you are
                                              // currently using

                if ((currentButton != null) && !fading)
                    {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))
                    //  for the highlight when hovering
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    }

                if (timer >= 2)
                    {

                    //Fade();
                    timer = 0;
                    if (!PeoPlayed)
                        {
                        ToPlay = PeoAudio;
                        PeoPlayed = true;
                        }
                    else
                        {
                        ToPlay = null;
                        }
                    }
                }
            else if ((hit.transform.gameObject.tag == "TowButton") && !fading)
                {
                
                //create a timer using Time.delta
                if (currentButton != null)
                    {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to
                    // turn off the highlights
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                currentButton = TownsButton; // this asigns the Button that you are
                                             // currently using

                if ((currentButton != null) && !fading)
                    {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))
                    //  for the highlight when hovering
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    }

                if (timer >= 2)
                    {

                    //Fade();
                    timer = 0;
                    if (!TowPlayed)
                        {
                        ToPlay = TowAudio;
                        TowPlayed = true;
                        }
                    else
                        {
                        ToPlay = null;
                        }
                    }
                }
            else if ((hit.transform.gameObject.tag == "LobButton") && !fading)
                {
                
                //create a timer using Time.delta
                if (currentButton != null)
                    {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to
                    // turn off the highlights
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                currentButton = LobbyButton; // this asigns the Button that you are
                                             // currently using

                ToPlay = null;

                if ((currentButton != null) && !fading)
                    {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))
                    //  for the highlight when hovering
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    }

                if (timer >= 2)
                    {

                    //Fade();
                    timer = 0;
                    }
                }
            else if ((hit.transform.gameObject.tag == "ActiveButton") && !fading)
                {
                hitButton = hit.transform.parent.gameObject.GetComponent<Button>();
                //create a timer using Time.delta
                hitButton = hit.transform.parent.gameObject.GetComponent<Button>();
                if (currentButton != null)
                    {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to
                    // turn off the highlights
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                currentButton = hitButton; // this asigns the Button that you are
                                           // currently using
                if ((currentButton != null) && !fading)
                    {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))
                    //  for the highlight when hovering
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    }

                if (timer >= 2)
                    {
                    currentButton.onClick.Invoke();
                    timer = 0;
                    }
                }
            

            }
        else
            {
            if (!fading)
                {
                timer = 0;
                }
            }
        if (fading)
            {
            //Fade();
            }
        if (Physics.Raycast(ray, out hit, maxRayDistance, ~excludeLayers))
            {
            if (hit.transform.gameObject.tag == "tombstone")
                {
                visor.SetActive(true);
                }
            }
        bool menuButtonState;
        bool menu = false;

    
        if (device.TryGetFeatureValue(CommonUsages.menuButton, out menuButtonState) && menuButtonState)
        {
            Debug.Log("I am pressed");
            if (!menu)
            {
                Pause();
                menu = true;
            }
            else
            {
                Unpause();
                menu = false;
            }
       
        }

    }

    private bool cooldown = false;
    public void Fade(GameObject gameObject)
        {
        if (cooldown == false)
        {
            Invoke("ResetCoolDown", 1.0f);
            cooldown = true;
            //Debug.Log(cooldown);
            map.SetActive(false);
            StartCoroutine("cor", gameObject);
        }
        else
        {

        }
        
    }
    void ResetCoolDown()
    {
        cooldown = false;
        //Debug.Log(cooldown);
    }
 

    public CanvasGroup csGrp;
    IEnumerator cor(GameObject gameObject)
    {
        csGrp = glassFade.GetComponent<CanvasGroup>();
        //Debug.Log("first alpha" + csGrp.alpha);
        csGrp.alpha = 0;
        float time = 1f;
        bool idk = false;
        //Debug.Log(idk);

        while (csGrp.alpha < 1)
        {
            csGrp.alpha += Time.deltaTime / time;
            //Debug.Log(csGrp.alpha);
            yield return null;
        }
        if (csGrp.alpha >= .95f)
        {
            xrRig.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.9f, gameObject.transform.position.z);
            xrRig.transform.localEulerAngles = new Vector3(0, gameObject.transform.parent.gameObject.transform.localEulerAngles.y, 0);
            idk = true;
            Debug.Log(gameObject);
        }
        if (idk == true)
        {
            StartCoroutine("notCor");
            idk = false;
            //Debug.Log(idk);
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






























































//var rot = Quaternion.Euler(1, 90, 90);
//if (!fadedOut && (fadeTimer < 1))
//    {
//    fading = true;
//    glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
//    fadeTimer += Time.deltaTime;
//    //yield return null;
//    if (fadeTimer >= 1)
//        {
//        fadedOut = true;
//        Debug.Log("1");
//        }
//    }
//else if (fadedOut && (fadeTimer >= 1))
//    {
//    //glassFade.CrossFadeAlpha(1, 1f, false);
//    xrRig.transform.position = new Vector3(currentButton.transform.position.x, currentButton.transform.position.y + 1.9f, currentButton.transform.position.z);
//    xrRig.transform.localEulerAngles = new Vector3(0, currentButton.transform.parent.gameObject.transform.localEulerAngles.y, 0);
//    Debug.Log("2");
//    //xrRig.transform.position = currentButton.transform.position;s
//    map.GetComponent<CanvasGroup>().alpha = 0;
//    map.SetActive(false);
//    //glassFade.CrossFadeAlpha(0, 1f, false);
//    if (atButton != null)
//        {
//        atButton.gameObject.SetActive(true);
//        atButton = currentButton;
//        atButton.gameObject.SetActive(false);
//        }
//    fadeTimer = .99f;
//    }
//else if (fadedOut && (fadeTimer > 0))
//    {
//    glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
//    fadeTimer -= Time.deltaTime;
//    //yield return null;
//    if (fadeTimer <= 0)
//        {
//        fadedIn = true;
//        Debug.Log("3");
//        }
//    }
//else if (fadedIn && fadedOut)
//    {
//    fadedOut = fadedIn = fading = false;
//    if (ToPlay != null)
//        {
//        cam.GetComponent<AudioSource>().clip = ToPlay;
//        cam.GetComponent<AudioSource>().Play();
//        ToPlay = null;
//        }
//    }