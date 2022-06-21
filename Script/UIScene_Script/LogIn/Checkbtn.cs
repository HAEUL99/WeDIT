using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Checkbtn : MonoBehaviour
{
    private GameObject check_btn;
    private GameObject playerInputField;
    private InputField playerIdvalue;

    private void Start()
    {
        check_btn = GameObject.Find("check_btn");
        playerInputField = GameObject.Find("PlayerId");

        Button btn = check_btn.GetComponent<Button>();
        playerIdvalue = playerInputField.GetComponent<InputField>();
        btn.onClick.AddListener(MovetoNextScene);

    }

    private void MovetoNextScene()
    {
        if(playerIdvalue.text.Length != 0)
        {
            PlayerCharacter.playerId = playerIdvalue.text;
            SceneManager.LoadScene("Scenes/GUIScene/Lobby");
        }
    }
}
