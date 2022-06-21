using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s4flowerright : Photon.Bolt.GlobalEventListener
{
    s4applebox s4AppleBox;
    S4BananaBox s4bananabox;
    public Rigidbody s4clearrightrig;
    // Start is called before the first frame update
    void Start()
    {
        s4clearrightrig = GetComponent<Rigidbody>();
        s4AppleBox = GameObject.Find("s4AppleBox").GetComponent<s4applebox>();
        s4bananabox = GameObject.Find("s4BananaBox").GetComponent<S4BananaBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (s4AppleBox.s4appleyes == true && s4bananabox.s4bananayes == true)
        {
            s4clearrightrig.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            s4clearrightrig.AddForce(Vector3.down * 10.0f, ForceMode.Acceleration);
        }
    }

    public override void OnEvent(Stage4ClearEvt evnt)
    {
        if (evnt.isS4AppleBox == true && evnt.isS4BananaBox == true)
        {
            s4clearrightrig.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            s4clearrightrig.AddForce(Vector3.down * 10.0f, ForceMode.Acceleration);
        }
    }
}
