using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorMenu : MonoBehaviour
{
    public GameObject visor;
    public Transform camera;
    public GameObject map;
    public GameObject info;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if ((camera.transform.localEulerAngles.x > 34.5f) && (camera.transform.localEulerAngles.x < 70f) || map.activeSelf == true || info.activeSelf == true)
        {
            if(visor.activeSelf == false)
            {
                visor.transform.localEulerAngles = new Vector3(0, camera.transform.localEulerAngles.y, 0);
                visor.SetActive(true);
            }
            if(timer < 1)
            {
                timer += Time.deltaTime * 3;
                visor.GetComponent<CanvasGroup>().alpha = timer;
            }
            
        }
        else
        {
            if (visor.activeSelf == true)
            {
                timer -= Time.deltaTime;
                visor.GetComponent<CanvasGroup>().alpha = timer * 3;
            }
            if (timer <= 0)
            {
                visor.SetActive(false);
            }
        }
    }
}
