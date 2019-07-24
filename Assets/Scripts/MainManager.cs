using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    public Text text;

    private bool isAlphaUp;
    
    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(Screen.width, Screen.width * 9 / 16, true);
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
