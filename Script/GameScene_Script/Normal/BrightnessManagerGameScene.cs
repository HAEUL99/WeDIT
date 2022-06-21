using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessManagerGameScene : MonoBehaviour
{
	private Light DirectLight;
	private bool check = true;

	private void Start()
	{
		DirectLight = GameObject.Find("Directional Light").GetComponent<Light>();
		if (check == true)
		{
			DirectLight.intensity = 0.85f;
			SettingBrightness.publicLight = DirectLight.intensity;
		}
        else
        {
			SetBrightness();
		}
	}

	private void SetBrightness()
	{
		DirectLight.intensity = SettingBrightness.publicLight;
	}
}
