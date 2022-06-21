using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s3Wall : Photon.Bolt.GlobalEventListener
{
    public GameObject s3wall;
    s3Door s3door;
    // Start is called before the first frame update
    void Start()
    {
        s3door = GameObject.Find("s3door").GetComponent<s3Door>();
        var stage3ClearEvt = Stage3ClearEvt.Create();
    }

    // Update is called once per frame
    void Update()
    {
        if(s3door.s3DoorOpened == true)
        {
            s3wall.SetActive(false);
        }
    }

    public override void OnEvent(Stage3ClearEvt evnt)
    {
        if (evnt.isS3Clear == true)
        {
            s3wall.SetActive(false);
        }
    }
}
