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

public static class SettingInvite
{
    public static int i = 0;

}


public class InviteSetting : Photon.Bolt.GlobalEventListener
{

    private GameObject yes_btn;
    private GameObject no_btn;
    private Button btn0; // yes
    private Button btn1; // no

    private GameObject pw_text;
    private GameObject pw_input;
    

    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();
    }


    void Start()
    {
        yes_btn = GameObject.Find("InviteYes_btn");
        no_btn = GameObject.Find("InviteNo_btn");
        btn0 = yes_btn.GetComponent<Button>();
        btn1 = no_btn.GetComponent<Button>();

        pw_text = GameObject.Find("Password_text");
        pw_input = GameObject.Find("Password_input");

        if(SettingInvite.i == 0)
        {
            setColorYes();
        }
        else
        {
            setColorNo();
        }

    }


    private void ChangeToYes()
    {

        setColorYes();
        SettingInvite.i = 0;

    }

    private void ChangeToNo()
    {

        setColorNo();
        SettingInvite.i = 1;

    }

    private void setColorYes()
    {
        var color_w = GetComponent<Button>().colors;
        color_w.normalColor = Color.white;
        btn0.colors = color_w;
        var color_g = GetComponent<Button>().colors;
        color_g.normalColor = Color.gray;
        btn1.colors = color_g;
    }

    private void setColorNo()
    {
        var color_g = GetComponent<Button>().colors;
        color_g.normalColor = Color.gray;
        btn0.colors = color_g;
        var color_w = GetComponent<Button>().colors;
        color_w.normalColor = Color.white;
        btn1.colors = color_w;
    }


    void Update()
    {
        btn0.onClick.AddListener(ChangeToYes);
        btn1.onClick.AddListener(ChangeToNo);


        if (BoltNetwork.IsRunning)
        {
            var session = BoltMatchmaking.CurrentSession as PhotonSession;
            TeamToken updateToken = (TeamToken)session.GetProtocolToken();
            updateToken.InvitePossibility = SettingInvite.i;
            BoltMatchmaking.UpdateSession(updateToken);

        }
    }
}
