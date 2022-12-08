using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOff : MonoBehaviour
{
    public GameObject thing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void offSwitch()
    {
        thing.SetActive(false);
    }
}
