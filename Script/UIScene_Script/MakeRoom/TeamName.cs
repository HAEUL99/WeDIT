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



public class TeamName : Photon.Bolt.GlobalEventListener
{

    private Text tname;
    
    

    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();
    }

    void Start()
    {
        // int now;

        tname = GetComponent<Text>();

        /*if (BoltNetwork.IsClient)
        {

            var session = BoltMatchmaking.CurrentSession;
            var photonSession = session as PhotonSession;
            TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();
            var newToken = new TeamToken();

            now = TToken.MemberNowIn;

            if (TToken.MemberID[now - 1] != PlayerCharacter.playerId)
            {
                newToken.MemberNowIn = now + 1;
                newToken.MemberID[now - 1] = PlayerCharacter.playerId;

                ConnectRequest(session.LanEndPoint, newToken);
            }
        }*/
    }

    /*public void ConnectRequest(UdpEndPoint endpoint, TeamToken token)
    {
        BoltNetwork.Accept(endpoint, token);
    }*/


    void Update()
    {

        var session = BoltMatchmaking.CurrentSession;
        var photonSession = session as PhotonSession;


        TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();


        if (TToken != null)
        {
            tname.text = TToken.RoomName;
        }

        else
        {
            tname.text = "No Name";
        }


    }

    /*public override void Connected(BoltConnection connection)
    {
        int now;

        if (BoltNetwork.IsServer)
        {
            BoltLog.Warn("Connection accepted!");

            var session = BoltMatchmaking.CurrentSession;
            var photonSession = session as PhotonSession;
            TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();


            if (connection.AcceptToken is TeamToken acceptToken)
            {
                now = acceptToken.MemberNowIn;
                TToken.MemberNowIn = now;
                TToken.MemberID[now - 2] = acceptToken.MemberID[now - 2];

                BoltMatchmaking.UpdateSession(TToken);

            }
            else
            {
                BoltLog.Warn("AcceptToken is NULL");
            }
        }
        
    }*/


    
}
