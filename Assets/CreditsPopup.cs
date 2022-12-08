using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPopup : MonoBehaviour
{
    public GameObject xrRig;
    public GameObject self;
    public GameObject credits;
    Vector3 xrPos;
    Vector3 selfPos;
    public float scaleFactor = 5f;
    // Start is called before the first frame update
    void Start()
    {
        selfPos = new Vector3(self.transform.position.x, self.transform.position.y, self.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xrPos = new Vector3(xrRig.transform.position.x, xrRig.transform.position.y, xrRig.transform.position.z);

        if (Vector3.Distance(selfPos, xrPos) > scaleFactor)
        {
            credits.SetActive(false);
        }
        if (Vector3.Distance(selfPos, xrPos) < scaleFactor)
        {
            //Debug.Log("within range");
            credits.SetActive(true);
        }
    }
}
