using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInstructScript : MonoBehaviour
{
    public GameObject map;
    public GameObject cam;
    private bool deactivate = false;
    //private bool nextPage = false;
    private float timer = 1;
    public AudioClip introClip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (deactivate)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime * 3;
                map.GetComponent<CanvasGroup>().alpha = timer;
            }
            else
            {
                timer = 1;
                deactivate = false;
                map.GetComponent<CanvasGroup>().alpha = 0;
                map.SetActive(false);
                cam.GetComponent<AudioSource>().clip = introClip;
                cam.GetComponent<AudioSource>().Play();


            }
        }
        //if (nextPage)
        //{
        //    if (timer > 0)
        //    {
        //        timer -= Time.deltaTime * 3;
        //        map.GetComponent<CanvasGroup>().alpha = timer;
        //    }
        //    else
        //    {
        //        timer = 1;
        //        nextPage = false;

        //    }
        //}
    }

    public void CloseMap()
    {
        if (map.activeSelf)
        {
            deactivate = true;
        }
        else { }
    }
    //public void NextPage()
    //{
    //    if (map.activeSelf)
    //    {
    //        nextPage = true;
    //    }
    //    else { }
    //}
}
