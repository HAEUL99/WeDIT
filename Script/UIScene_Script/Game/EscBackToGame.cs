using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscBackToGame : MonoBehaviour
{
    private GameObject escUI;
    private GameObject backBtn;
    private Button btn;

    private void Start()
    {
        escUI = GameObject.Find("EscUI");
        backBtn = GameObject.Find("BacktoGame_btn");
        btn = backBtn.GetComponent<Button>();
        btn.onClick.AddListener(PressEsc);
    }
    

    private void PressEsc()
    {
        escUI.SetActive(false);
    }
}
