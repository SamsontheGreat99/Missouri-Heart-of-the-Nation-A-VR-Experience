using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Idea : MonoBehaviour
{
    private Transform xrRigPosition;
    public Transform xrRig;
    public GameObject[] tombstones;
    private GameObject[] tombPos;
    public float x;
    public float y;
    Vector3 position;
    Vector3 newPosition;
    public float scaleFactor = 1f;
    public GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(xrRig.position.x, xrRig.position.y, xrRig.position.z);

        tombstones = GameObject.FindGameObjectsWithTag("tombstoneLarge");
        Debug.Log(tombstones.Length);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        newPosition = new Vector3(xrRig.position.x, xrRig.position.y, xrRig.position.z);

        if (Vector3.Distance(position,newPosition) > scaleFactor){

		    foreach(UnityEngine.GameObject tomb in tombstones)
            {
                tomb.SetActive(false);
                position = newPosition;
	        }
            map.SetActive(false);
        }
    }
}
