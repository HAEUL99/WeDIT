using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class CloudVisible : Photon.Bolt.GlobalEventListener
{
    public GameObject nextcloudrs1, nextcloudrs2, nextcloudrs3, nextcloudrs4;
    //public Vector3 spawnPos1, spawnPos2, spawnPos3, spawnPos4;
    //public GameObject nextcloud;
    public bool Ischecked = false;

    private void Start()
    {
        nextcloudrs1.SetActive(false);
        nextcloudrs2.SetActive(false);
        nextcloudrs3.SetActive(false);
        nextcloudrs4.SetActive(false);
        //nextcloudrs1 = Resources.Load<GameObject>($"UI_pref/SpawnObject/Stage2/Cloud1");
        // nextcloudrs2 = Resources.Load<GameObject>($"UI_pref/SpawnObject/Stage2/Cloud2");
        // nextcloudrs3 = Resources.Load<GameObject>($"UI_pref/SpawnObject/Stage2/Cloud3");
        // nextcloudrs4 = Resources.Load<GameObject>($"UI_pref/SpawnObject/Stage2/Cloud4");
        //spawnPos1 = GameObject.Find("cloudSpawn1").transform.position;
        //spawnPos2 = GameObject.Find("cloudSpawn2").transform.position;
        //spawnPos3 = GameObject.Find("cloudSpawn3").transform.position;
        //spawnPos4 = GameObject.Find("cloudSpawn4").transform.position;
    }

    private void OnTriggerStay(Collider col)
    {
        if (Ischecked == false)
        {
            //nextcloud = BoltNetwork.Instantiate(nextcloudrs, spawnPos, Quaternion.Euler(0, 0, 0));
            //nextcloud = Instantiate(nextcloudrs1, spawnPos1, Quaternion.Euler(0, 0, 0));
            //nextcloudrs1.SetActive = true;

            //state.SetActive = true;
            //nextcloudrs1.SetActive(state.SetActive);
            var cloudevnt = CloudVisibleEvnt.Create();
            cloudevnt.setActive = true;
            cloudevnt.numOfcloud = 1;
            cloudevnt.Send();

            Ischecked = true;
        }

    }

    public override void OnEvent(CloudVisibleEvnt evnt)
    {
        if(evnt.setActive == true && evnt.numOfcloud == 1)
        {
            nextcloudrs1.SetActive(true);
        }
    }


}
