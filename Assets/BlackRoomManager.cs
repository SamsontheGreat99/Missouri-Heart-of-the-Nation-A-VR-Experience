using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRoomManager : MonoBehaviour
{
    public CanvasGroup csGrp;
    public GameObject blackRoom;
    public float time = 1f;
    public void ExitBlackRoom(GameObject gameObject)
    {
        StartCoroutine("Exit", gameObject);
    }

    IEnumerator Exit(GameObject gameObject)
    {
        csGrp = blackRoom.GetComponent<CanvasGroup>();
        while(csGrp.alpha > 0)
        {
            csGrp.alpha -= Time.deltaTime / time;
            yield return null;
        }
        if(csGrp.alpha <= 0)
        {
            blackRoom.SetActive(false);
        }
    }
}
