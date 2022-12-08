using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InstructionMenuScript : MonoBehaviour
{
    public GameObject Page1Button;
    public GameObject Page2Button;
    public GameObject Page2Button_1;
    public GameObject Page3Button;
    public GameObject ExitButton;
    public GameObject Page1Instructions;
    public GameObject Page2Instuctions;
    public GameObject Page3Instructions;
    public GameObject instructionMenuCanvas;
    public GameObject visor;
    private bool activate = false;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (instructionMenuCanvas.activeInHierarchy == true)
        {
            visor.SetActive(true);
        }
        if (activate)
        {
            if (timer < 1)
            {
                timer += Time.deltaTime * 3;
                instructionMenuCanvas.GetComponent<CanvasGroup>().alpha = timer;
            }
            else
            {
                timer = 0;
                activate = false;
            }
        }
    }
    public void Page1()
    {
        Page1Button.SetActive(false);
        Page2Button.SetActive(true);
        Page2Button_1.SetActive(false);
        Page3Button.SetActive(false);
        ExitButton.SetActive(false);
        Page1Instructions.SetActive(true);
        Page2Instuctions.SetActive(false);
        Page3Instructions.SetActive(false);
    }
    public void Page2()
    {
        Page1Button.SetActive(true);
        Page2Button.SetActive(false);
        Page2Button_1.SetActive(false);
        Page3Button.SetActive(true);
        ExitButton.SetActive(false);
        Page1Instructions.SetActive(false);
        Page2Instuctions.SetActive(true);
        Page3Instructions.SetActive(false);
    }
    public void Page3()
    {
        Page1Button.SetActive(false);
        Page2Button.SetActive(false);
        Page2Button_1.SetActive(true);
        Page3Button.SetActive(false);
        ExitButton.SetActive(true);
        Page1Instructions.SetActive(false);
        Page2Instuctions.SetActive(false);
        Page3Instructions.SetActive(true);
    }
    public void OpenMap()
    {

        if (!instructionMenuCanvas.activeSelf)
        {
            instructionMenuCanvas.SetActive(true);


            //var direction = new Vector3(camera.forward.x, camera.forward.y, camera.forward.z);
            //map.transform.LookAt(direction);

            //map.transform.position = new Vector3(xrRig.transform.position.x, xrRig.transform.position.y + .5f, xrRig.transform.position.z + 1);

            // map.transform.localEulerAngles = new Vector3(0, camera.transform.localEulerAngles.y, 0);
            // map.transform.position = new Vector3(camera.forward.x, camera.forward.y, camera.forward.z);
            instructionMenuCanvas.GetComponent<CanvasGroup>().alpha = 0;
            activate = true;
        }
        else { }
    }
    //public void NextPage()
    //{
    //    Page1Button.SetActive(true);
    //    Page2Button.SetActive(false);
    //    Page3Button.SetActive(true);
    //    Page1Instructions.SetActive(false);
    //    Page2Instuctions.SetActive(true);
    //}
    //public void BackPage()
    //{
    //    Page1Button.SetActive(false);
    //    Page2Instuctions.SetActive(false);
    //    Page1Instructions.SetActive(true);
    //}
    //public void FinalPage()
    //{

    //}
}
