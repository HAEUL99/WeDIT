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

public class EscExit : Photon.Bolt.GlobalEventListener
{
    private GameObject realExitUI;
    private Button ExitBtn;

    private Button RealYes;
    private Button RealNo;
    private GameObject EscUI;
    private bool ischecked;

    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();

    }
    // Start is called before the first frame update
    void Start()
    {
        ischecked = false;
        realExitUI = GameObject.Find("RealExitQ_Img");
        realExitUI.SetActive(false);
        ExitBtn = GameObject.Find("Exit_btn").GetComponent<Button>();
        ExitBtn.onClick.AddListener(ShowRealExitUiI);

        RealYes = realExitUI.transform.GetChild(0).GetComponent<Button>();
        RealNo = realExitUI.transform.GetChild(1).GetComponent<Button>();
        EscUI = GameObject.Find("EscUI");

        RealYes.onClick.AddListener(ClickedYes);
        RealNo.onClick.AddListener(ClickedNo);

    }

    public void ShowRealExitUiI()
    {
        realExitUI.SetActive(true);


    }

    public void ClickedYes()
    {
        if (BoltNetwork.IsServer)
        {

            var session = BoltMatchmaking.CurrentSession;
            var photonSession = session as PhotonSession;
            TeamToken updateToken = (TeamToken)session.GetProtocolToken();

            updateToken.IsShutDown = true;
            BoltMatchmaking.UpdateSession(updateToken);

            BoltNetwork.LoadScene("Lobby");

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

                //BoltLauncher.StartClient();
                ischecked = true;
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

    public void ClickedNo()
    {
        realExitUI.SetActive(false);

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

            SceneManager.LoadScene("Scenes/GUIScene/Lobby");
            //BoltNetwork.LoadSceneSync();
            //BoltLauncher.StartClient();

        }
    }

    private void Delay()
    {
        SceneManager.LoadScene("Scenes/GUIScene/Lobby");
        BoltLauncher.Shutdown();
    }
}