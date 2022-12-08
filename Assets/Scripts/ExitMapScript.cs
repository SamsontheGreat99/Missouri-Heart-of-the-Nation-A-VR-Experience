using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMapScript : MonoBehaviour
{
    public GameObject map;
    private bool deactivate = false;
    private float timer = 1;

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
                
            }
        }

    }

    public void CloseMap()
    {
        if (map.activeSelf)
        {
            deactivate = true;
        }
        else { }
    }
}
