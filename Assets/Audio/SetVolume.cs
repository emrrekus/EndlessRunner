using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private string parameterName;

    [SerializeField]
    private Toggle audioToggle;

    [SerializeField]
    private AudioMixer audioMixer;
    private float sliderValue;

    private bool toggleOn = false;

    private float audioDB;
    // Start is called before the first frame update
    void Start()
    {
        //audioToggle.isOn = PlayerPrefs.GetInt(parameterName) == 0 ? true : false;
        audioMixer.GetFloat(parameterName, out audioDB);
        audioMixer.SetFloat(parameterName, audioToggle.isOn ? audioDB : -80);
        audioToggle.onValueChanged.AddListener(ToggleAudio);

    }
    public void ToggleAudio(bool isOn)
    {
        if (isOn)
        {
            audioMixer.SetFloat(parameterName, audioDB);
        }
        else
        {
            audioMixer.SetFloat(parameterName, -80);
        }
        PlayerPrefs.SetInt(parameterName, isOn ? 1 : 0);
        toggleOn = isOn;

        if (toggleOn == false)
        {
            slider.value = slider.minValue;
        }
        else
        {
           slider.value = slider.maxValue;
        }
    }

    float test;
    public void SetLevel(float sliderValue)
    {
        test = sliderValue;
        audioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);

    }
}
