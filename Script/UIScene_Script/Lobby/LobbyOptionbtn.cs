using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyOptionbtn : MonoBehaviour
{
    private GameObject Option_btn;

    private void Start()
    {
        Option_btn = GameObject.Find("Option_btn");
        Button btn = Option_btn.GetComponent<Button>();
        btn.onClick.AddListener(MovetoNextScene);

    }

    private void MovetoNextScene()
    {
        SceneManager.LoadScene("Scenes/GUIScene/Option");
    }
}