using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscOptionBack : MonoBehaviour
{
    private GameObject Back_btn;
    private GameObject Option_panel;

    private void Start()
    {
        Option_panel = GameObject.Find("Option_panel");
        Back_btn = GameObject.Find("Back_btn");
        Button btn = Back_btn.GetComponent<Button>();
        btn.onClick.AddListener(OptionPanel);
    }

    private void OptionPanel()
    {
        Option_panel.SetActive(false);
    }
}
