using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombstonePopupScript : MonoBehaviour
{
    public GameObject map;
    private bool activate = false;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (activate)
        {
            if (timer < 1)
            {
                timer += Time.deltaTime * 3;
                map.GetComponent<CanvasGroup>().alpha = timer;
            }
            else
            {
                timer = 1;
                activate = false;
                map.GetComponent<CanvasGroup>().alpha = 1;
                map.SetActive(true);


            }
        }

    }

    public void OpenTombstone()
    {
        if (!map.activeSelf)
        {
            activate = true;
        }
        
    }
}
