using System.Collections;
using System.Collections.Generic;
using Photon.Bolt;
using UnityEngine;

/*
public class CloudandLever : Photon.Bolt.EntityBehaviour<IFlyingCloudState>
{
    public BoltEntity upleverCenter;
    public BoltEntity sideleverCenter;
    public BoltEntity forwardleverCenter;
    public BoltEntity cloud;
    public int speed = 1;

    public override void Attached()
    {

        state.SetTransforms(state.cloudTransform, transform);


        state.AddCallback("cloudTransform", Moveobject);

    }

    void Moveobject()
    {

        entity.transform.position = state.cloudTransform.Position;
        entity.transform.rotation = state.cloudTransform.Rotation;
    }


    
    private void Update()
    {
        Uplever();
        Sidelever();
        Forwardlever();


    }


    private void Uplever()
    {
       
        float upAngle = upleverCenter.transform.eulerAngles.x;
        //float angle_door = doorCenter.transform.eulerAngles.y;

        //var speed = 0.4f;
        var movement = Vector3.zero;
        //var movement = transform.InverseTransformPoint(Vector3.zero);


        if (upAngle > 20 && upAngle < 90)
        {
            if (cloud.transform.localPosition.y <= 180)
            {
                Debug.Log("++");
                movement.y += 1;
                //cloud.transform.localPosition = cloud.transform.localPosition + (movement.normalized * speed * BoltNetwork.FrameDeltaTime);
                cloud.transform.localPosition = cloud.transform.localPosition + (movement.normalized * speed * Time.deltaTime);
            }
        }
        if (upAngle < 340 && upAngle > 270)
        {
            if (cloud.transform.localPosition.y >= 170)
            {
                Debug.Log("--");
                movement.y -= 1;
                //cloud.transform.localPosition = cloud.transform.localPosition + (movement.normalized * speed * BoltNetwork.FrameDeltaTime);
                cloud.transform.localPosition = cloud.transform.localPosition + (movement.normalized * speed * Time.deltaTime);
            }
        }



    }

    private void Sidelever()
    {
        float sideAngle = sideleverCenter.transform.eulerAngles.x;


        if (sideAngle > 20 && sideAngle < 90)
        {
            //movement.z += 1;
            //cloud.transform.localPosition = cloud.transform.localPosition + (movement.normalized * speed * Time.deltaTime);
            cloud.transform.localPosition = cloud.transform.localPosition + (cloud.transform.forward * speed * Time.deltaTime);
        }

        //right
        if (sideAngle < 340 && sideAngle > 270)
        {
            Debug.Log("--");
            //movement.z -= 1;
            //cloud.transform.localPosition = cloud.transform.localPosition + (movement.normalized * speed * Time.deltaTime);
            cloud.transform.localPosition = cloud.transform.localPosition - (cloud.transform.forward * speed * Time.deltaTime);

        }


    }
    private void Forwardlever()
    {
        float forwardAngle = forwardleverCenter.transform.eulerAngles.x;


        if (forwardAngle > 20 && forwardAngle < 90)
        {
            //movement.x += 1;
            //cloud.transform.localPosition = cloud.transform.localPosition + (movement.normalized * speed * Time.deltaTime);
            cloud.transform.localPosition = cloud.transform.localPosition + (cloud.transform.right * speed * BoltNetwork.FrameDeltaTime);
        }

        //right
        if (forwardAngle < 350 && forwardAngle > 270)
        {
            //movement.x -= 1;
            //cloud.transform.localPosition = cloud.transform.localPosition + (movement.normalized * speed * Time.deltaTime);
            cloud.transform.localPosition = cloud.transform.localPosition - (cloud.transform.right * speed * BoltNetwork.FrameDeltaTime);
        }

    }

}
*/