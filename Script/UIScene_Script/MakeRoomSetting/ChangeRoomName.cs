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

public class ChangeRoomName : Photon.Bolt.GlobalEventListener
{

    private GameObject rnInputField;
    //private InputField rnvalue;
    
    
    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();
    }

    void Start()
    {
        
        rnInputField = GameObject.Find("RoomName_Input");
        //rnvalue = rnInputField.GetComponent<InputField>();

    }



    void Update()
    {
        string str_name;

        str_name = rnInputField.GetComponent<InputField>().text;

        if (str_name.Length != 0)
        {
            if (BoltNetwork.IsRunning)
            {

                var session = BoltMatchmaking.CurrentSession;
                var photonSession = session as PhotonSession;
                TeamToken updateToken = (TeamToken)session.GetProtocolToken();

                updateToken.RoomName = str_name;
                BoltMatchmaking.UpdateSession(updateToken);

            }
        }
    }
}