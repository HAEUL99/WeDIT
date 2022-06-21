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

public static class SettingNumberofMember
{
    public static float publicMember = 6;

}


public class memberSlider : Photon.Bolt.GlobalEventListener
{

    public Slider mSlider;

    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();
    }

    void Start()
    {
        mSlider = gameObject.GetComponent<Slider>();
        /*mSlider.onValueChanged.AddListener(delegate {
            Save();
        });

        if (BoltNetwork.IsRunning)
        {
            var session = BoltMatchmaking.CurrentSession as PhotonSession;
            TeamToken updateToken = (TeamToken)session.GetProtocolToken();
            // updateToken.TotalMemberCapacity = (int)mSlider.value;
            updateToken.TotalMemberCapacity = (int)SettingNumberofMember.publicMember;
            BoltMatchmaking.UpdateSession(updateToken);

        }*/
    }


    private void Save()
    {
        SettingNumberofMember.publicMember = mSlider.value;
    }


    void Update()
    {

        mSlider.onValueChanged.AddListener(delegate {
            Save();
        });

        //SettingNumberofMember.publicMember = mSlider.value;

        if (BoltNetwork.IsRunning)
        {
            var session = BoltMatchmaking.CurrentSession as PhotonSession;
            TeamToken updateToken = (TeamToken)session.GetProtocolToken();
            // updateToken.TotalMemberCapacity = (int)mSlider.value;
            updateToken.TotalMemberCapacity = (int)SettingNumberofMember.publicMember;
            BoltMatchmaking.UpdateSession(updateToken);
        }

    }

}

