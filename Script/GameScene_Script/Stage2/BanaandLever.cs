using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class BanaandLever : Photon.Bolt.GlobalEventListener
{
    public GameObject upleverCenter;
    public GameObject sideleverCenter;
    public GameObject forwardleverCenter;
    public GameObject banana;

    private void Update()
    {
        Uplever();
        Sidelever();
        Forwardlever();


    }


    private void Uplever()
    {
        float angle_lever = upleverCenter.transform.eulerAngles.x;


        var speed = 0.4f;
        var movement = Vector3.zero;

        //up
        if (angle_lever > 10 && angle_lever < 90)
        {
            if (banana.transform.localPosition.y <= 195)
            {
                movement.y += 1;
                banana.transform.localPosition = banana.transform.localPosition + (movement.normalized * speed * BoltNetwork.FrameDeltaTime);
            }

        }

        //down
        if (angle_lever < 350 && angle_lever > 270)
        {
            if (banana.transform.localPosition.y >= 175)
            {
                movement.y -= 1;
                banana.transform.localPosition = banana.transform.localPosition + (movement.normalized * speed * BoltNetwork.FrameDeltaTime);
            }

        }








    }

    private void Sidelever()
    {
        float angle_lever = sideleverCenter.transform.eulerAngles.x;

        var speed = 0.4f;


        //left
        if (angle_lever > 10 && angle_lever < 90)
        {
            //if (banana.transform.localPosition.z <= 62)
            {

                banana.transform.localPosition = banana.transform.localPosition + (banana.transform.forward * speed * BoltNetwork.FrameDeltaTime);
            }

        }

        //right
        if (angle_lever < 350 && angle_lever > 270)
        {
           // if (banana.transform.localPosition.z >= 59)
            {

                banana.transform.localPosition = banana.transform.localPosition - (banana.transform.forward * speed * BoltNetwork.FrameDeltaTime);
            }

        }


    }
    private void Forwardlever()
    {
        float angle_lever = forwardleverCenter.transform.eulerAngles.x;

        var speed = 0.4f;


        //left
        if (angle_lever > 10 && angle_lever < 90)
        {

           // if (banana.transform.localPosition.x <= -87)
            {

                banana.transform.localPosition = banana.transform.localPosition + (banana.transform.right * speed * BoltNetwork.FrameDeltaTime);
            }

        }

        //right
        if (angle_lever < 350 && angle_lever > 270)
        {
            //if (banana.transform.localPosition.x >= -126)
            {

                banana.transform.localPosition = banana.transform.localPosition - (banana.transform.right * speed * BoltNetwork.FrameDeltaTime);
            }

        }
    }
}
