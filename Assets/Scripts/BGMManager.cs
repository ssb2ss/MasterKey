using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{

    public static BGMManager instance;

    private AudioSource bgmPlayer;
    [SerializeField]
    private float volume;

    public AudioClip bgm;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        volume = PlayerPrefs.GetFloat("BGMvolume", 1);

        bgmPlayer = GetComponent<AudioSource>();
        PlayBGM(bgm);
    }

    public void PlayBGM(AudioClip clip)
    {
        bgmPlayer.Stop();
        bgmPlayer.clip = clip;
        bgmPlayer.loop = true;
        bgmPlayer.time = 0;
        bgmPlayer.volume = volume;
        bgmPlayer.Play();
    }

    public void SetVolume(Slider slider)
    {
        volume = slider.value;
        PlayerPrefs.SetFloat("BGMvolume", volume);
        bgmPlayer.volume = volume;
    }

}
