using UnityEngine;
using System;
using System.Collections;
using Photon.Bolt;

public class GrabObj_Pickup : Photon.Bolt.GlobalEventListener
{
    public BoltEntity targetObj;
    public BoltConnection boltConnection;

    private Rigidbody rigidbody;
    private Transform parent;

    private bool isGrabbed = false;
    public bool working = false;


    private void Awake() {
        targetObj = gameObject.GetComponent<BoltEntity>();
        parent = transform.parent;
        rigidbody = GetComponent<Rigidbody>();
    }

    public void getObj(BoltEntity obj)
    {
        targetObj = obj;

    }



    private void Update() {
        if ((Vector3.Distance(new Vector3(targetObj.transform.position.x, 0, targetObj.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z)) < 1)) { 
            //플레이어가 가까이 있을 때
            if (Input.GetMouseButtonDown(0)) { //왼쪽 클릭을 입력받아서
                working = true;
                var isGrab = GrabObjEvnt.Create();
                isGrab.Player = targetObj;
                isGrab.isGrabbed = true;
                isGrab.thisObject = gameObject.GetComponent<BoltEntity>();
                isGrab.Send();

            }
            if (Input.GetMouseButtonUp(0))
            { //놓을 때 이동
                Graboff();
            }

        }
        
    }

    public override void OnEvent(GrabObjEvnt evnt)
    {
        if (evnt.isGrabbed == true && evnt.thisObject == gameObject.GetComponent<BoltEntity>())
        {
            StartCoroutine(GrabOn(evnt.Player));

      
        }
        if(evnt.isGrabbed == false && evnt.thisObject == gameObject.GetComponent<BoltEntity>())
        {
            evnt.Player.GetComponent<PlayerInteraction>().pickdown();
            transform.SetParent(parent);
            evnt.Player.GetComponent<PlayerController>().state.isGrabbing = 0; //플레이어 상태 갱신
            isGrabbed = false;
            rigidbody.isKinematic = false;
        }
    }

    IEnumerator GrabOn(BoltEntity player)
    {
        if(working) player.GetComponent<PlayerInteraction>().pickupFirst(this);
        else yield break;

        yield return new WaitForSeconds(0.5f);
        
        if(working) rigidbody.isKinematic = true;
        else yield break;
        if(working) player.GetComponent<PlayerInteraction>().pickupSecond(transform,this);
        else yield break;
        
        yield return new WaitForSeconds(0.5f);
        if(working) player.GetComponent<PlayerInteraction>().pickupThird(transform,this);
        else yield break;
        



    }

    public void Graboff() {
        working = false;
        var isGrab = GrabObjEvnt.Create();
        isGrab.Player = targetObj;
        isGrab.isGrabbed = false;
        isGrab.thisObject = gameObject.GetComponent<BoltEntity>();
        isGrab.Send();
    }

}
