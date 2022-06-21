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
using TMPro;

using UnityEngine.SceneManagement;

public class LobbyPlaybtn : MonoBehaviour
{
    private GameObject Play_btn;

    private void Start()
    {
        Play_btn = GameObject.Find("Play_btn");
        Button btn = Play_btn.GetComponent<Button>();
        btn.onClick.AddListener(MovetoNextScene);

    }

    private void MovetoNextScene()
    {
        //SceneManager.LoadScene("Scenes/gameStageTest");
        
        SceneManager.LoadScene("Scenes/GUIScene/Play");

        
        if (BoltNetwork.IsRunning && BoltNetwork.IsServer)
        {
            BoltLauncher.Shutdown();
        }

        BoltLauncher.StartClient();
        
    }



}
