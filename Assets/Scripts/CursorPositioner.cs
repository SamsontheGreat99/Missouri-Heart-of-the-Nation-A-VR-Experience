using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour
{
    public GameObject cursor;
    private float scaleFactor = 0.0005f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "painting")
            {
                cursor.SetActive(false);
            }
            else
            {
                cursor.SetActive(true);
                cursor.transform.localPosition = new Vector3(0, 0, hit.distance * .95f);
                float size = hit.distance * scaleFactor;
                cursor.transform.localScale = new Vector3(size, size);
            }
        }
    }
}
