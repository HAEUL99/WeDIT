using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class S4Button2 : Photon.Bolt.GlobalEventListener
{
    public Rigidbody s4button2Rigidbody;
    Renderer s4Button2Color;
    public GameObject s4Button2;
    public bool s4button2clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        s4button2Rigidbody = GetComponent<Rigidbody>();
        s4Button2Color = gameObject.GetComponent<Renderer>();
        s4button2Rigidbody.AddForce(Vector3.up * 10.0f, ForceMode.Acceleration);
    }

    private void OnCollisionStay(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player" || Button1Click.gameObject.tag == "WakeUpObj")
        {
            var stage4ButtonEvt = Stage4ButtonEvt.Create();
            stage4ButtonEvt.isS4Button2 = true;
            stage4ButtonEvt.Send();
            s4button2Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            s4Button2Color.material.color = Color.red;
            s4button2clicked = true;
        }
    }

    private void OnCollisionExit(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player" || Button1Click.gameObject.tag == "WakeUpObj")
        {
            var stage4ButtonEvt = Stage4ButtonEvt.Create();
            stage4ButtonEvt.isS4Button2 = false;
            stage4ButtonEvt.Send();
            s4button2Rigidbody.AddForce(Vector3.up * 10.0f, ForceMode.Acceleration);
            s4Button2Color.material.color = Color.black;
            s4button2clicked = false;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Stop")
        {
            s4button2Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}
