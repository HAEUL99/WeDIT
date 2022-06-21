using UnityEngine;
using System;
using System.Collections;
using Photon.Bolt;

public class GrabObj_PickHat : Photon.Bolt.GlobalEventListener
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
        if ((Vector3.Distance(new Vector3(targetObj.transform.position.x, 0, targetObj.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z)) < 2))
        { //�÷��̾ ������ ���� ��
            if (Input.GetMouseButtonDown(0))
            { //���� Ŭ���� �Է¹޾Ƽ�
                working = true;
                var isGrab = GrabObjEvnt.Create();
                isGrab.Player = targetObj;
                isGrab.isGrabbed = true;
                isGrab.thisObject = gameObject.GetComponent<BoltEntity>();
                isGrab.Send();

            }
            if (Input.GetMouseButtonUp(0))
            { //���� �� �̵�
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
        player.GetComponent<PlayerInteraction>().pickupFirst(this);

        yield return new WaitForSeconds(0.5f);
        rigidbody.isKinematic = true;
        player.GetComponent<PlayerInteraction>().pickupSecond(transform,this);
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerInteraction>().pickupThird(transform,this);



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
