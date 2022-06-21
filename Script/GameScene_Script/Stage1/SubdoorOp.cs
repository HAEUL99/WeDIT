using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Bolt;
using Photon.Bolt.Matchmaking;
using Photon.Bolt.Utils;
using UdpKit.Platform.Photon;
using UnityEngine;

//방에 있는 모든 플레이어가 차에 타면 문이 열림 
public class SubdoorOp : Photon.Bolt.GlobalEventListener
{
    public List<string> numberList;
    public int numberNum;
    public BoxCollider backSpace;
    public int totalCheck = 0;
    public Animator Start_doorSubAnim;
    
    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<TeamToken>();

    }

    public void CheckMemberlist()
    {
        var session = BoltMatchmaking.CurrentSession;
        var photonSession = session as PhotonSession;

        TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();


        numberList = TToken.MemberID.ToList();
        numberNum = TToken.MemberNowIn;
        //Debug.Log($"numberNum: {numberNum}");
    }

    private void Start()
    {
        CheckMemberlist();
        backSpace = GameObject.Find("backSpace").GetComponent<BoxCollider>();
        
    }

    private void Update()
    {
        CheckAllRide();

    }

    public void CheckAllRide()
    {
        //캐릭터 mesh collider랑 character controller 각각 한번씩 들어와서 *2 해줌
        if (totalCheck == numberNum * 2)
        {
            //Debug.Log("모두 들어옴");
            bool Ischecked = true;
            Start_doorSubAnim.SetBool("IsStage1SubDoor", Ischecked);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // event
        if (other.tag == "Player")
        {
            totalCheck++;
            //Debug.Log($"totalCheckStartPoint++: {totalCheck}");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // event
        if (other.tag == "Player")
        {
            totalCheck--;
            //Debug.Log($"totalCheckStartPoint--: {totalCheck}");
        }
    }






}
