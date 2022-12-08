using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialFadeOut : MonoBehaviour
{
    private float fadeTimer = 1;
    private bool completed = false;
    public GameObject glassFade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!completed)
        {
            glassFade.GetComponent<CanvasGroup>().alpha = fadeTimer;
            fadeTimer -= Time.deltaTime;
            if (fadeTimer <= 0)
            {
                completed = true;
            }
        }
    }
}
