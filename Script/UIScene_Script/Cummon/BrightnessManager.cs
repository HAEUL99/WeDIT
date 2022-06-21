using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class BrightnessManager : MonoBehaviour
{
	private Light DirectLight;
	


	private void Start()
	{
		DirectLight = GameObject.Find("Directional Light").GetComponent<Light>();
		SetBrightness();

	}

	private void SetBrightness()
	{
		DirectLight.intensity = SettingBrightness.publicLight;
	}

}
