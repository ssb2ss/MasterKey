using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour
{

    public Text text, tabtorestart;

    private bool isAlphaUp;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("currentScore", 0);
        text.text = "당신은 " + score + "개의 자물쇠를 열었습니다!";
        isAlphaUp = true;
        tabtorestart.color = new Color(1, 1, 1, 0);
        StartCoroutine(Blinking());
    }

    public void OnScreenClick()
    {
        SceneManager.LoadScene("MainScene");
        return;
    }

    private IEnumerator Blinking()
    {
        while (true)
        {
            if (isAlphaUp)
            {
                tabtorestart.color = new Color(1, 1, 1, tabtorestart.color.a + 0.01f);
                if(tabtorestart.color.a >= 1)
                {
                    tabtorestart.color = new Color(1, 1, 1, 1);
                    isAlphaUp = false;
                }
            }
            else
            {
                tabtorestart.color = new Color(1, 1, 1, tabtorestart.color.a - 0.01f);
                if(tabtorestart.color.a <= 0)
                {
                    tabtorestart.color = new Color(1, 1, 1, 0);
                    isAlphaUp = true;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

}
