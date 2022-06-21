using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;
using Photon.Bolt.Matchmaking;
using UdpKit.Platform.Photon;
using Photon.Bolt.Utils;
using System.Linq;

public class AllInMBuillding : Photon.Bolt.GlobalEventListener
{
    public GameObject SpotLights;
    public GameObject Frontdoors;
    //public GameObject car;
    private Animator lightanim;
    private Animator closedanim;
    public List<string> numberList;
    public int numberNum;

    public int totalCheck = 0;
    private bool Ischeck = false;

    // Start is called before the first frame update
    void Start()
    {
        lightanim = SpotLights.GetComponent<Animator>();
        closedanim = Frontdoors.GetComponent<Animator>();
        CheckMemberlist();
        //SpotLights.SetActive(false);
    }


    public void CheckMemberlist()
    {
        var session = BoltMatchmaking.CurrentSession;
        var photonSession = session as PhotonSession;

        TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();


        numberList = TToken.MemberID.ToList();
        numberNum = TToken.MemberNowIn;
        Debug.Log($"numberNum: {numberNum}");
    }



    private void Update()
    {
        CheckAllInBuilding();

    }

    private void CheckAllInBuilding()
    {
        
        if (totalCheck == numberNum * 2 && Ischeck == false)
        {

            //앞 문 닫기
            closedanim.SetBool("IsInBuild", true);
            Invoke("StartLight", 4.0f);
            Ischeck = true;

        }



    }

    private void StartLight()
    {
        SpotLights.SetActive(true);
        lightanim.SetBool("IsStart", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        // event
        if (other.tag == "Player")
        {
            totalCheck++;
            Debug.Log($"totalCheckMiddlePoint++: {totalCheck}");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // event
        if (other.tag == "Player")
        {
            totalCheck--;
            Debug.Log($"totalCheckMiddlePoint--: {totalCheck}");
        }
    }

}
