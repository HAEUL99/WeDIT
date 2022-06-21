using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class makeroomSetBtn : MonoBehaviour
{
    private GameObject Setting_btn;

    private void Start()
    {
        Setting_btn = GameObject.Find("Setting_btn");
        Button btn = Setting_btn.GetComponent<Button>();
        btn.onClick.AddListener(MovetoNextScene);

    }

    private void MovetoNextScene()
    {
        SceneManager.LoadScene("Scenes/GUIScene/MakeRoomSetting");
    }
}