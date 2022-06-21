using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;


public class S4Fly2 : Photon.Bolt.GlobalEventListener
{
    public GameObject s4Fly2;
    public Rigidbody s4fly2Rigidbody;
    S4Button2 s4button2;
    Vector3 destination = new Vector3(-135.1f, 1.0f, 5.0f);
    public bool bananayes = false;
    // Start is called before the first frame update
    void Start()
    {
        s4fly2Rigidbody = GetComponent<Rigidbody>();
        s4button2 = GameObject.Find("S4DoorButton2").GetComponent<S4Button2>();
        var stage4ButtonEvt = Stage4ButtonEvt.Create();
    }

    // Update is called once per frame
    void Update()
    {
        if (s4button2.s4button2clicked == true && bananayes == false)
        {
            transform.position = Vector3.Slerp(transform.position, destination, 0.02f);
            s4fly2Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }

    private void OnCollisionEnter(Collision banana)
    {
        if (banana.gameObject.tag == "Stop")
        {
            var stage4ButtonEvt = Stage4ButtonEvt.Create();
            stage4ButtonEvt.isS4Banana = true;
            stage4ButtonEvt.Send();
            bananayes = true;
        }
    }
    public override void OnEvent(Stage4ButtonEvt evnt)
    {
        if (evnt.isS4Button2 == true && evnt.isS4Banana == false)
        {
            transform.position = Vector3.Slerp(transform.position, destination, 0.02f);
            s4fly2Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}

