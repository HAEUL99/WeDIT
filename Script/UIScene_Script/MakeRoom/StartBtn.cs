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

public class StartBtn : Photon.Bolt.GlobalEventListener
{
    private GameObject stabtn;
    private GameObject setbtn;
    public Button start_btn;

    void Start()
    {
        stabtn = GameObject.Find("Start_btn");
        setbtn = GameObject.Find("Setting_btn");
        if (BoltNetwork.IsClient)
        {
            stabtn.SetActive(false);
            setbtn.SetActive(false);
        }

        start_btn.onClick.AddListener(StartGame);

        

    }

    private void Update()
    {
        var session = BoltMatchmaking.CurrentSession;
        var photonSession = session as PhotonSession;
        TeamToken updateToken = (TeamToken)session.GetProtocolToken();

        //Debug.Log($"updateToken.IsGameStart: {updateToken.IsStart}");

        if (updateToken.IsStart && BoltNetwork.IsClient)
        {

            BoltNetwork.LoadSceneSync();

        }

    }





    public void StartGame()
    {
        //Debug.Log("start 누름");
        //Debug.Log($"BoltMatchmaking.CurrentSession: {BoltMatchmaking.CurrentSession.HostName}");
        if (BoltNetwork.IsServer)
        {
            
            //Debug.Log("서버가 스타트누름");
            //var session = BoltMatchmaking.CurrentSession;
            //var photonSession = session as PhotonSession;
            //TeamToken updateToken = (TeamToken)session.GetProtocolToken();
            var session = BoltMatchmaking.CurrentSession;
            var photonSession = session as PhotonSession;
            TeamToken updateToken = (TeamToken)session.GetProtocolToken();
            updateToken.IsStart = true;
            BoltMatchmaking.UpdateSession(updateToken);

            //BoltNetwork.LoadScene("GameStageHaeul");
            BoltNetwork.LoadScene("gameStageTest");
            //IsServerStart.ServerStartGame = true;


        }



    }
}
