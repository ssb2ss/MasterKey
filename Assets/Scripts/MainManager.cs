using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    public Camera mainCamera;
    public Text text;

    public GameObject settingUI;

    public Text languageText, sfxText, bgmText;
    public Image korean, english;
    public Slider bgmSlider, sfxSlider;

    private bool isAlphaUp;
    private bool isEnglish;
    
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
        if (PlayerPrefs.GetInt("Language", -1) == -1)
        {
            if(Application.systemLanguage == SystemLanguage.Korean)
            {
                PlayerPrefs.SetInt("Language", 0);
                isEnglish = false;
            }
            else
            {
                PlayerPrefs.SetInt("Language", 1);
                isEnglish = true;
            }
        }
        else if (PlayerPrefs.GetInt("Language") == 0)
        {
            isEnglish = false;
        }
        else
        {
            isEnglish = true;
        }
        UpdateLanguage();

        bgmSlider.value = PlayerPrefs.GetFloat("BGMvolume", 1);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXvolume", 1);

        text.color = new Color(1, 1, 1, 0);
        settingUI.SetActive(false);
        isAlphaUp = true;
        StartCoroutine(Blinking());
    }

    public void OnClickScreen()
    {
        SceneManager.LoadScene("GameScene");
        return;
    }

    public void OnClickSetting(int mode)
    {
        if (mode == 0)
        {
            settingUI.SetActive(true);
        }
        else
        {
            settingUI.SetActive(false);
        }
    }

    public void SetLanguage(int mode)
    {
        if(mode == 0)
        {
            PlayerPrefs.SetInt("Language", 0);
            isEnglish = false;
            UpdateLanguage();
        }
        else
        {
            PlayerPrefs.SetInt("Language", 1);
            isEnglish = true;
            UpdateLanguage();
        }
    }

    private void UpdateLanguage()
    {
        if (isEnglish)
        {
            text.text = "Tab to Start";
            languageText.text = "Language";
            sfxText.text = "SFX Volume";
            bgmText.text = "BGM Volume";
            korean.color = new Color(0.5f, 0.5f, 0.5f, 1);
            english.color = new Color(1, 1, 1, 1);
        }
        else
        {
            text.text = "화면을 누르세요";
            languageText.text = "언어 설정";
            sfxText.text = "효과음 음량";
            bgmText.text = "배경음 음량";
            korean.color = new Color(1, 1, 1, 1);
            english.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
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
