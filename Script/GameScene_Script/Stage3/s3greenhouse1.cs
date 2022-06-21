using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s3greenhouse1 : Photon.Bolt.GlobalEventListener
{
    s3Ball1 s3ball1;
    s3Ball2 s3ball2;
    s3Ball3 s3ball3;
    public GameObject s3Greenhouse1;
    public Rigidbody s3greenhouserig1;
    Vector3 start = new Vector3(-116.2f, 0.4f, -61.8f);
    Vector3 destination = new Vector3(-115.5f, 0.4f, -60.7f);
    // Start is called before the first frame update
    void Start()
    {
        s3greenhouserig1 = GetComponent<Rigidbody>();
        s3ball1 = GameObject.Find("ball1check").GetComponent<s3Ball1>();
        s3ball2 = GameObject.Find("ball2check").GetComponent<s3Ball2>();
        s3ball3 = GameObject.Find("ball3check").GetComponent<s3Ball3>();
        var stage3BallEvt = Stage3BallEvt.Create();
    }

    // Update is called once per frame
    void Update()
    {
        if (s3ball1.iss3ball1 == true && s3ball2.iss3ball2 == true && s3ball3.iss3ball3 == true)
        {
            transform.position =Vector3.MoveTowards(transform.position, destination, 0.01f);
            s3greenhouserig1.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            if(s3Greenhouse1.transform.position.x >= -116.2f)
            {
                s3greenhouserig1.constraints = ~RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                transform.position = Vector3.MoveTowards(transform.position, start, 0.01f);
                s3greenhouserig1.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            }
               
        }
    }

    public override void OnEvent(Stage3BallEvt evnt)
    {
        if (evnt.isS3Ball1 == true && evnt.isS3Ball2 == true && evnt.isS3Ball3 == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.01f);
            s3greenhouserig1.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            if (s3Greenhouse1.transform.position.x >= -116.2f)
            {
                s3greenhouserig1.constraints = ~RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                transform.position = Vector3.MoveTowards(transform.position, start, 0.01f);
                s3greenhouserig1.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}
