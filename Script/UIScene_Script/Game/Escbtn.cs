using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escbtn : MonoBehaviour
{
    
    private GameObject escUI;
    private bool CanseeUI;

    private void Start()
    {
        escUI = GameObject.Find("EscUI");
        escUI.SetActive(false);
        CanseeUI = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            PressEsc();

        }
    }

    private void PressEsc()
    {
        if (CanseeUI == false)
        {
            escUI.SetActive(true);
            CanseeUI = true;
        }
        else
        {
            escUI.SetActive(false);
            CanseeUI = false;
        }
    }
}
