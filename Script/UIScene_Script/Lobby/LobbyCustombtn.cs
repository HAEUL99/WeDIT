using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyCustombtn : MonoBehaviour
{
    private GameObject Custom_btn;

    private void Start()
    {
        Custom_btn = GameObject.Find("Custom_btn");
        Button btn = Custom_btn.GetComponent<Button>();
        btn.onClick.AddListener(MovetoNextScene);

    }

    private void MovetoNextScene()
    {
        SceneManager.LoadScene("Scenes/GUIScene/Custom_model");
    }
}