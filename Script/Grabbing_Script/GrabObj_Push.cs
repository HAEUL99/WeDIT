using UnityEngine;
using System;

public class GrabObj_Push : MonoBehaviour
{
    public GameObject targetObj;

    private Transform parent;

    private bool isGrabbed;

    private void Awake() {
        targetObj = transform.gameObject;
        parent = transform.parent;
    }

    public void getObj(GameObject obj) {
        targetObj = obj;
    }

    private void Update() {
        if ((Vector3.Distance(new Vector3(targetObj.transform.position.x,0,targetObj.transform.position.z),new Vector3(transform.position.x,0,transform.position.z)) < 4) && (targetObj.transform.position.y - transform.position.y)<2) { //플레이어가 가까이 있을 때
            if (Input.GetMouseButtonDown(0)) {
                if (!isGrabbed) {
                    transform.SetParent(targetObj.transform);
                    targetObj.GetComponent<PlayerController>().isGrabbing = 2;
                    targetObj.GetComponent<Animator>().SetBool("PPGrab",true);
                }
            }
        }
        
        if (Input.GetMouseButtonUp(0)) { //왼쪽버튼 뗄 때
            transform.SetParent(parent);
            targetObj.GetComponent<PlayerController>().isGrabbing = 0;;
            targetObj.GetComponent<Animator>().SetBool("PPGrab",false); //상자 미는 애니메이션 종료
        }
    }
}
