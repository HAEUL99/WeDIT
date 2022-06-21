using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SettingBrightness
{
    public static float publicLight = 1.1f;

}


public class OptionBrightness : MonoBehaviour
{

    public Light myLight;
    private Slider briSlider;


    void Start()
    {
        myLight = GameObject.Find("Directional Light").GetComponent<Light>();
        briSlider = gameObject.GetComponent<Slider>();
        briSlider.value = SettingBrightness.publicLight;

        briSlider.onValueChanged.AddListener(delegate {
            ChangeBri();
    	});

    }

    public void ChangeBri()
    {
        myLight.intensity = briSlider.value;
        SettingBrightness.publicLight = myLight.intensity;
    }


}


