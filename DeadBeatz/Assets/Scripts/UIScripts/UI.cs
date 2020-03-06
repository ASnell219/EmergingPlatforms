using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;
    public AudioMixer mixer;

    public AudioSetting[] audioSettings;
    private enum AudioGroups { Master, Music, SFX };

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < audioSettings.Length; i++)
        {
            audioSettings[i].Initialize();
        }
    }

    public void SetVolume(float value)
    {
        audioSettings[(int)AudioGroups.Master].SetExposedParam(value);
        PlayerPrefs.SetFloat("SliderVolumeLevel", value);
    }

}

[System.Serializable]
public class AudioSetting
{
    public Slider slider;
    public string exposedParam;

    public void Initialize()
    {
        slider.value = PlayerPrefs.GetFloat(exposedParam);
    }

    public void SetExposedParam(float value) // 1
    {
        UI.instance.mixer.SetFloat(exposedParam, value); // 3
        PlayerPrefs.SetFloat(exposedParam, value); // 4
    }

}
