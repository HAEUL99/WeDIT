using UnityEngine;
using Photon.Bolt;
using System.Collections.Generic;

public class CarController : Photon.Bolt.EntityBehaviour<ICarState> {
    private bool ready;
    //private KeyCode defeat = KeyCode.Backspace;

    private CarMovement3D movement3D;
    //private CarRiding riding;
    //private PlayerRiding pRiding;
    public PlayerController playercontroller;
    //private Transform playertransform;

    public int available = 0;
    public bool[] seat = {false,false,false,false,false};

    public override void Attached()
    {
        //state.SetTransforms(state.CarTransform, transform);
    }

    private void Awake() {
        movement3D = GetComponent<CarMovement3D>();
        //riding = GetComponent<CarRiding>();
    }

    public void getPlayer(GameObject objt) { //플레이어 스폰 시 오브젝트를 넘겨받아 플레이어 전역 변수에 저장
        playercontroller = objt.GetComponent<PlayerController>();
        //playertransform = objt.GetComponent<Transform>();
        //pRiding = objt.GetComponent<PlayerRiding>();
        ready = true;
    }

    private void Update() {
        if(ready) {
        if(playercontroller.isDriver) { //차량 이동 부분
            float x = Input.GetAxisRaw("Vertical");
            float z = Input.GetAxisRaw("Horizontal") / 100;

            //float accel1 = Input.GetAxisRaw("Fire1");
            //float accel2 = Input.GetAxisRaw("Fire2");
        
            movement3D.Rotation(z*180/Mathf.PI);
            //movement3D.Acceleration(accel1,accel2);
            movement3D.MoveTo(new Vector3(Mathf.Sin(transform.eulerAngles.y/180*Mathf.PI)*x,0,Mathf.Cos(transform.eulerAngles.y/180*Mathf.PI)*x));
        } else {
            movement3D.MoveTo(new Vector3(0,0,0));
        }
        }

        /*if(Input.GetKeyDown(defeat)) { //차량 위치 초기화부분
            movement3D.PositionInitialize();
        }*/
    }

    /*public void Rideoff() { //차량에서 내릴 때 움직임 함수
        playercontroller.Rideoff();
        playertransform.GetComponent<CharacterController>().enabled = true;
        setavailable(0);
        playercontroller.isRide = false;
        riding.enabled = false;
        pRiding.enabled = true;
    }*/

    public void setavailable(int i) { // 운전자가 차에 탔는지 판별하는부분
        available = i;
        state.available = i;
    }
}