using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    public Camera mainCamera;
    public Text text;

    private bool isAlphaUp;
    
    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        Rect rect = mainCamera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)16 / 9);
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        mainCamera.rect = rect;
    }

    private void Start()
    {
        text.color = new Color(1, 1, 1, 0);
        isAlphaUp = true;
        StartCoroutine(Blinking());
    }

    public void OnClickScreen()
    {
        SceneManager.LoadScene("GameScene");
        return;
    }

    private IEnumerator Blinking()
    {
        while (true)
        {
            if (isAlphaUp)
            {
                text.color = new Color(1, 1, 1, text.color.a + 0.01f);
                if (text.color.a >= 1)
                {
                    text.color = new Color(1, 1, 1, 1);
                    isAlphaUp = false;
                }
            }
            else
            {
                text.color = new Color(1, 1, 1, text.color.a - 0.01f);
                if (text.color.a <= 0)
                {
                    text.color = new Color(1, 1, 1, 0);
                    isAlphaUp = true;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

}
