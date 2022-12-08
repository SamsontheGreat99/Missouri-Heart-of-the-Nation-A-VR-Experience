using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MenuRaycast : MonoBehaviour
{
    private Transform camera;
    public float maxRayDistance = 500.0f;
    public LayerMask excludeLayers;
    public Button hitButton;
    public Button currentButton;
    private float fadeTimer = 0;
    private float timer = 0;
    private float fill = 0;
    public Image fillImage;
    public Transform xrRig;
    public GameObject glassFade;
    private bool fading, fadedOut, fadedIn;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        fading = false;
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
                fill = (timer / 3);
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
           
                if (timer >= 3)
                {
                    Fade();
                    timer = 0;
                    // use onClick.Invoke(); to activate your button
                }
            }
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
        if(fadedOut == true)
        {
            currentButton.onClick.Invoke();
        }
    }

    private void Fade()
    {
        if (!fadedOut && (fadeTimer < 1))
        {
            
            fading = true;
            glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
            fadeTimer += Time.deltaTime;
            if (fadeTimer >= 1)
            {
                fadedOut = true;
                fading = false;
            }
        }
        else if (fadedOut && (fadeTimer >= 1))
        {
            fadeTimer = .99f;            
        }
        else if (fadedOut && (fadeTimer > 0))
        {
            glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
            fadeTimer -= Time.deltaTime;
            if (fadeTimer <= 0)
            {
                fadedIn = true;
            }
        }
        else if (fadedIn && fadedOut)
        {
            fadedOut = fadedIn = fading = false;
        }
    }
}
