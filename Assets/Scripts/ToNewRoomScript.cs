//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class ToNewRoomScript : MonoBehaviour
//{
//    public GameObject glassFade;
//    public GameObject map;
//    private bool fading, fadedOut, fadedIn;
//    private float fadeTimer = 0;
//    private float timeMultiplier = 1.0f;
//    public Button TargetButton;
//    public Transform xrRig;
//    //public Animator animator;
//    public Image blackFade;
//    private Color objectColor;
//    bool fadeToBlack = true;
//    bool fadeFromBlack = false;
//    float fadeAmount;
//    public float fadeSpeed = 1.0f;


//    public CanvasGroup csGrp;
//    // Start is called before the first frame update
//    void Start()
//    {
      
//    }

//    // Update is called once per frame
//    void Update()
//    {
       
//    }
    
//    public void Fade()
//    {
//        StartCoroutine("cor");
//    }

//    IEnumerator cor()
//    {
//        csGrp = GetComponent<CanvasGroup>();
//        csGrp.alpha = 0;
//        float time = 5f;
//        bool idk = false;

//        while(csGrp.alpha < 1)
//        {
//            csGrp.alpha += Time.deltaTime / time;
//            yield return null;
//        }
//        if(csGrp.alpha == 1)
//        {
//            xrRig.transform.position = new Vector3(currentButton.transform.position.x, currentButton.transform.position.y + 1.9f, currentButton.transform.position.z);
//            xrRig.transform.localEulerAngles = new Vector3(0, currentButton.transform.parent.gameObject.transform.localEulerAngles.y, 0);
//            idk = true;
//        }
//        if (idk == true)
//        {
//            StartCoroutine("notCor");
//            idk = false;
//        }
//    }
//    IEnumerator notCor()
//    {
//        csGrp = GetComponent<CanvasGroup>();
//        csGrp.alpha = 1;
//        float time = 5f;

//        while(csGrp.alpha > 0)
//        {
//            csGrp.alpha -= Time.deltaTime / time;
//            yield return null;
//        }
//    }
//    //private void Fade()
//    //{
//    //    //var rot = Quaternion.Euler(1, 90, 90);
//    //    if (!fadedOut && (fadeTimer < 1))
//    //    {
//    //        fading = true;
//    //        glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
//    //        fadeTimer += Time.deltaTime * timeMultiplier;
//    //        if (fadeTimer >= 1)
//    //        {
//    //            fadedOut = true;
//    //            fillImage.fillAmount = 0;
//    //        }
//    //    }
//    //    else if (fadedOut && (fadeTimer >= 1))
//    //    {

//    //        xrRig.transform.position = new Vector3(currentButton.transform.position.x, currentButton.transform.position.y + 1.9f, currentButton.transform.position.z);
//    //        xrRig.transform.localEulerAngles = new Vector3(0, currentButton.transform.parent.gameObject.transform.localEulerAngles.y, 0);
//    //        //xrRig.transform.position = currentButton.transform.position;s
//    //        map.GetComponent<CanvasGroup>().alpha = 0;
//    //        map.SetActive(false);
//    //        if (atButton != null)
//    //        {
//    //            atButton.gameObject.SetActive(true);
//    //            atButton = currentButton;
//    //            atButton.gameObject.SetActive(false);
//    //        }
//    //        fadeTimer = .99f;
//    //    }
//    //    else if (fadedOut && (fadeTimer > 0))
//    //    {
//    //        glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
//    //        fadeTimer -= Time.deltaTime * timeMultiplier;
//    //        if (fadeTimer <= 0)
//    //        {
//    //            fadedIn = true;
//    //        }
//    //    }
//    //    else if (fadedIn && fadedOut)
//    //    {
//    //        fadedOut = fadedIn = fading = false;
//    //        if (ToPlay != null)
//    //        {
//    //            cam.GetComponent<AudioSource>().clip = ToPlay;
//    //            cam.GetComponent<AudioSource>().Play();
//    //            ToPlay = null;
//    //        }
//    //    }
//    //}
//    //public void Fade()
//    //{
//    //    xrRig.transform.position = new Vector3(TargetButton.transform.position.x, TargetButton.transform.position.y + 1.9f, TargetButton.transform.position.z);
//    //    xrRig.transform.localEulerAngles = new Vector3(0, TargetButton.transform.parent.gameObject.transform.localEulerAngles.y, 0);
//    //}
//    //public void pleaseFade()
//    //{
//    //    StartCoroutine("Fade");
//    //}
//    //IEnumerator Fade()
//    //{
//    //    objectColor = blackFade.GetComponent<Image>().color;
//    //    //animator.SetTrigger("button");
//    //    if (fadeToBlack)
//    //    {
//    //        Debug.Log("first if");
//    //        while(blackFade.GetComponent<Image>().color.a < 255)
//    //        {
//    //            fadeAmount = objectColor.a + (fadeSpeed * 1);

//    //            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
//    //            blackFade.GetComponent<Image>().color = objectColor;
//    //            Debug.Log("hey");
//    //            yield return null;
//    //        }
//    //    }
//    //    else
//    //    {
//    //        while (blackFade.GetComponent<Image>().color.a > 0)
//    //        {
//    //            fadeAmount = objectColor.a - (fadeSpeed * 1);

//    //            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
//    //            blackFade.GetComponent<Image>().color = objectColor;
//    //            Debug.Log("bye");
//    //            yield return null;
//    //        }
//    //    }


































//    //    if (!fadedOut && (fadeTimer < 1))
//    //    {
//    //        fading = true;
//    //        while (fading)
//    //        {
//    //            glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
//    //            fadeTimer += Time.deltaTime / timeMultiplier;
//    //            if(fadeTimer >= 1)
//    //            {
//    //                break;
//    //            }
//    //            Debug.Log(fadeTimer);
//    //        }
//    //        Debug.Log("broken");
//    //        if (fadeTimer >= .95)
//    //        {
//    //            fadedOut = true;
//    //            Debug.Log(fadedOut);
//    //        }

//    //    }
//    //    if (fadedOut && (fadeTimer >= .95))
//    //    {
//    //        Debug.Log("hey");
//    //        xrRig.transform.position = new Vector3(TargetButton.transform.position.x, TargetButton.transform.position.y + 1.9f, TargetButton.transform.position.z);
//    //        xrRig.transform.localEulerAngles = new Vector3(0, TargetButton.transform.localEulerAngles.y, 0);

//    //        //map.GetComponent<CanvasGroup>().alpha = 0;
//    //        //map.SetActive(false);

//    //        while (true)
//    //        {
//    //            Debug.Log("Second While Loop");
//    //            glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
//    //            fadeTimer -= Time.deltaTime / timeMultiplier;
//    //            if (fadeTimer <= 0)
//    //            {
//    //                break;
//    //            }
//    //        }
//    //    }
//    //    if (fadedOut && (fadeTimer > 0))
//    //    {
//    //        while (fading)
//    //        {
//    //            glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
//    //            fadeTimer -= Time.deltaTime * timeMultiplier;
//    //            if (fadeTimer <= 0)
//    //            {
//    //                break;
//    //            }
//    //        }
//    //        if (fadeTimer <= 0)
//    //        {
//    //            fadedIn = true;
//    //        }
//    //    }
//    //    if (fadedIn && fadedOut)
//    //    {
//    //        fadedOut = fadedIn = fading = false;
//    //    }
//    //    //xrRig.transform.position = new Vector3(TargetButton.transform.position.x, TargetButton.transform.position.y + 1.9f, TargetButton.transform.position.z);
//    //    //xrRig.transform.localEulerAngles = new Vector3(0, TargetButton.transform.localEulerAngles.y, 0);

//}
//    //private void Fade()
//    //{
//    //    //var rot = Quaternion.Euler(1, 90, 90);
//    //    if (!fadedOut && (fadeTimer < 1))
//    //    {
//    //        fading = true;
//    //        glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
//    //        fadeTimer += Time.deltaTime * timeMultiplier;
//    //        if (fadeTimer >= 1)
//    //        {
//    //            fadedOut = true;
//    //        }
//    //    }
//    //    else if (fadedOut && (fadeTimer >= 1))
//    //    {
//    //        xrRig.transform.position = new Vector3(TargetButton.transform.position.x, TargetButton.transform.position.y + 1.9f, TargetButton.transform.position.z);
//    //        xrRig.transform.localEulerAngles = new Vector3(0, TargetButton.transform.localEulerAngles.y, 0);

//    //        map.GetComponent<CanvasGroup>().alpha = 0;
//    //        map.SetActive(false);

//    //        fadeTimer = .99f;
//    //    }
//    //    else if (fadedOut && (fadeTimer > 0))
//    //    {
//    //        glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
//    //        fadeTimer -= Time.deltaTime * timeMultiplier;
//    //        if (fadeTimer <= 0)
//    //        {
//    //            fadedIn = true;
//    //        }
//    //    }
//    //    else if (fadedIn && fadedOut)
//    //    {
//    //        fadedOut = fadedIn = fading = false;
//    //    }
//    //}
////}
