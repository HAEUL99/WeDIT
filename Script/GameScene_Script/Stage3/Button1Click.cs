using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class Button1Click : Photon.Bolt.GlobalEventListener
{
    public Rigidbody s3button1Rigidbody;
    Renderer s3Button1Color;
    public bool s3button1clicked = false;
    public GameObject s3Hat;

    // Start is called before the first frame update
    void Start()
    {
        s3button1Rigidbody = GetComponent<Rigidbody>();
        s3Button1Color = gameObject.GetComponent<Renderer>();
    }
    private void OnCollisionEnter(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player" || Button1Click.gameObject.tag == "WakeUpObj")
        {
            var stage3ButtonEvt = Stage3ButtonEvt.Create();
            stage3ButtonEvt.s3Button1Clicked = true;
            stage3ButtonEvt.s3HatActive = true;
            stage3ButtonEvt.Send();
            s3button1Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            s3Button1Color.material.color = Color.white;
            s3button1clicked = true;
            s3Hat.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnCollisionStay(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player" || Button1Click.gameObject.tag == "WakeUpObj")
        {
            s3button1Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            s3Button1Color.material.color = Color.white;
            s3button1clicked = true;
            s3Hat.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnCollisionExit(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player" || Button1Click.gameObject.tag == "WakeUpObj")
        {
            var stage3ButtonEvt = Stage3ButtonEvt.Create();
            stage3ButtonEvt.s3Button1Clicked = false;
            stage3ButtonEvt.Send();
            s3button1Rigidbody.AddForce(Vector3.up * 10.0f, ForceMode.Acceleration);
            s3Button1Color.material.color = Color.black;
            s3button1clicked = false;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Stop")
        {
            s3button1Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }

    public override void OnEvent(Stage3ButtonEvt evnt)
    {
        if (evnt.s3HatActive == true)
        {
            s3Hat.SetActive(true);
        }
    }
}
