using UnityEngine;
using UnityEngine.UI;


public class PanelExit_btn : MonoBehaviour
{
    private GameObject Back_btn;
    private GameObject pwPanel;

    private void Start()
    {
        pwPanel = GameObject.Find("Panel_pw");
        Back_btn = GameObject.Find("pwExit_btn");
        Button btn = Back_btn.GetComponent<Button>();
        btn.onClick.AddListener(OutThisScene);

    }

    private void OutThisScene()
    {
        pwPanel.SetActive(false);
    }
}
