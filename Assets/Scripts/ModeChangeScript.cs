using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeChangeScript : MonoBehaviour
{
    public GameObject glassFade;
    private bool fading, fadedOut, fadedIn = false;
    private float fadeTimer = 0;
    public string LevelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fading)
        {
            Fade();
        }
        if (fadedOut)
        {
            Application.LoadLevel(LevelToLoad);
            SceneManager.LoadScene(LevelToLoad);
        }
    }

    public void Fade()
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

