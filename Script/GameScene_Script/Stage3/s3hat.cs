using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s3hat : Photon.Bolt.GlobalEventListener
{
    Button1Click button1click;
    public Rigidbody s3hatrig;
    // Start is called before the first frame update

    private bool first = true;
    void Start()
    {
        s3hatrig = GetComponent<Rigidbody>();
        button1click = GameObject.Find("DoorButton1").GetComponent<Button1Click>();
        var stage3ButtonEvt = Stage3ButtonEvt.Create();
        stage3ButtonEvt.Send();
    }

    // Update is called once per frame
    void Update()
    {
        if (button1click.s3button1clicked == true)
        {
            s3hatrig.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "s3mission2")
        {
            s3hatrig.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
        if (col.gameObject.tag == "Player")
        {
            s3hatrig.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }

    public override void OnEvent(Stage3ButtonEvt evnt)
    {
        if (evnt.s3Button1Clicked == true)
        {
            s3hatrig.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}
