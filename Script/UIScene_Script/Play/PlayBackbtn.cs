using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Bolt;
using Photon.Bolt.Matchmaking;
using UdpKit;
using System;
using UdpKit.Platform.Photon;
using Photon.Bolt.Utils;
using UnityEngine.SceneManagement;

public class PlayBackbtn : MonoBehaviour
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
        if (BoltNetwork.IsRunning)
        {
            BoltLauncher.Shutdown();
        }
        SceneManager.LoadScene("Scenes/GUIScene/Lobby");
    }
}
