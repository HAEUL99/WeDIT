using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;
using PolyverseSkiesAsset;
using Photon.Bolt.Matchmaking;
using UdpKit.Platform.Photon;
using System.Linq;
using Photon.Bolt.Utils;

public class EndingDetect : Photon.Bolt.GlobalEventListener
{
    //사진 object
    public Animator photoObject;
    //전체 조명
    public Light directionalLight;
    //스포트라이트
    public GameObject spotlightob;
    public Light spotLight;
    //하늘
    public GameObject sky;
    public GameObject blackcolor;

    //플레이어 카메라
    private GameObject[] cameras;


    public List<string> numberList;
    public int numberNum;
    public int totalCheck = 0;
    private bool Ischeck = false;

    private void Start()
    { 
        //photoObject.SetActive(false);
        spotlightob.SetActive(false);
        CheckMemberlist();

    }

    public void CheckMemberlist()
    {
        var session = BoltMatchmaking.CurrentSession;
        var photonSession = session as PhotonSession;

        TeamToken TToken = (TeamToken)photonSession.GetProtocolToken();


        numberList = TToken.MemberID.ToList();
        numberNum = TToken.MemberNowIn;
        Debug.Log($"numberNum7: {numberNum}");
    }

    private void Update()
    {
        CheckAllInEndArea();
    }

    private void CheckAllInEndArea()
    {

        if (totalCheck == numberNum * 2 && Ischeck == false)
        {

            cameras = GameObject.FindGameObjectsWithTag("MainCamera");
            Debug.Log($"cameras: {cameras.Length}");

            var endingEvnt = EndingEvnt.Create();
            endingEvnt.setActive = true;
            endingEvnt.Send();
            Ischeck = true;

        }



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

    /*
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            cameras = GameObject.FindGameObjectsWithTag("MainCamera");
            Debug.Log($"cameras: {cameras.Length}");

            var endingEvnt = EndingEvnt.Create();
            endingEvnt.setActive = true;
            endingEvnt.Send();
            
            
        }


    }
    */



    public override void OnEvent(EndingEvnt evnt)
    {
        if (evnt.setActive)
        {
            directionalLight.intensity = 0.0f;

            Debug.Log($"cameras1: {cameras.Length}");
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;

            }

            //photoObject.SetActive(true);
            photoObject.SetBool("IsSet", true);
            
            Invoke("SetLight", 4.5f);
            Invoke("GoToLobby", 16.0f);
            
        }
    }

    void SetLight()
    {
        spotlightob.SetActive(true);
    }

    void GoToLobby()
    {
        BoltNetwork.LoadScene("Lobby");
        Invoke("ShutDownServer", 3.0f);

    }
    void ShutDownServer()
    {
        if (BoltNetwork.IsServer)
        {
            BoltLauncher.Shutdown();
        }
    }
}
