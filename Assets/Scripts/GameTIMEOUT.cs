using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTIMEOUT : GameFSMState
{

    public GameObject timeout;
    public float timeoutMoveSpeed;

    public override void BeginState()
    {
        base.BeginState();

        for (int i = 0; i < 6; i++)
        {
            GameManager.instance.buttonManager.button[i].SetActive(false);
        }
        timeout.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 1200, 0);
        timeout.SetActive(true);
    }

    private void Update()
    {
        timeout.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(
            timeout.GetComponent<RectTransform>().anchoredPosition,
            new Vector3(0, 0, 0),
            timeoutMoveSpeed * Time.deltaTime);

        if(timeout.GetComponent<RectTransform>().anchoredPosition.y < 0.002f)
        {
            timeout.SetActive(false);
            GameManager.instance.ChangeGameoverScene();
            return;
        }
    }

}
