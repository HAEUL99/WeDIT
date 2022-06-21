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

public class CheckSituation : Photon.Bolt.GlobalEventListener
{

    private GameObject panel;
    private GameObject pw_inputfield;
    private GameObject pw_btn;
    private GameObject msg_field;
    private TeamToken TToken;

    //private InputField pw_value;
    private Button check_btn;
    private Text msg_text;
    //private Text pw_text;
    public bool IsPWRight;

    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();
    }

    void Start()
    {
        panel = GameObject.Find("Panel_pw");
        pw_inputfield = GameObject.Find("PW_input");
        pw_btn = GameObject.Find("Password_btn");
        msg_field = GameObject.Find("Message_text");

        check_btn = pw_btn.GetComponent<Button>();
        msg_text = msg_field.GetComponent<Text>();

        IsPWRight = false;

        var session = BoltMatchmaking.CurrentSession;
        var photonSession = session as PhotonSession;
        TToken = (TeamToken)photonSession.GetProtocolToken();

        if (BoltNetwork.IsRunning && BoltNetwork.IsServer)
        {
            panel.SetActive(false);
        }

        else if (BoltNetwork.IsRunning && BoltNetwork.IsClient)
        {
            if (TToken.InvitePossibility == 1) // public
            {
                panel.SetActive(false);
            }
            else // private
            {
                msg_text.text = "Please enter password";
                check_btn.onClick.AddListener(CheckPassword);
            }

        }

    }

    void Update()
    {

        check_btn.onClick.AddListener(CheckPassword);
    }


    public void CheckPassword()
    {
        string str;
        msg_text.text = "Password checking...";

        str = pw_inputfield.GetComponent<InputField>().text;
        msg_text.text = "Password checking..." + str;

        if (TToken.Password == str)
        {
            panel.SetActive(false);
            IsPWRight = true;
        }
        else
        {
            msg_text.text = "Password [" + str + "] is wrong. Enter again.";
        }
    }


}
