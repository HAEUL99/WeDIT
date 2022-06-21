using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s3hatfreeze : Photon.Bolt.GlobalEventListener
{
    public Rigidbody s3hatRigidbody;
    s3WindMill s3windmill;
    // Start is called before the first frame update
    void Start()
    {
        s3windmill = GameObject.Find("s3WindMill").GetComponent<s3WindMill>();
        s3hatRigidbody = GetComponent<Rigidbody>();
        var stage3ButtonEvt = Stage3ButtonEvt.Create();
    }

    // Update is called once per frame
    void Update()
    {
        if (s3windmill.iss3windmill == true)
        {
            s3hatRigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "s3mission1")
        {
            s3hatRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
        if (col.gameObject.tag == "Player")
        {
            s3hatRigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }

    public override void OnEvent(Stage3ButtonEvt evnt)
    {
        if (evnt.isS3WindMill == true)
        {
            s3hatRigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}
