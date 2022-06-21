using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public static class SettingBGM
{
    public static float publicBGM = 0.1f;

}


public class OptionSound : MonoBehaviour
{

    public AudioMixer Mixer;

    private Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = gameObject.GetComponent<Slider>();
        volumeSlider.value = SettingBGM.publicBGM;

        volumeSlider.onValueChanged.AddListener(delegate {
            ChangeVolume();
    });

    }

    public void ChangeVolume()
    {
        SettingBGM.publicBGM = volumeSlider.value;
        Mixer.SetFloat("BGMVol", Mathf.Log10(volumeSlider.value)*20);
    }

}

