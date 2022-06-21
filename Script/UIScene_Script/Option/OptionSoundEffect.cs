using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public static class SettingEff
{
    public static float publicEff = 0.3f;

}

public class OptionSoundEffect : MonoBehaviour
{

    public AudioMixer Mixer;

    private Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = gameObject.GetComponent<Slider>();
        volumeSlider.value = SettingEff.publicEff;

        volumeSlider.onValueChanged.AddListener(delegate {
            ChangeVolume();
    });
        
    }

    public void ChangeVolume()
    {
        SettingEff.publicEff = volumeSlider.value;
        Mixer.SetFloat("EffVol", Mathf.Log10(volumeSlider.value)*20);
    }

}


