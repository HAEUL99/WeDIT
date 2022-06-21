using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class S4Fly1 : Photon.Bolt.GlobalEventListener
{
    public GameObject s4Fly1;
    public Rigidbody s4flyRigidbody;
    S4Button1 s4button1;
    Vector3 start = new Vector3(-125.4f, 5.0f, -7.9f);
    Vector3 destination = new Vector3(-104.4f, 3.2f, 11.7f);
    public bool appleyes = false;
    // Start is called before the first frame update
    void Start()
    {
        s4flyRigidbody = GetComponent<Rigidbody>();
        s4button1 = GameObject.Find("S4DoorButton1").GetComponent<S4Button1>();
        var stage4ButtonEvt = Stage4ButtonEvt.Create();
    }

    // Update is called once per frame
    void Update()
    {
        if (s4button1.s4button1clicked == true && appleyes == false)
        {
            transform.position = Vector3.Slerp(transform.position, start, 0.02f);
            s4flyRigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }

    private void OnCollisionEnter(Collision apple)
    {
        if (apple.gameObject.tag == "Stop")
        {
            var stage4ButtonEvt = Stage4ButtonEvt.Create();
            stage4ButtonEvt.isS4Apple = true;
            stage4ButtonEvt.Send();
            appleyes = true;
        }
    }
    public override void OnEvent(Stage4ButtonEvt evnt)
    {
        if (evnt.isS4Button1 == true && evnt.isS4Apple == false)
        {
            transform.position = Vector3.Slerp(transform.position, start, 0.02f);
            s4flyRigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}

