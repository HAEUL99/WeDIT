using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioInitializing : MonoBehaviour
{
    public AudioMixer Mixer;

    // Start is called before the first frame update
    void Start()
    {
        float b = SettingBGM.publicBGM;
        float e = SettingEff.publicEff;
        Mixer.SetFloat("BGMVol", Mathf.Log10(b) * 20);
        Mixer.SetFloat("EffVol", Mathf.Log10(e) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
