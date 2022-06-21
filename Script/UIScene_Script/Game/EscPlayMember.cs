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

public class EscPlayMember : Photon.Bolt.GlobalEventListener
{
    private string temp;
    //private int nowIn;
    private Text memberID;

    private void Start()
    {
        memberID = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        CheckingMembers();    
    }

    private void CheckingMembers()
    {

        var session = BoltMatchmaking.CurrentSession;
        var photonSession = session as PhotonSession;

        TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();

        if (TToken != null)
        {

            temp = "- Member id -\n" + TToken.HostID;

            for (int i = 0; i < (TToken.MemberNowIn - 1); i++)
            {
                temp = temp + "\n" + TToken.MemberID[i];
            }

        }

        memberID.text = temp;
    }


}
