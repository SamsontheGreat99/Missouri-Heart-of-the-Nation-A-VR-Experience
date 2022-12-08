using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject infoButton;
    public GameObject InstructionMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InfoMenu()
    {
        if (!InstructionMenu.activeInHierarchy)
        {
            InstructionMenu.SetActive(true);
        }
    }
}
