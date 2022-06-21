using UnityEngine;
using System;

public class GrabObj_Function : MonoBehaviour
{
    private KeyCode jumpKeyCode = KeyCode.Space;

    private GameObject player;
    private PlayerController pController;

    private bool isGrabbed = false;
    private bool funcCondition = false;

    private void Awake() {
        player = GameObject.Find("man_casual");
        pController = GameObject.Find("man_casual").GetComponent<PlayerController>();
    }

    private void Update() {

        funcCondition=false;

        if(Input.GetKeyDown(jumpKeyCode)) {
            funcCondition=true;
        }

        if ((Vector3.Distance(player.transform.position, transform.position) < 2) && (Math.Abs(player.transform.position.y- transform.position.y)<1)) {
            if (Input.GetMouseButtonDown(0)) {
                float y = player.transform.position.y+0.9f;
                transform.position=new Vector3(transform.position.x,y,transform.position.z);
                transform.SetParent(player.transform);
                pController.isGrabbing = 1;
            }

            if(isGrabbed && funcCondition) {
                func();
            }

            if (Input.GetMouseButtonUp(0)) {
                transform.SetParent(player.transform.parent.parent);
                pController.isGrabbing = 0;
            }
        }
    }

    private void func() {
        Debug.Log("Function Executed");
    }

    //잡았을 때 동작하는 물체 스크립팅용 템플릿 스크립트입니다
}
