using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchScreen : MonoBehaviour
{
    private GameObject TouchScreen_btn;

    private void Start()
    {
        TouchScreen_btn = GameObject.Find("TouchScreen_btn");
        Button btn = TouchScreen_btn.GetComponent<Button>();
        btn.onClick.AddListener(MovetoNextScene);

    }

    private void MovetoNextScene()
    {
        SceneManager.LoadScene("Scenes/GUIScene/LogIn");
    }
}
