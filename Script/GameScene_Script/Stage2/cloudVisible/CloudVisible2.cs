using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class CloudVisible2 : Photon.Bolt.GlobalEventListener
{
    public GameObject nextcloudrs3;
    public CloudVisible cloudvisible;
    private GameObject nextcloudrs;
    private Vector3 spawnPos;
    private GameObject nextcloud;
    public bool Ischecked = false;

    /*
    private void Start()
    {
        nextcloudrs = Resources.Load<GameObject>($"UI_pref/SpawnObject/Stage2/Cloud3");
        spawnPos = GameObject.Find("cloudSpawn3").transform.position;
    }
    */
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
            cloudevnt.numOfcloud = 3;
            cloudevnt.Send();

            Ischecked = true;
        }

    }

    public override void OnEvent(CloudVisibleEvnt evnt)
    {
        if (evnt.setActive == true && evnt.numOfcloud == 3)
        {
            nextcloudrs3.SetActive(true);
        }
    }
}
