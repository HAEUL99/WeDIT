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


/*
public static class TotalsessionInfo
{
    public static int _sessionNum = 0;
    public static List<string> _roomList;
}
*/

public class Makebtn : Photon.Bolt.GlobalEventListener
{
    private string hostID;
    private Button make_btn;
    private Button client_btn;

    private int gameRoomnum;
    private GameObject roombtnPref;
    private GameObject roombtn;
    private GameObject loadbtn;
    private Transform roombtnParent;
    //private GameObject TeamName_View;

    /*private GameObject pw_inputfield;
    private InputField pw_value;
    private GameObject pword_btn;
    private Button pw_btn;
    private GameObject msg_tmesh;
    private TextMeshProUGUI msg_text;*/

    // pw panel
    private GameObject pwpanel;
    private GameObject pw_inputfield;
    private GameObject pw_btn;
    private GameObject msg_field;
    private GameObject teamname_pw;

    //private InputField pw_value;
    private Button check_btn;
    private Text msg_text;


    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();

    }


    private void Start()
    {
        pwpanel = GameObject.Find("Panel_pw");
        pw_inputfield = GameObject.Find("PW_input");
        pw_btn = GameObject.Find("Password_btn");
        msg_field = GameObject.Find("Message_text");
        teamname_pw = GameObject.Find("TeamName_pwpanel");
        check_btn = pw_btn.GetComponent<Button>();
        msg_text = msg_field.GetComponent<Text>();

        pwpanel.SetActive(false);

        loadbtn = GameObject.Find("Loading");
        loadbtn.SetActive(false);

        make_btn = GameObject.Find("Make_btn").GetComponent<Button>();
        make_btn.onClick.AddListener(StartServer);

        //client_btn = GameObject.Find("Client_btn").GetComponent<Button>();
        //client_btn.onClick.AddListener(StartClient);
        //TeamName_View = GameObject.Find("TeamName_View");

        roombtnParent = GameObject.Find("TeamName_View").transform.GetChild(0).GetChild(0);
        //LoadRoomButtons();

        /*pw_inputfield = GameObject.Find("Password_input");
        pw_value = pw_inputfield.GetComponent<InputField>();
        pword_btn = GameObject.Find("Password_btn");
        pw_btn = pword_btn.GetComponent<Button>();

        msg_tmesh = GameObject.Find("Message_text");
        msg_text = msg_tmesh.GetComponent<TextMeshProUGUI>();

        pw_inputfield.SetActive(false);
        pword_btn.SetActive(false);*/


    }

    private void Update()
    {



    }


    public void StartServer()
    {
        if (BoltNetwork.IsRunning && BoltNetwork.IsClient)
        {
            BoltLauncher.Shutdown();
        }
        BoltLauncher.StartServer();
        loadbtn.SetActive(true);
    }



    public override void BoltStartDone()
    {
        var TeamT = new TeamToken();
        TeamT.RoomName = PlayerCharacter.playerId;
        TeamT.HostID = PlayerCharacter.playerId;
        TeamT.InvitePossibility = 0;
        TeamT.MemberNowIn = 1;
        TeamT.TotalMemberCapacity = 6;
        //TeamT.TotalMemberCapacity = 1;

        TeamT.Password = PlayerCharacter.playerId;

        TeamT.IsStart = false;
        TeamT.IsShutDown = false;
        TeamT.IsFinish = false;



        BoltMatchmaking.CreateSession(sessionID: TeamT.RoomName, sceneToLoad: "MakeRoom", token: TeamT);
    }



    /*
    public void StartClient()
    {
        if (BoltNetwork.IsRunning && BoltNetwork.IsServer)
        {
            BoltLauncher.Shutdown();
        }

        BoltLauncher.StartClient();
        //AfterClientServer();

    }
    */

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {


        //Button[] allChildren = GameObject.Find("TeamName_View").transform.GetChild(0).GetChild(0).GetComponentsInChildren<Button>();
        GameObject[] allChildren = GameObject.FindGameObjectsWithTag("Button");



        for (int i = 0; i < allChildren.Length; i++)
        {
            Destroy(allChildren[i]);
        }

        List<TeamToken> roomList = new List<TeamToken>();


        foreach (var session in sessionList)
        {
            UdpSession udpSession = session.Value as UdpSession;
            PhotonSession photonSession = udpSession as PhotonSession;

            TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();

            roomList.Add(TToken); // token.roomname
        }


        InstantiateRoomBtn(roomList);

    }


    public void InstantiateRoomBtn(List<TeamToken> roomList)
    {
        //TotalsessionInfo._sessionNum = roomList.Count;
        for (int i = 0; i < roomList.Count; i++)
        {
            //TotalsessionInfo._roomList[i] = roomList[i];
            BoltLog.Warn($"RoomList: {roomList[i].RoomName}");

            roombtnPref = Resources.Load<GameObject>("UI_pref/RoomButton/Roombtn");

            roombtn = Instantiate(roombtnPref, roombtnParent);
            roombtn.transform.GetChild(0).gameObject.SetActive(false);

            roombtn.transform.GetChild(2).GetComponent<Text>().text = $"{roomList[i].RoomName}";
            roombtn.name = roomList[i].HostID;



            //ready, start 이미지 바꿔줌 
            if (roomList[i].IsStart == true)
            {
                roombtn.transform.GetChild(0).gameObject.SetActive(true);
                roombtn.transform.GetChild(1).gameObject.SetActive(false);
            }


            //멤버
            roombtn.transform.GetChild(3).GetComponent<Text>().text = roomList[i].MemberNowIn + " / "
                + roomList[i].TotalMemberCapacity;

            /*UnityEngine.Events.UnityAction JoinSessionaction = () =>
            {
                JoinSession(roomList[i]);
            };*/

            string roomname = roombtn.name;
            string roompw = roomList[i].Password;
            string teamname = roomList[i].RoomName;

            //아직 시작안하, 인원이 totalcapacity보다 작으면 입장가능
            if (roomList[i].IsStart == false && roomList[i].MemberNowIn < roomList[i].TotalMemberCapacity)
            {
                if (roomList[i].InvitePossibility == 0)
                {
                    teamname_pw.GetComponent<Text>().text = teamname;
                    roombtn.GetComponent<Button>().onClick.AddListener(() => JoinSessionPrivate(roomname, roompw));
                }
                else
                {
                    roombtn.GetComponent<Button>().onClick.AddListener(() => JoinSession(roomname));
                }

            }
        }

    }


    public void JoinSession(string roomname)
    {
        BoltMatchmaking.JoinSession(roomname);
    }

    public void JoinSessionPrivate(string roomname, string roompw)
    {
        pwpanel.SetActive(true);
        msg_text.text = "Please enter password";
        check_btn.onClick.AddListener(() => CheckPassword(roomname, roompw));
    }

    public void CheckPassword(string roomname, string roompw)
    {

        string str;
        msg_text.text = "Password checking...";

        str = pw_inputfield.GetComponent<InputField>().text;
        msg_text.text = "Password checking..." + str;

        if (roompw == str)
        {
            BoltMatchmaking.JoinSession(roomname);
        }
        else
        {
            msg_text.text = "Password [" + str + "] is wrong. Enter again.";
        }
    }



    /*
    public void AfterClientServer()
    {
        if (BoltNetwork.IsRunning && BoltNetwork.IsClient)
        {
            foreach (var session in BoltNetwork.SessionList)
            {
                UdpSession udpSession = session.Value as UdpSession;

                if (udpSession.Source != UdpSessionSource.Photon)
                    continue;

                PhotonSession photonSession = udpSession as PhotonSession;

                string sessionName = photonSession.HostName;


            }
        }
    }
    */


}
