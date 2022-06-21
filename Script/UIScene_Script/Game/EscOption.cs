using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscOption : MonoBehaviour
{
    private GameObject Back_btn;
    private GameObject Option_panel;

    private void Start()
    {
        Option_panel = GameObject.Find("Option_panel");
        Option_panel.SetActive(false);
        Back_btn = GameObject.Find("Option_btn");
        Button btn = Back_btn.GetComponent<Button>();
        btn.onClick.AddListener(OptionPanel);
        


    }

    private void OptionPanel()
    {
        Option_panel.SetActive(true);
    }
}
