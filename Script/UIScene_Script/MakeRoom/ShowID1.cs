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
using System.Linq;
using UnityEngine.SceneManagement;

public class ShowID1 : Photon.Bolt.GlobalEventListener
{

    private Text memberID;
    public string temp;
    public int nowIn;
    private GameObject Back_btn;
    //private CheckSituation checkSituation;

    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();
    }

    public override void SceneLoadLocalDone(string scene, IProtocolToken token)
    {
        if (!BoltNetwork.IsServer)
        {
            var session = BoltMatchmaking.CurrentSession;
            var photonSession = session as PhotonSession;

            TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();
            
            TToken.MemberID[TToken.MemberNowIn - 1] = PlayerCharacter.playerId;
            TToken.MemberNowIn++;




            RoomInfoEvent evnt = RoomInfoEvent.Create();
            evnt.RoomToken = TToken;

            evnt.Send();
        }
            
    }

    public override void OnEvent(RoomInfoEvent evnt)
    {

        BoltMatchmaking.UpdateSession(evnt.RoomToken);
    }


    void Start()
    {
        Back_btn = GameObject.Find("Exit_btn");
        Button btn = Back_btn.GetComponent<Button>();
        btn.onClick.AddListener(OutThisScene);
        memberID = GetComponent<Text>();
        Checking();

    }


    void Update()
    {


        Checking();
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

            BoltNetwork.LoadSceneSync();
            BoltLauncher.StartClient();

        }
    }


    private void Checking()
    {

        var session = BoltMatchmaking.CurrentSession;
        var photonSession = session as PhotonSession;

        TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();



        if (TToken != null)
        {
            nowIn = TToken.MemberNowIn;
            temp = "- Member id -\n" + TToken.HostID;

            for (int i = 0; i < (nowIn - 1); i++)
            {
                temp = temp + "\n" + TToken.MemberID[i];
            }

        }

        memberID.text = temp;
    }

    private void OutThisScene()
    {

        //host나가면 server 닫힘 
        if (BoltNetwork.IsServer)
        {

            var session = BoltMatchmaking.CurrentSession;
            var photonSession = session as PhotonSession;
            TeamToken updateToken = (TeamToken)session.GetProtocolToken();

            updateToken.IsShutDown = true;
            BoltMatchmaking.UpdateSession(updateToken);

            BoltNetwork.LoadScene("Play");

            BoltLauncher.Shutdown();
            BoltLauncher.StartClient();

        }


        //client나가면 tokenupdate
        if (BoltNetwork.IsClient)
        {
            var session = BoltMatchmaking.CurrentSession;
            var photonSession = session as PhotonSession;

            TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();
        

            var numbersList = TToken.MemberID.ToList();
            numbersList.Remove(PlayerCharacter.playerId);
            numbersList.Add("");
            TToken.MemberID = numbersList.ToArray();
            TToken.MemberNowIn--;


            RoomInfoEvent evnt = RoomInfoEvent.Create();
            evnt.RoomToken = TToken;

            evnt.Send();

            Invoke("Delay", 2.0f);
            //SceneManager.LoadScene("Scenes/GUIScene/Play");
            //BoltLauncher.Shutdown();
            //BoltLauncher.StartClient();
        }

        //SceneManager.LoadScene("Scenes/GUIScene/Play");
        //BoltLauncher.StartClient();

    }

    void Delay()
    {
        SceneManager.LoadScene("Scenes/GUIScene/Play");
        BoltLauncher.Shutdown();
        BoltLauncher.StartClient();
    }
}
