using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public static class ButtonOrder
{
    public static int orderCount = 0;

    //순서: blue, red, yellow, blue

}

public class ButtonBlue : Photon.Bolt.GlobalEventListener
{
    public Rigidbody buttonrb;
    Renderer buttoncolor;
    public GameObject backdoor;
    public Renderer buttoncolororiginal;
    private GameObject bluelight;
    private GameObject redlight;
    private GameObject yellowlight;
    private GameObject bluelight1;
    public GameObject SpotLights;






    void Start()
    {
        buttonrb = GetComponent<Rigidbody>();
        buttoncolor = gameObject.GetComponent<Renderer>();
        bluelight = GameObject.Find("B_Light").gameObject;
        redlight = GameObject.Find("R_Light").gameObject;
        yellowlight = GameObject.Find("Y_Light").gameObject;
        bluelight1 = GameObject.Find("B_Light (1)").gameObject;
        SpotLights.SetActive(false);
    }



    private void OnCollisionStay(Collision Button1Click)
    {
        if (Button1Click.gameObject.tag == "Player")
        {

            buttonrb.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            buttoncolor.material.color = Color.white;
            //Ischecked = true;

            

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            
            
            switch (ButtonOrder.orderCount)
            {
                case 0:
                    var stage1ButtonEvnt = Stage1ButtonEvnt.Create();
                    ButtonOrder.orderCount = 1;
                    stage1ButtonEvnt.orderCount = ButtonOrder.orderCount;
                    stage1ButtonEvnt.Send();
                    //ButtonOrder.orderCount = 1;
                    Debug.Log($"파: {ButtonOrder.orderCount}");
                    break;
                case 3:
                    Debug.Log("문열림");
                    var stage1BackDoorOpenEvnt = Stage1BackDoorOpenEvnt.Create();
                    ButtonOrder.orderCount = 4;
                    stage1BackDoorOpenEvnt.IsOpen = true;
                    stage1BackDoorOpenEvnt.Send();
                    //Invoke("OpenBackdoor", 2.0f);
                    //CurrentStep.curentstep = 1;
               
                    break;
                default:
                    var stage1ButtonEvnt2 = Stage1ButtonEvnt.Create();
                    ButtonOrder.orderCount = 1;
                    stage1ButtonEvnt2.orderCount = ButtonOrder.orderCount;
                    stage1ButtonEvnt2.Send();
                    Debug.Log($"reset: {ButtonOrder.orderCount}");
                    break;


            }

        }
        


    }

    public override void OnEvent(Stage1ButtonEvnt evnt)
    {
        if (evnt.orderCount == 0)
        {

            bluelight.GetComponent<Light>().intensity = 10;
            bluelight1.GetComponent<Light>().intensity = 10;
            redlight.GetComponent<Light>().intensity = 6;
            yellowlight.GetComponent<Light>().intensity = 12;
        }
        if (evnt.orderCount == 1)
        {

            bluelight.GetComponent<Light>().intensity = 0;
            bluelight1.GetComponent<Light>().intensity = 10;
            redlight.GetComponent<Light>().intensity = 6;
            yellowlight.GetComponent<Light>().intensity = 12;
        }
        if (evnt.orderCount == 2)
        {
            redlight.GetComponent<Light>().intensity = 0;
        }
        if (evnt.orderCount == 3)
        {
            yellowlight.GetComponent<Light>().intensity = 0;
        }

        /*
        else
        {

            bluelight.GetComponent<Light>().intensity = 10;
            bluelight1.GetComponent<Light>().intensity = 10;
            redlight.GetComponent<Light>().intensity = 6;
            yellowlight.GetComponent<Light>().intensity = 12;
            //bluelight.SetActive(true);
            //redlight.SetActive(true);
            //yellowlight.SetActive(true);
            //bluelight1.SetActive(true);
        }
        */

    }


    public override void OnEvent(Stage1BackDoorOpenEvnt evnt)
    {
        if (evnt.IsOpen)
        {
            //bluelight.GetComponent<Light>().intensity = 0;
            bluelight1.GetComponent<Light>().intensity = 0;
            //redlight.GetComponent<Light>().intensity = 0;
            //yellowlight.GetComponent<Light>().intensity = 0;
            Invoke("OpenBackdoor", 2.0f);
            
        }
    }

    private void OpenBackdoor()
    {
        /*
        if (BoltNetwork.IsServer)
        {

            backdoor.GetComponent<Animator>().SetBool("IsButtonOn", true);
        }
        */
        backdoor.GetComponent<Animator>().SetBool("IsButtonOn", true);
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
