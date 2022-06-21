using UnityEngine;
using System.Collections;

public class CarMovement3D : MonoBehaviour
{
    private float moveSpeed = 10f;
    //private float moveSpeedy = 5f;
    private float gravity = -4.9f;
    private float RotationTemp = 0f;
    //public bool notCollision = true;

    private Vector3 moveDirection;
    private Vector3 moveDirectionxz;
    private Vector3 moveDirectiony;

    private CharacterController characterController;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        //characterController.enabled = false;
    }

    private void Update() {
        if (IsCheckGrounded() == false) { //중력파트
            moveDirection.y = gravity;
        } else {
            moveDirection.y = 0;
        }
        //moveDirectionxz.x = moveDirection.x;
        //moveDirectionxz.z = moveDirection.z;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        //characterController.Move(moveDirectiony * moveSpeedy * Time.deltaTime);
        //transform.position += (moveDirectionxz * moveSpeed * Time.deltaTime);
        //transform.position += (moveDirectiony * moveSpeedy * Time.deltaTime);
        //Debug.Log(moveDirection);
    }

    public void MoveTo(Vector3 direction) { //CarController에서 이동 컨트롤이 입력되었을 경우 방향을 스크립트 내 3D벡터로 변환해주는 함수
        moveDirection = new Vector3(direction.x,moveDirection.y,direction.z);
    }

    public void Rotation(float z) { //차량 회전 파트
        transform.Rotate (new Vector3(-transform.eulerAngles.x, z, -transform.eulerAngles.z));
    }

    /*public void Acceleration(float accel1, float accel2) { //속도변환 함수(마우스 클릭시 가속)
        moveSpeed += (float)(((accel1*accel2)-0.5)*0.05);
        if (moveSpeed < 0) moveSpeed = 0;
        if (moveSpeed > 10) moveSpeed = 10;
    }*/
/*
    //충돌움직임 제어 함수
    public void OnTriggerEnter() { 
        notCollision=false;
    }
    public void OnTriggerStay() {
        if (RotationTemp==0) characterController.Move(moveDirectionxz * -moveSpeed * Time.deltaTime);
        else transform.Rotate (new Vector3(0, -5*RotationTemp, 0));
        notCollision=false;
    }
    public void OnTriggerExit() {
        notCollision=true;
    }*/
    
    /*public void PositionInitialize() { //자동차 위치초기화 움직임 함수
        characterController.enabled = false;
        transform.position=new Vector3(-6f,0,19f);
        transform.eulerAngles=new Vector3(0,-90f,0);
        characterController.enabled = true;
    }*/

    private bool IsCheckGrounded() { //RayCast 이용 착지여부 판단
        if (characterController.isGrounded) return true;
        var ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        var maxDistance = 0.1f;
        Debug.DrawRay(transform.position + Vector3.up * 0.1f, Vector3.down * maxDistance, Color.red);
        return Physics.Raycast(ray, maxDistance);
    }
}