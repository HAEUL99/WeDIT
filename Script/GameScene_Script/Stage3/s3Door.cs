using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s3Door : Photon.Bolt.GlobalEventListener
{
    s3mission1 s3Mission1;
    s3mission2 s3Mission2;
    public GameObject s3door;
    public Rigidbody s3doorRigidbody;
    public bool s3DoorOpened = false;
    Vector3 start = new Vector3(-123.1f, -0.5f, -26.0f);
    Vector3 destination = new Vector3(-132.5f, -0.5f, -29.8f);
    // Start is called before the first frame update
    void Start()
    {
        s3doorRigidbody = GetComponent<Rigidbody>();
        s3Mission1 = GameObject.Find("s3mission1").GetComponent<s3mission1>();
        s3Mission2 = GameObject.Find("s3mission2").GetComponent<s3mission2>();
        var stage3ClearEvt = Stage3ClearEvt.Create();
    }

    // Update is called once per frame
    void Update()
    {
        if (s3Mission1.s3misiion1clear == true && s3Mission2.s3misiion2clear == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.05f);
            s3doorRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            s3DoorOpened = true;
        }
        else
        {
            if (s3door.transform.position.x <= -123.1f)
            {
                s3doorRigidbody.constraints = ~RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                transform.position = Vector3.MoveTowards(transform.position, start, 0.05f);
                s3doorRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            }
        }
    }

    public override void OnEvent(Stage3ClearEvt evnt)
    {
        if (evnt.isS3Mission1 == true && evnt.isS3Mission2 == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.05f);
            s3doorRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            s3DoorOpened = true;
        }
        else
        {
            if (s3door.transform.position.x <= -123.1f)
            {
                s3doorRigidbody.constraints = ~RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                transform.position = Vector3.MoveTowards(transform.position, start, 0.05f);
                s3doorRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}
