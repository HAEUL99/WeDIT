using UnityEngine;
using System.Collections;
using Photon.Bolt;
using Photon.Bolt.Matchmaking;
using UdpKit;
using System;

public class TestScene : Photon.Bolt.GlobalEventListener
{
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, Screen.width - 20, Screen.height - 20));

        if (GUILayout.Button("Start Server", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true)))
        {
            // START SERVER
            BoltLauncher.StartServer();
        }

        if (GUILayout.Button("Start Client", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true)))
        {
            // START CLIENT
            BoltLauncher.StartClient();
           // BoltMatchmaking.JoinSession("Haeul");
        }

        GUILayout.EndArea();
    }

    public override void BoltStartDone()
    {
        string matchname = "Haeul";
        BoltMatchmaking.CreateSession(sessionID: matchname, sceneToLoad: "gameStage");

        //else BoltNetwork.Connect(UdpKit.UdpEndPoint.Parse("127.0.0.1:27000"));

    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        foreach (var session in sessionList)
        {
            UdpSession photonSesion = session.Value as UdpSession;

            if (photonSesion.Source == UdpSessionSource.Photon)
            {
                BoltMatchmaking.JoinSession(photonSesion);
            }
        }
    }
}