using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemberValue : MonoBehaviour
{

    private GameObject value_text;
    private GameObject nmSlider;
    private Slider sli;
    TextMeshProUGUI t;

    void Start()
    {
        nmSlider = GameObject.Find("NofM_slider");
        sli = nmSlider.GetComponent<Slider>();

        value_text = GameObject.Find("NMValue");
        t = value_text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = sli.value.ToString();
    }

}
