using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;
using Photon.Bolt.Matchmaking;
using UdpKit.Platform.Photon;
using Photon.Bolt.Utils;

public class Stage4_clear_box : Photon.Bolt.GlobalEventListener
{
    public GameObject stage4Door;
    bool doorFlag = false;
    bool IsFinishCheck = false;
    public GameObject FinishUI;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (other.tag == "stage4_succ")
        {
            //문열리기
            

            Debug.Log("succ");
            doorFlag = true;
        }
        else if (other.tag == "stage4_fail")
        {
            rb.AddForce(new Vector3(6, 6, 6), ForceMode.Impulse);
            Debug.Log("fail");
        }
    }
    void Start()
    {
        FinishUI.SetActive(false);
    }

    void Update()
    {
        if (doorFlag)
        {
            IsFinishCheck = true;
            Quaternion desired = Quaternion.Euler(0, 180, 0);
            stage4Door.transform.rotation = Quaternion.Lerp(stage4Door.transform.rotation, desired, 0.01f);

            //게임 끝 ui 띄우기
            Invoke("ShowFinishUI", 3.0f);
            //모두 로비로 돌리기
            Invoke("GotoLobby", 6.0f);

        }
    }


    void ShowFinishUI()
    {
        FinishUI.SetActive(true);
        Time.timeScale = 0;
    }

    void GotoLobby()
    {
        if (BoltNetwork.IsServer)
        {

            BoltNetwork.LoadScene("Lobby");

            BoltLauncher.Shutdown();
            //BoltLauncher.StartClient();

        }

        if (BoltNetwork.IsClient)
        {
            BoltNetwork.LoadScene("Lobby");
        }


     
        

    }
    
    
}
