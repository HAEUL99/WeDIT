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

public class RoomInformation : Photon.Bolt.GlobalEventListener
{
    private Text tinf;

    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();
    }


    void Start()
    {

        tinf = GetComponent<Text>();
        Checking();
        
    }

    
    void Update()
    {
        Checking();
    }

    private void Checking()
    {
        string str;

        var session = BoltMatchmaking.CurrentSession;
        var photonSession = session as PhotonSession;

        TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();


        if (TToken != null)
        {
            tinf.text = "- Room Information -\n";
            if (TToken.InvitePossibility == 0)
            {
                str = "private";
            }
            else
            {
                str = "public";
            }


            tinf.text = tinf.text + "Member : " + TToken.MemberNowIn + " / "
                + TToken.TotalMemberCapacity + "\n" + str + "\n";
            if (TToken.InvitePossibility == 0)
            {
                if (TToken.Password == null)
                {
                    tinf.text = tinf.text + "Please set the pw.";
                }
                else
                {
                    tinf.text = tinf.text + "Password : " + TToken.Password;
                }

            }

        }
        
        else
        {
            tinf.text = "No Information";
        }
        
    }
}
