using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CusmainModelbtn : MonoBehaviour
{
    private GameObject Model_btn;

    private void Start()
    {
        Model_btn = GameObject.Find("Model_btn");
        Button btn = Model_btn.GetComponent<Button>();
        btn.onClick.AddListener(MovetoNextScene);

    }

    private void MovetoNextScene()
    {
        SceneManager.LoadScene("Scenes/GUIScene/Custom_model");
    }
}
