using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{

    public static SFXManager instance;

    private AudioSource sfxPlayer;
    [SerializeField]
    private float volume;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        volume = PlayerPrefs.GetFloat("SFXvolume", 1);

        sfxPlayer = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxPlayer.clip = clip;
        sfxPlayer.time = 0;
        sfxPlayer.volume = volume;
        sfxPlayer.Play();
    }

    public void SetVolume(Slider slider)
    {
        volume = slider.value;
        PlayerPrefs.SetFloat("SFXvolume", volume);
        sfxPlayer.volume = volume;
    }

}
