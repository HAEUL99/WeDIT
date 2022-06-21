using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuple : MonoBehaviour
{
    public Rigidbody buttonrb;
    Renderer buttoncolor;
    Renderer origincolor;
    public ButtonGreen buttonGreen;
    public GameObject cloud;
    public bool Ischecked = false;
    public Rigidbody s2levera;
    public Rigidbody s2leverb;
    public Rigidbody s2leverc;

    void Start()
    {
        buttonrb = GetComponent<Rigidbody>();
        buttoncolor = gameObject.GetComponent<Renderer>();
        origincolor = gameObject.GetComponent<Renderer>();
        cloud = buttonGreen.cloud;
        s2levera = cloud.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Rigidbody>();
        s2leverb = cloud.transform.GetChild(1).GetChild(3).gameObject.GetComponent<Rigidbody>();
        s2leverc = cloud.transform.GetChild(2).GetChild(3).gameObject.GetComponent<Rigidbody>();

    }



    private void OnCollisionStay(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player")
        {

            buttonrb.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            buttoncolor.material.color = Color.white;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Ischecked = !Ischecked;
            s2levera = buttonGreen.cloud.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Rigidbody>();
            s2leverb = buttonGreen.cloud.transform.GetChild(1).GetChild(3).gameObject.GetComponent<Rigidbody>();
            s2leverc = buttonGreen.cloud.transform.GetChild(2).GetChild(3).gameObject.GetComponent<Rigidbody>();
            if (Ischecked)
            {
                
                s2levera.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                s2leverb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                s2leverc.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

            }
            else
            {
                s2levera.constraints = ~RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                s2leverb.constraints = ~RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                s2leverc.constraints = ~RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            }
        }

    }


    private void OnCollisionExit(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player")
        {
            buttonrb.AddForce(Vector3.up * 10.0f, ForceMode.Acceleration);
            buttoncolor.material.color = origincolor.material.color;
        }

    }


    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Stop")
        {
            buttonrb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}
