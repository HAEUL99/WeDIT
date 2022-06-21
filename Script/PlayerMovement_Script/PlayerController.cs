using UnityEngine;
using System;
using Photon.Bolt;

public class PlayerController : Photon.Bolt.EntityBehaviour<IPlayerState>
{

    private KeyCode jumpKeyCode = KeyCode.Space;
    //private KeyCode defeat = KeyCode.Backspace;

    private CharacterController characterController;
    private Animator animator;
    private PlayerMovement3D movement3D;
    private PlayerRiding riding;
    private PlayerInteraction interaction;

    private CameraMovement cameramovement;

    private Transform cartransform;
    private CarController carcontroller;
    //private CarSync carsync;

    //private GameObject[] Anchors;

    public bool isRide = false;
    public bool isDriver = false;
    private bool updatetemp = false;
    public int isGrabbing = 0;

    private int index = 0;

    public override void Attached()
    {
        state.SetTransforms(state.PlayerTransform, transform);
        if (!entity.IsOwner) return;
        carcontroller.getPlayer(this.gameObject);
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        movement3D = GetComponent<PlayerMovement3D>();
        riding = GetComponent<PlayerRiding>();
        interaction = GetComponent<PlayerInteraction>();

        cameramovement = transform.Find("Main Camera").GetComponent<CameraMovement>();

        cartransform = GameObject.Find("car").GetComponent<Transform>();
        carcontroller = GameObject.Find("car").GetComponent<CarController>();
        //carsync = GameObject.Find("car").GetComponent<CarSync>();
    }

    private void Update()
    {
        if (!entity.IsOwner) {
            if (state.isRide ==  true) {
                cartransform.gameObject.GetComponent<CharacterController>().enabled = false;
                cartransform.position = transform.position;
                cartransform.rotation = transform.rotation;
                if(!updatetemp) updatetemp = true;
            } else {
                if(updatetemp) {
                    cartransform.gameObject.GetComponent<CharacterController>().enabled = true;
                    updatetemp = false;
                }
            }
            return;
        }
        float x = Input.GetAxisRaw("Vertical");
        float z = Input.GetAxisRaw("Horizontal") / 50;

        if (isGrabbing == 2)
        { //상자를 밀고 있을 때 좌우이동 막고 속도 내리는 부분
            z = 0;
            x = x * 0.3f;
        }

        if (isGrabbing == 3)
        { //레버 잡았을 때 이동제어 부분
            z = Input.GetAxisRaw("Mouse X") / 50;
            x = 0;
        }

        if (isRide == true)
        { //자동차 탑승시 플레이어 오브젝트 이동방지 부분
            x = 0;
            z = 0;
        }

        movement3D.Rotation(z * 180 / Mathf.PI);
        movement3D.MoveTo(new Vector3(Mathf.Sin(transform.eulerAngles.y / 180 * Mathf.PI) * x, 0, Mathf.Cos(transform.eulerAngles.y / 180 * Mathf.PI) * x));

        if (Input.GetKeyDown(jumpKeyCode) && isGrabbing != 2)
        { //점프부분
            movement3D.JumpTo();
        }

        /*if (x != 0)
        { //애니메이터 수정부분
            state.isWalking = true;
            animator.SetBool("isWalking", state.isWalking);
        }
        else
        {
            state.isWalking = false;
            animator.SetBool("isWalking", state.isWalking);
        }*/

        /*if (Input.GetKeyDown(defeat))
        { //위치초기화부분
            movement3D.PositionInitialize();
        }*/
    }

    public void Rideon()
    { //차량에 탈 때 움직임 함수
    if(!isRide) {
        cameramovement.RideonMove();
        gameObject.transform.SetParent(cartransform);
        characterController.enabled = false;
        state.isRiding = true;
        animator.SetBool("isRiding", true);
        transform.position = cartransform.position;
        transform.eulerAngles = cartransform.eulerAngles;
        /*if (entity.IsOwner) carsync.isRide2 = true;
        
        Anchors = GameObject.FindGameObjectsWithTag("Anchor");
        foreach (GameObject Obj in Anchors)
        {
            if(Obj.GetComponent<BoltEntity>().IsOwner) {
                Obj.GetComponent<PlayerAnchor>().enabled = true;
            }
        }*/

        isRide = true;
        state.isRide = true;
        isDriver = true;
        carcontroller.setavailable(1);
        Debug.Log("RIDE ON");
    }
    }

    public void Rideoff()
    { //차량에서 내릴 때 움직임 함수
    if(isRide) {
        transform.SetParent(null);
        transform.position = (cartransform.position + new Vector3(-0.6f * Mathf.Cos((cartransform.eulerAngles.y + 90) / 180 * Mathf.PI), 1.5f, 0.6f * Mathf.Sin((cartransform.eulerAngles.y + 90) / 180 * Mathf.PI)));
        //transform.eulerAngles = cartransform.eulerAngles;
        /*if (entity.IsOwner) carsync.isRide2 = false;
        
        Anchors = GameObject.FindGameObjectsWithTag("Anchor");
        foreach (GameObject Obj in Anchors)
        {
            if(Obj.GetComponent<BoltEntity>().IsOwner) {
                Obj.GetComponent<PlayerAnchor>().enabled = false;
            }
        }*/
        characterController.enabled = true;
        state.isRiding = false;
        animator.SetBool("isRiding", false);
        cameramovement.RideoffMove();
        carcontroller.setavailable(0);
        isRide = false;
        state.isRide = false;
        isDriver = false;
        Debug.Log("RIDE OFF");
    }
    }

    public void carried() {
        if(!isRide) {
            for(int i=0;i<5;i++) {
                if(carcontroller.seat[i]==false) {
                    index=i-2;
                    break;
                }
            }
            carcontroller.seat[index+2] = true;

            cameramovement.CarryMove((cartransform.position + new Vector3(
                5.0f * Mathf.Cos((cartransform.eulerAngles.y + 90) / 180 * Mathf.PI)+0.6f * index * Mathf.Sin((cartransform.eulerAngles.y + 90) / 180 * Mathf.PI)
                , 0, 
                5.0f * Mathf.Sin((cartransform.eulerAngles.y + 90) / 180 * Mathf.PI)+0.6f * index * Mathf.Cos((cartransform.eulerAngles.y + 90) / 180 * Mathf.PI))),
            cartransform.eulerAngles,transform.position,transform.eulerAngles,cartransform);
            
            gameObject.transform.SetParent(cartransform);
            characterController.enabled = false;
            state.isRiding = true;
            animator.SetBool("isRiding", true);
            transform.position = (cartransform.position + new Vector3(
                5.0f * Mathf.Cos((cartransform.eulerAngles.y + 90) / 180 * Mathf.PI)+0.6f * index * Mathf.Sin((cartransform.eulerAngles.y + 90) / 180 * Mathf.PI)
                , 0, 
                5.0f * Mathf.Sin((cartransform.eulerAngles.y + 90) / 180 * Mathf.PI)+0.6f * index * Mathf.Cos((cartransform.eulerAngles.y + 90) / 180 * Mathf.PI)));
            transform.eulerAngles = cartransform.eulerAngles;
            
            isRide = true;
            Debug.Log("FULL FUNC");
        }
    }

    public void carryoff() {
        if(isRide) {
            carcontroller.seat[index+2] = false;
            index=0;
            cameramovement.CarryMove(transform.position,transform.eulerAngles,transform.position,transform.eulerAngles,transform);
            transform.SetParent(null);
            characterController.enabled = true;
            state.isRiding = false;
            animator.SetBool("isRiding", false);
            isRide = false;
            Debug.Log("CARRY NO");
        }
    }
}