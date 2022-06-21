using UnityEngine;
using System;
using Photon.Bolt;

public class PlayerInteraction : Photon.Bolt.EntityBehaviour<IPlayerState>
{

    private GameObject player;
    private GameObject Geometry;
    private GameObject RigGeometry;
    private Transform Hand;
    private Transform RigHand;
    private PlayerController Controller;
    private Animator Animator;


    private GameObject[] WakeUpObj;

    public override void Attached()
    {
        player = this.gameObject;
        Geometry = transform.Find("Geometry").gameObject;
        RigGeometry = transform.Find("Rig").Find("Geometry").gameObject;
        Hand = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
        RigHand = transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
        Controller = GetComponent<PlayerController>();
        Animator = transform.Find("Rig").GetComponent<Animator>();
        state.SetAnimator(Animator);
        state.SetTransforms(state.RigTransform, transform.Find("Rig").transform);
        state.SetTransforms(state.HandTransform, Hand.transform);
        state.SetTransforms(state.RigHandTransform, RigHand.transform);
        state.AddCallback("RigOn", GeometryChange);


        if (!entity.IsOwner) return;
        // 잡기 오브젝트들에게 플레이어 오브젝트라고 메세징하는 부분
        
        WakeUpObj = GameObject.FindGameObjectsWithTag("WakeUpObj");
        foreach (GameObject Obj in WakeUpObj)
        {
            Obj.SendMessage("getObj", this.entity, SendMessageOptions.DontRequireReceiver);
        }
        
        WakeUpObj = GameObject.FindGameObjectsWithTag("s3ball3");
        foreach (GameObject Obj in WakeUpObj)
        {
            Obj.SendMessage("getObj", this.entity, SendMessageOptions.DontRequireReceiver);
        }
        
        WakeUpObj = GameObject.FindGameObjectsWithTag("s3ball2");
        foreach (GameObject Obj in WakeUpObj)
        {
            Obj.SendMessage("getObj", this.entity, SendMessageOptions.DontRequireReceiver);
        }
        WakeUpObj = GameObject.FindGameObjectsWithTag("s3ball1");
        foreach (GameObject Obj in WakeUpObj)
        {
            Obj.SendMessage("getObj", this.entity, SendMessageOptions.DontRequireReceiver);
        }
        WakeUpObj = GameObject.FindGameObjectsWithTag("s3hat2");
        foreach (GameObject Obj in WakeUpObj)
        {
            Obj.SendMessage("getObj", this.entity, SendMessageOptions.DontRequireReceiver);
        }
        WakeUpObj = GameObject.FindGameObjectsWithTag("s3hat1");
        foreach (GameObject Obj in WakeUpObj)
        {
            Obj.SendMessage("getObj", this.entity, SendMessageOptions.DontRequireReceiver);
        }
        WakeUpObj = GameObject.FindGameObjectsWithTag("s4apple");
        foreach (GameObject Obj in WakeUpObj)
        {
            Obj.SendMessage("getObj", this.entity, SendMessageOptions.DontRequireReceiver);
        }
        WakeUpObj = GameObject.FindGameObjectsWithTag("s4banana");
        foreach (GameObject Obj in WakeUpObj)
        {
            Obj.SendMessage("getObj", this.entity, SendMessageOptions.DontRequireReceiver);
        }
        // 잡기 오브젝트들에게 플레이어 오브젝트라고 메세징하는 부분
        
    }

    public void pickupFirst(GrabObj_Pickup traget)
    {
        if(traget.working) {
            state.RigOn = true;
        } else return;
        if(traget.working) {
            state.grabAnimation = 1;
        } else return;
        if(traget.working) {
            Animator.SetInteger("grabAnimation", state.grabAnimation);
        } else return;
    }
    public void pickupFirst(GrabObj_PickupBig traget)
    {
        if(traget.working) {
            state.RigOn = true;
        } else return;
        if(traget.working) {
            state.grabAnimation = 1;
        } else return;
        if(traget.working) {
            Animator.SetInteger("grabAnimation", state.grabAnimation);
        } else return;
    }
    public void pickupFirst(GrabObj_PickHat traget)
    {
        if(traget.working) {
            state.RigOn = true;
        } else return;
        if(traget.working) {
            state.grabAnimation = 1;
        } else return;
        if(traget.working) {
            Animator.SetInteger("grabAnimation", state.grabAnimation);
        } else return;
    }

    public void pickupSecond(Transform targetTransform,GrabObj_Pickup traget)
    {
        if(traget.working) {
            targetTransform.SetParent(RigHand);
        } else return;
        if(traget.working) {
            targetTransform.position = RigHand.position;
        } else return;
        if(traget.working) {
            targetTransform.eulerAngles = (RigHand.eulerAngles);
        } else return;
        // ^ 오브젝트 이동(플레이어 손바닥 위치)
        // ^ 오브젝트를 플레이어 손바닥에 직각으로 rotation 시킴
    }

    public void pickupSecond(Transform targetTransform,GrabObj_PickupBig traget)
    {
        if(traget.working) {
            targetTransform.SetParent(RigHand);
        } else return;
        if(traget.working) {
            targetTransform.position = RigHand.position;
        } else return;
        if(traget.working) {
            targetTransform.eulerAngles = (RigHand.eulerAngles);
        } else return;
        // ^ 오브젝트 이동(플레이어 손바닥 위치)
        // ^ 오브젝트를 플레이어 손바닥에 직각으로 rotation 시킴
    }

    public void pickupSecond(Transform targetTransform,GrabObj_PickHat traget)
    {
        if(traget.working) {
            targetTransform.SetParent(RigHand);
        } else return;
        if(traget.working) {
            targetTransform.position = RigHand.position;
        } else return;
        if(traget.working) {
            targetTransform.eulerAngles = (RigHand.eulerAngles);
        } else return;
        // ^ 오브젝트 이동(플레이어 손바닥 위치)
        // ^ 오브젝트를 플레이어 손바닥에 직각으로 rotation 시킴
    }

    public void pickupThird(Transform targetTransform,GrabObj_Pickup traget)
    {
        if(traget.working) {
            state.RigOn = false;
        } else return;
        if(traget.working) {
            state.grabAnimation = 0;
        } else return;
        if(traget.working) {
            Animator.SetInteger("grabAnimation", state.grabAnimation);
        } else return;
        if(traget.working) {
            targetTransform.SetParent(Hand);
        } else return;
        if(traget.working) {
            targetTransform.position = Hand.position;
        } else return;
        if(traget.working) {
            targetTransform.eulerAngles = (Hand.eulerAngles);
        } else return;
        if(traget.working) {
            Controller.state.isGrabbing = 1;
        } else return;

        // ^ 오브젝트 이동(플레이어 손바닥 위치)

         //플레이어 상태 갱신
    }

    public void pickupThird(Transform targetTransform,GrabObj_PickupBig traget)
    {
        if(traget.working) {
            state.RigOn = false;
        } else return;
        if(traget.working) {
            state.grabAnimation = 0;
        } else return;
        if(traget.working) {
            Animator.SetInteger("grabAnimation", state.grabAnimation);
        } else return;
        if(traget.working) {
            targetTransform.SetParent(Hand);
        } else return;
        if(traget.working) {
            targetTransform.position = Hand.position;
        } else return;
        if(traget.working) {
            targetTransform.eulerAngles = (Hand.eulerAngles);
        } else return;
        if(traget.working) {
            Controller.state.isGrabbing = 1;
        } else return;

        // ^ 오브젝트 이동(플레이어 손바닥 위치)

         //플레이어 상태 갱신
    }

    public void pickupThird(Transform targetTransform,GrabObj_PickHat traget)
    {
        if(traget.working) {
            state.RigOn = false;
        } else return;
        if(traget.working) {
            state.grabAnimation = 0;
        } else return;
        if(traget.working) {
            Animator.SetInteger("grabAnimation", state.grabAnimation);
        } else return;
        if(traget.working) {
            targetTransform.SetParent(Hand);
        } else return;
        if(traget.working) {
            targetTransform.position = Hand.position;
        } else return;
        if(traget.working) {
            targetTransform.eulerAngles = (Hand.eulerAngles);
        } else return;
        if(traget.working) {
            Controller.state.isGrabbing = 1;
        } else return;

        // ^ 오브젝트 이동(플레이어 손바닥 위치)

         //플레이어 상태 갱신
    }

    public void pickdown() {
        state.RigOn = false;
        state.grabAnimation = 0;
        Animator.SetInteger("grabAnimation", state.grabAnimation);
    }


    void GeometryChange()
    {
        if (state.RigOn)
        {
            Geometry.SetActive(false);
            RigGeometry.SetActive(true);
        }
        else
        {
            Geometry.SetActive(true);
            RigGeometry.SetActive(false);
        }
    }

    private void Update() {
        if(Hand.childCount>1) {
                if(Hand.GetChild(1).GetComponent<GrabObj_Pickup>()!=null) {
                    Hand.GetChild(1).GetComponent<GrabObj_Pickup>().Graboff();
                } else if(Hand.GetChild(1).GetComponent<GrabObj_PickupBig>()!=null) {
                    Hand.GetChild(1).GetComponent<GrabObj_PickupBig>().Graboff();
                } else if(Hand.GetChild(1).GetComponent<GrabObj_PickHat>()!=null) {
                    Hand.GetChild(1).GetComponent<GrabObj_PickHat>().Graboff();
                }
        }
    }
}