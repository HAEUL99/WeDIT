using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LobbyHowToPlay : MonoBehaviour
{

    private GameObject How_btn;
    private GameObject How_panel;
    private GameObject Back_btn;
    private Button how;
    private Button back;


    void Start()
    {
        How_btn = GameObject.Find("How_btn");
	How_panel = GameObject.Find("How_panel");
	Back_btn = GameObject.Find("Back_btn");
	How_panel.SetActive(false);

	how = How_btn.GetComponent<Button>();
        back = Back_btn.GetComponent<Button>();

	how.onClick.AddListener(ShowHow);


    }

    void Update()
    {
        
    }

    private void ShowHow()
    {
        How_panel.SetActive(true);
	back.onClick.AddListener(UnShowHow);
    }

    private void UnShowHow()
    {
        How_panel.SetActive(false);
    }
}
