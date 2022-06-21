using UnityEngine;
using System;
using Photon.Bolt;

public class PlayerRiding : Photon.Bolt.GlobalEventListener {

    private KeyCode ridekey = KeyCode.F;

    public BoltEntity targetObj;
    private CarController carcontroller;
    private PlayerController controller;
    private Transform cartransform;

    public bool isRide = false;

    private void Awake() {
        controller = GetComponent<PlayerController>();
        cartransform = GameObject.Find("car").transform;
        carcontroller = cartransform.GetComponent<CarController>();
        targetObj = controller.entity;
    }

    /*public void getPlayer(BoltEntity obj)
    {
        targetObj = obj;
    }*/

    private void Update() {
        if(!transform.GetComponent<PlayerController>().entity.IsOwner) return;
        if(Input.GetKeyDown(ridekey)) {
            if(!isRide) {
                if(Math.Pow((transform.position.x-cartransform.position.x),2)+ Math.Pow((transform.position.z-cartransform.position.z),2) < 4.0f) {
                    if(carcontroller.available==0) {
                        var rideevent = RideEvent.Create();
                        rideevent.Player = targetObj;
                        rideevent.isRide = false;
                        rideevent.isDriver = true;
                        rideevent.Send();
                        isRide=true;
                    } else {
                        var rideevent = RideEvent.Create();
                        rideevent.Player = targetObj;
                        rideevent.isRide = false;
                        rideevent.isDriver = false;
                        rideevent.Send();
                        isRide=true;
                    }
                } else Debug.Log("Too far");
            } else {
                if(controller.isDriver==true) {
                    var rideevent = RideEvent.Create();
                    rideevent.Player = targetObj;
                    rideevent.isRide = true;
                    rideevent.isDriver = true;
                    rideevent.Send();
                    isRide=false;
                } else {
                    var rideevent = RideEvent.Create();
                    rideevent.Player = targetObj;
                    rideevent.isRide = true;
                    rideevent.isDriver = false;
                    rideevent.Send();
                    isRide=false;
                }
            }
        }
    }

    public override void OnEvent(RideEvent evnt)
    {
        if(evnt.isDriver == true) {
            if(evnt.isRide == false) {
                evnt.Player.GetComponent<PlayerController>().Rideon();
            }
            if(evnt.isRide == true) {
                evnt.Player.GetComponent<PlayerController>().Rideoff();
            }
        }
        if(evnt.isDriver == false) {
            if(evnt.isRide == false) {
                evnt.Player.GetComponent<PlayerController>().carried();
            }
            if(evnt.isRide == true) {
                evnt.Player.GetComponent<PlayerController>().carryoff();
            }
        }
    }
}