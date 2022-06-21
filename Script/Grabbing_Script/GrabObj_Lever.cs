using UnityEngine;
using System;

public class GrabObj_Lever : MonoBehaviour
{
    public GameObject targetObj;

    private bool isGrabbed;
    private bool funcCondition = false;

    private void Awake() {
        targetObj = transform.gameObject;
    }

    public void getObj(GameObject obj) {
        targetObj = obj;
    }

    private void Update() {
        if (Vector3.Distance(targetObj.transform.position, transform.position) < 1f) { //플레이어가 가까이 있을 때
            if (Input.GetMouseButtonDown(0)) { //마우스 왼쪽 버튼을 입력받는다
                if (!isGrabbed) {
                    funcCondition=true;
                    targetObj.GetComponent<PlayerController>().isGrabbing = 3;
                    targetObj.GetComponent<Animator>().SetBool("isLever",true);
                }
            }

            if(funcCondition) {
                transform.Rotate(new Vector3(Input.GetAxis("Mouse X")*3,0,0));
            }

            if (Input.GetMouseButtonUp(0)) { //마우스 왼쪽 버튼 떼면
                funcCondition=false;
                targetObj.GetComponent<PlayerController>().isGrabbing = 0;
                targetObj.GetComponent<Animator>().SetBool("isLever",false); //레버 잡는 애니메이션 해제
            }
        }
    }
}
