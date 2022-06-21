using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class Button2Click : Photon.Bolt.GlobalEventListener
{
    public Rigidbody s3button2Rigidbody;
    Renderer s3Button2Color;
    public bool s3button2clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        s3button2Rigidbody = GetComponent<Rigidbody>();
        s3Button2Color = gameObject.GetComponent<Renderer>();
        s3button2Rigidbody.AddForce(Vector3.up * 10.0f, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player" || Button1Click.gameObject.tag == "WakeUpObj")
        {
            var stage3ButtonEvt = Stage3ButtonEvt.Create();
            stage3ButtonEvt.s3Button2Clicked = true;
            stage3ButtonEvt.Send();
            s3button2Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            s3Button2Color.material.color = Color.white;
            s3button2clicked = true;
        }
    }

    private void OnCollisionStay(Collision Button2Click)
    {
        if (Button2Click.gameObject.tag == "Player" || Button2Click.gameObject.tag == "WakeUpObj")
        {
            var stage3ButtonEvt = Stage3ButtonEvt.Create();
            stage3ButtonEvt.s3Button2Clicked = true;
            stage3ButtonEvt.Send();
            s3button2Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation; ;
            s3Button2Color.material.color = Color.red;
            s3button2clicked = true;
        }
    }

    private void OnCollisionExit(Collision Button2Click)
    {
        if (Button2Click.gameObject.tag == "Player" || Button2Click.gameObject.tag == "WakeUpObj")
        {
            var stage3ButtonEvt = Stage3ButtonEvt.Create();
            stage3ButtonEvt.s3Button2Clicked = false;
            stage3ButtonEvt.Send();
            s3button2Rigidbody.AddForce(Vector3.up * 10.0f, ForceMode.Acceleration);
            s3Button2Color.material.color = Color.black;
            s3button2clicked = false;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Stop")
        {
            s3button2Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}
