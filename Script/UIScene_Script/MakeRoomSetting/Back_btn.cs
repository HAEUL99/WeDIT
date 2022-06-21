using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back_btn : MonoBehaviour
{
    private GameObject check_btn;

    private void Start()
    {
        check_btn = GameObject.Find("Back_btn");
        Button btn = check_btn.GetComponent<Button>();
        btn.onClick.AddListener(MovetoNextScene);

    }

    private void MovetoNextScene()
    {
        SceneManager.LoadScene("Scenes/GUIScene/MakeRoom");



    }
}

