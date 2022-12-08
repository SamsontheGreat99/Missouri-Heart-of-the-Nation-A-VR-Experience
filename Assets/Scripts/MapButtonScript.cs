using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButtonScript : MonoBehaviour
{
    public GameObject map;
    public GameObject visor;
    public GameObject xrRig;
    private bool activate = false;
    private float timer = 0;
    public Transform camera;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform camera = Camera.main.transform;
        if (map.activeInHierarchy == true)
        {
            visor.SetActive(true);
        }

        if (activate)
        {
            if (timer < 1)
            {
                timer += Time.deltaTime * 3;
                map.GetComponent<CanvasGroup>().alpha = timer;
            }
            else
            {
                timer = 0;
                activate = false;
            }
        }
        
    }

    public void OpenMap()
    {
        
        if (!map.activeSelf)
        {
            map.SetActive(true);
            Debug.Log("yo");

            
            //var direction = new Vector3(camera.forward.x, camera.forward.y, camera.forward.z);
            //map.transform.LookAt(direction);

            //map.transform.position = new Vector3(xrRig.transform.position.x, xrRig.transform.position.y + .5f, xrRig.transform.position.z + 1);

           // map.transform.localEulerAngles = new Vector3(0, camera.transform.localEulerAngles.y, 0);
           // map.transform.position = new Vector3(camera.forward.x, camera.forward.y, camera.forward.z);
            map.GetComponent<CanvasGroup>().alpha = 0;
            activate = true;
        }
        else { }
    }
}
