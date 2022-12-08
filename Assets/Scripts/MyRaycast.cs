using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MyRaycast : MonoBehaviour
{
    private Transform camera;
    public Transform cameraOffset;
    public GameObject cam;
    public float maxRayDistance = 500.0f;
    public LayerMask excludeLayers;
    public Button hitButton;
    public Button currentButton;
    public Button atButton = null;
    private float fadeTimer = 0;
    private float timer = 0;
    private float fill = 0;
    public float timeMultiplier = 2.0f;
    public Image fillImage;
    public Transform xrRig;
    public GameObject glassFade;
    private bool fading, fadedOut, fadedIn;
    public GameObject map;
    //public GameObject[] paintings;
    public GameObject visor;

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

    private bool STLPlayed = true;
    private bool RivPlayed = true;
    private bool IndPlayed = true;
    private bool AgPlayed = true;
    private bool KCPlayed = true;
    private bool PeoPlayed = true;
    private bool TowPlayed = true;
    // Start is called before the first frame update
    void awake()
    {
        Vector3 temp = new Vector3(0, -.5f, 0);
        cameraOffset.position += temp;
    }
    void Start()
    {
        camera = Camera.main.transform;
        fading = false;
        Vector3 temp = new Vector3(0, -.5f, 0);
        cameraOffset.position += temp;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray(camera.position, camera.transform.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRayDistance, ~excludeLayers))
        {
            if ((hit.transform.gameObject.tag == "Button") && !fading)
            {
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
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
                    Fade();
                    timer = 0;
                }
            }
            else if ((hit.transform.gameObject.tag == "STLButton") && !fading)
            {
                hitButton = hit.transform.gameObject.GetComponent<Button>();
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
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
                    Fade();
                    hitButton.onClick.Invoke();
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
                hitButton = hit.transform.gameObject.GetComponent<Button>();
                //hitButton.OnPointerExit(new PointerEventData(EventSystem.current));
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
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
                    
                    Fade();
                    hitButton.onClick.Invoke();
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
                hitButton = hit.transform.gameObject.GetComponent<Button>();
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
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
                    
                    Fade();
                    hitButton.onClick.Invoke();
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
                hitButton = hit.transform.gameObject.GetComponent<Button>();
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
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
                    
                    Fade();
                    hitButton.onClick.Invoke();
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
                hitButton = hit.transform.gameObject.GetComponent<Button>();
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
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
                    
                    Fade();
                    hitButton.onClick.Invoke();
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
                hitButton = hit.transform.gameObject.GetComponent<Button>();
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
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
                    
                    Fade();
                    hitButton.onClick.Invoke();
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
                hitButton = hit.transform.gameObject.GetComponent<Button>();
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
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
                    
                    Fade();
                    hitButton.onClick.Invoke();
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
                hitButton = hit.transform.gameObject.GetComponent<Button>();
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
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

                    Fade();
                    hitButton.onClick.Invoke();
                    timer = 0;
                }
            }
            else if ((hit.transform.gameObject.tag == "ActiveButton") && !fading)
            {
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
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
           /* else if ((hit.transform.gameObject.tag == "painting") && !fading)
                { 
                timer += Time.deltaTime;
                fill = (timer / 2);
                fillImage.fillAmount = fill;
                //create a timer using Time.delta
                //xrRig.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.z);
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
            */
                else
                {
                    timer = 0;
                    fillImage.fillAmount = timer;
                }

                }
                else
                {
                 if (!fading)
                 {
                    timer = 0;
                    fillImage.fillAmount = timer;
                 }
            }
                if (fading)
                {
                    Fade();
                }
            if (Physics.Raycast(ray, out hit, maxRayDistance, ~excludeLayers))
            {
            if (hit.transform.gameObject.tag == "tombstone")
                {
                visor.SetActive(true);
                }
            }
        }
    
private void Fade()
    {
        //var rot = Quaternion.Euler(1, 90, 90);
        if (!fadedOut && (fadeTimer < 1))
        {
            fading = true;
            glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
            fadeTimer += Time.deltaTime * timeMultiplier;
            if (fadeTimer >= 1)
            {
                fadedOut = true;
                fillImage.fillAmount = 0;
            }
        }
        else if (fadedOut && (fadeTimer >= 1))
        {
            
            xrRig.transform.position = new Vector3(currentButton.transform.position.x, currentButton.transform.position.y + 1.9f, currentButton.transform.position.z);
            xrRig.transform.localEulerAngles = new Vector3(0, currentButton.transform.parent.gameObject.transform.localEulerAngles.y, 0);
            //xrRig.transform.position = currentButton.transform.position;s
            map.GetComponent<CanvasGroup>().alpha = 0;
            map.SetActive(false);    
            if(atButton != null)
            {
                atButton.gameObject.SetActive(true);
                atButton = currentButton;
                atButton.gameObject.SetActive(false);
            }
            fadeTimer = .99f;
        }
        else if (fadedOut && (fadeTimer > 0))
        {
            glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
            fadeTimer -= Time.deltaTime * timeMultiplier;
            if (fadeTimer <= 0)
            {
                fadedIn = true;
            }
        }
        else if (fadedIn && fadedOut)
        {
            fadedOut = fadedIn = fading = false;
            if (ToPlay != null)
            {
                cam.GetComponent<AudioSource>().clip = ToPlay;
                cam.GetComponent<AudioSource>().Play();
                ToPlay = null;
            }
        }
    }
}