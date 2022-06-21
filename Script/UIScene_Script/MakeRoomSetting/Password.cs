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

public class Password : Photon.Bolt.GlobalEventListener
{

    private GameObject pwInputField;
    private InputField pwvalue;

    private string str_pw;

    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();
    }

    void Start()
    {
        pwInputField = GameObject.Find("Password_Input");
        pwvalue = pwInputField.GetComponent<InputField>();
    }



    void Update()
    {
        str_pw = pwvalue.text;

        if (str_pw.Length != 0)
        {
            if (BoltNetwork.IsRunning)
            {

                var session = BoltMatchmaking.CurrentSession;
                var photonSession = session as PhotonSession;
                TeamToken updateToken = (TeamToken)session.GetProtocolToken();

                updateToken.Password = str_pw;
                BoltMatchmaking.UpdateSession(updateToken);

            }
        }
    }
}