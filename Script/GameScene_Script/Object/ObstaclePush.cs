using System.Collections;
using System.Collections.Generic;
using Photon.Bolt;
using UnityEngine;

public class ObstaclePush : Photon.Bolt.GlobalEventListener
{
    // 물건마다 rigidbody mass 값 정하기 
    // forceMagnitude 값 정하기 
    private float forceMagnitude = 50;


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //닿은 물건의 rigidbody 가져옴 
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        //BoltEntity hitobject = (BoltEntity)hit.collider.gameObject;

        /*

        public override void OnEvent(ColliderHitEvent evnt)
    {
        Rigidbody rigidbody = evnt.rbObject;
        rigidbody.AddForceAtPosition(evnt.force, evnt.position, ForceMode.Force);

    }
        */
        if (rigidbody != null)
        {
            //내 힘의 방향을 구함
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();


            //ColliderHitEvent evnt = ColliderHitEvent.Create();
            //evnt.force = forceDirection * forceMagnitude;
            //evnt.position = transform.position;
           // evnt.rbObject = hitobject;


            //rigidbody에 힘적용
            //ForceMode.Force : 리지드바디 질량 고려해서 꾸준히 힘 주는거
            //ForceMode.Impulse: 리지드바디 질량 고려해서 짧은 순간 힘 주는
            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Force);

        }

    }

}
