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
using System.Linq;
using UnityEngine.SceneManagement;

public class makeroomExit_btn : Photon.Bolt.GlobalEventListener
{
    private GameObject Back_btn;
    private bool ischecked;

    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();

    }

    private void Start()
    {
        Back_btn = GameObject.Find("Exit_btn");
        Button btn = Back_btn.GetComponent<Button>();
        btn.onClick.AddListener(OutThisScene);
        ischecked = false;

    }

    private void OutThisScene()
    {
        if (BoltNetwork.IsServer)
        {

            var session = BoltMatchmaking.CurrentSession;
            var photonSession = session as PhotonSession;
            TeamToken updateToken = (TeamToken)session.GetProtocolToken();

            updateToken.IsShutDown = true;
            BoltMatchmaking.UpdateSession(updateToken);

            BoltNetwork.LoadScene("Play");

            Invoke("ServerShutDown", 3.0f);
            //BoltLauncher.Shutdown();
            //BoltLauncher.StartClient();

        }


        //client나가면 tokenupdate
        if (BoltNetwork.IsClient)
        {
            if (ischecked == false)
            {
                var session = BoltMatchmaking.CurrentSession;
                var photonSession = session as PhotonSession;

                TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();


                var numbersList = TToken.MemberID.ToList();
                numbersList.Remove(PlayerCharacter.playerId);
                numbersList.Add("");
                TToken.MemberID = numbersList.ToArray();
                TToken.MemberNowIn--;


                RoomInfoInGameEvent evnt = RoomInfoInGameEvent.Create();
                evnt.RoomInGameToken = TToken;

                evnt.Send();

                Invoke("Delay", 2.0f);
                ischecked = true;
                //BoltLauncher.StartClient();
            }
            
        }

    }

    public void ServerShutDown()
    {
        BoltLauncher.Shutdown();
    }


    public override void OnEvent(RoomInfoInGameEvent evnt)
    {

        BoltMatchmaking.UpdateSession(evnt.RoomInGameToken);
    }

    private void Update()
    {
        ShutDownChecking();
    }

    private void ShutDownChecking()
    {
        var session = BoltMatchmaking.CurrentSession;
        var photonSession = session as PhotonSession;
        TeamToken updateToken = (TeamToken)session.GetProtocolToken();

        //Debug.Log($"updateToken.IsGameStart: {updateToken.IsStart}");

        if (updateToken.IsShutDown == true)
        {

            SceneManager.LoadScene("Scenes/GUIScene/Play");
            //BoltNetwork.LoadSceneSync();
            //BoltLauncher.StartClient();

        }
    }

    private void Delay()
    {
        SceneManager.LoadScene("Scenes/GUIScene/Play");
        BoltLauncher.Shutdown();
    }

}
