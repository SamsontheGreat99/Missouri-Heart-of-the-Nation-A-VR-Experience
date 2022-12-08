using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    public Transform xrRig;
    public GameObject blackPanel;
    private float threshold = 0.0f;
    Vector3 lastPos;
    public float fadeSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = xrRig.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 offset = xrRig.position - lastPos;
        if (offset.x > threshold)
        {
            Color color = blackPanel.GetComponent <MeshRenderer> ().material.color;
            color.a -= Time.deltaTime * fadeSpeed;
            blackPanel.GetComponent <MeshRenderer> ().material.color = color;
            lastPos = xrRig.position;
        }
    }
}
