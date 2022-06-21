using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyGameOverbtn : MonoBehaviour
{
    private GameObject GameOver_btn;
    private GameObject Sure;
    private Button yes;
    private Button no;

    private void Start()
    {
	Sure = GameObject.Find("SureToExit");
	yes = GameObject.Find("YesBtn").GetComponent<Button>();
	no = GameObject.Find("NoBtn").GetComponent<Button>();
	Sure.SetActive(false);

        GameOver_btn = GameObject.Find("GameOver_btn");
        Button btn = GameOver_btn.GetComponent<Button>();
        btn.onClick.AddListener(DoubleCheck);
    }


    private void DoubleCheck()
    {
	Sure.SetActive(true);
	no.onClick.AddListener(Unshow);
	yes.onClick.AddListener(GameQuit);

    }

    private void Unshow()
    {
	Sure.SetActive(false);
    }

    private void GameQuit()
    {
        Application.Quit();
    }
}

