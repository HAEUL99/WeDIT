using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class ButtonRed : Photon.Bolt.GlobalEventListener
{
    public Rigidbody buttonrb;
    Renderer buttoncolor;
    public Renderer buttoncolororiginal;

    private GameObject bluelight;
    private GameObject redlight;
    private GameObject yellowlight;
    private GameObject bluelight1;


    void Awake()
    {
        buttonrb = GetComponent<Rigidbody>();
        bluelight = GameObject.Find("B_Light").gameObject;
        redlight = GameObject.Find("R_Light").gameObject;
        yellowlight = GameObject.Find("Y_Light").gameObject;
        bluelight1 = GameObject.Find("B_Light (1)").gameObject;
        buttoncolor = gameObject.GetComponent<Renderer>();

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
            switch (ButtonOrder.orderCount)
            {
                case 1:
                    var stage1ButtonEvnt = Stage1ButtonEvnt.Create();
                    ButtonOrder.orderCount = 2;
                    stage1ButtonEvnt.orderCount = ButtonOrder.orderCount;
                    stage1ButtonEvnt.Send();
                    //ButtonOrder.orderCount = 2;
                    Debug.Log($"빨: {ButtonOrder.orderCount}");
                    break;
                default:
                    var stage1ButtonEvnt1 = Stage1ButtonEvnt.Create();
                    ButtonOrder.orderCount = 0;
                    stage1ButtonEvnt1.orderCount = ButtonOrder.orderCount;
                    stage1ButtonEvnt1.Send();
                    //ButtonOrder.orderCount = 0;
                    Debug.Log($"reset: {ButtonOrder.orderCount}");
                    break;

            }
        }
            
        /*
        if (ButtonOrder.orderCount == 1)
        {
            ButtonOrder.orderCount = 2;
            Debug.Log($"빨: {ButtonOrder.orderCount}");
 
        }
        else
        {
            ButtonOrder.orderCount = 0;
            Debug.Log($"reset: {ButtonOrder.orderCount}");
        }
        */

    }


    private void OnCollisionExit(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player")
        {
            buttonrb.AddForce(Vector3.up * 10.0f, ForceMode.Acceleration);
            buttoncolor.material.color = buttoncolororiginal.material.color;
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
