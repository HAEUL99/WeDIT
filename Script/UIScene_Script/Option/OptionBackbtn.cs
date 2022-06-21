using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionBackbtn : MonoBehaviour
{
    private GameObject Back_btn;

    private void Start()
    {
        Back_btn = GameObject.Find("Back_btn");
        Button btn = Back_btn.GetComponent<Button>();
        btn.onClick.AddListener(MovetoPreviousScene);

    }

    private void MovetoPreviousScene()
    {
        SceneManager.LoadScene("Scenes/GUIScene/Lobby");
    }
}
