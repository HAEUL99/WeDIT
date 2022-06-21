using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class ShowAnswer : Photon.Bolt.GlobalEventListener
{
    //public GameObject[] answerCloud;
    public Renderer[] cloudcolors;
    public Renderer blinkColor;
    public Renderer originalCloud;

    public Rigidbody buttonrb;
    Renderer buttoncolor;
    public Renderer buttoncolororiginal;

    void Start()
    {
        buttonrb = GetComponent<Rigidbody>();
        buttoncolor = gameObject.GetComponent<Renderer>();


        /*
        for (int i = 0; i < answerCloud.Length; i++)
        {
            cloudcolors[i] = answerCloud[i].GetComponent<Renderer>();
        }
        */
    }



    private void OnCollisionStay(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player")
        {

            buttonrb.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            buttoncolor.material.color = Color.white;

            for (int i = 0; i < cloudcolors.Length; i++)
            {
                cloudcolors[i].material.color = blinkColor.material.color;
            }


        }

    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Invoke("blinkCloud", 0.5f);
            Invoke("blinkCloud_origin", 1f);
            Invoke("blinkCloud", 1.3f);
            Invoke("blinkCloud_origin", 1.6f);
            Invoke("blinkCloud", 1.9f);
            Invoke("blinkCloud_origin", 2.1f);
        }



    }
    */
    public void blinkCloud()
    {
        for (int i = 0; i < cloudcolors.Length; i++)
        {
            cloudcolors[i].material.color = blinkColor.material.color;
        }


    }

    public void blinkCloud_origin()
    {

        for (int i = 0; i < cloudcolors.Length; i++)
        {
            cloudcolors[i].material.color = Color.white;
        }

    }


    private void OnCollisionExit(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player")
        {
            buttonrb.AddForce(Vector3.up * 10.0f, ForceMode.Acceleration);
            buttoncolor.material.color = buttoncolororiginal.material.color;

            for (int i = 0; i < cloudcolors.Length; i++)
            {
                cloudcolors[i].material.color = originalCloud.material.color;
            }
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
