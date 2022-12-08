using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject pauseObject;
    private AudioSource audioSource; // assuming music is attached to this GO
    
    public Camera cam;
    bool bPause = false;
    public Button pauseButton;
    public Button playButton;
    void Update()
    {
        
        //install 'Oculus Integration' for this to work
        bool bPauseNow = !(OVRManager.hasInputFocus && OVRManager.hasVrFocus);

        //pause state change
        if (Camera.main != null) cam = Camera.main;
        
        if (bPause != bPauseNow)
        {
            bPause = bPauseNow;
            if (bPauseNow)
            {
                Time.timeScale = 0.0f; //stops FixedUpdate

                //Update keeps running, but 
                // rendering must also be paused to pass vrc
                cam.enabled = false;
                cam.GetComponent<AudioListener>().enabled = false;
                pauseButton.onClick.Invoke();
            }
            else
            {
                Time.timeScale = 1.0f;

                //
                cam.enabled = true;
                cam.GetComponent<AudioListener>().enabled = true;
                playButton.onClick.Invoke();
            }
        }

        //...
    }
    private void PauseGame()
    {
        if (pauseObject != null)
            pauseObject.SetActive(true);
        Time.timeScale = 0.0f;
        if (audioSource != null)
            audioSource.Pause();
    }

    private void UnPauseGame()
    {
        if (OVRManager.hasVrFocus)
        {
            if (pauseObject != null)
                pauseObject.SetActive(false);
            Time.timeScale = 1.0f;
            if (audioSource != null)
                audioSource.UnPause();
        }
    }
}




//private void OnEnable()
//{
//    OVRManager.HMDUnmounted += PauseGame;
//    OVRManager.HMDMounted += UnPauseGame;
//    OVRManager.VrFocusLost += PauseGame;
//    OVRManager.VrFocusAcquired += UnPauseGame;
//    audioSource = GetComponent<AudioSource>();
//}

//private void OnDisable()
//{
//    OVRManager.HMDUnmounted -= PauseGame;
//    OVRManager.HMDMounted -= UnPauseGame;
//    OVRManager.VrFocusLost -= PauseGame;
//    OVRManager.VrFocusAcquired -= UnPauseGame;
//}

//private void Update()
//{
//    if (!OVRManager.hasVrFocus || !OVRManager.isHmdPresent || !OVRManager.hasInputFocus)
//    {
//        PauseGame();
//    }
//    else
//    {
//        UnPauseGame();
//    }
//}