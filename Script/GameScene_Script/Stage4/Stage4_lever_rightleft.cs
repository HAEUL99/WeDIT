using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_lever_rightleft : MonoBehaviour
{
	public Transform leverCenter;
	public Transform tractorCenter;
	public GameObject tractorCenterOb;
	public Transform tractorArmCenter;
	public GameObject tractorArmCenterOb;

	//public GameObject interactionObject;
	//private Animator interactionObjectAnim;

	private void OperateLever()
	{
		float angle_lever = leverCenter.transform.eulerAngles.x;
		//float angle_door = doorCenter.transform.eulerAngles.y;

		if (angle_lever < 180)
		{
			tractorCenterOb.transform.rotation = Quaternion.Euler(0, -angle_lever, 0);
			tractorArmCenterOb.transform.rotation = Quaternion.Euler(0, -angle_lever, 0);
		}
		else
		{
			tractorCenterOb.transform.rotation = Quaternion.Euler(0, 360 - angle_lever, 0);
			tractorArmCenterOb.transform.rotation = Quaternion.Euler(0, 360 - angle_lever, 0);
		}
		//Debug.Log($"leverMain.transform.rotation.x: {leverMain.transform.eulerAngles.x}");
		/*
		if (45 <= leverMain.transform.eulerAngles.x)
		{
			EventManager.Instance.PostNotification(EVENT_TYPE.Stage1_Lever1, this);
		}
		*/
		/*
		switch (angle)
		{
			case angle 
		} 
		*/
		//Debug.Log($"angle: {angle}");
	}


	public void Update()
	{
		OperateLever();
	}


	/*
	public void OperateLever()
	{
		//Debug.Log($"leverMain.transform.rotation.x: {leverMain.transform.eulerAngles.x}");
		if (45 <= leverMain.transform.eulerAngles.x)
		{
			EventManager.Instance.PostNotification(EVENT_TYPE.Stage1_Lever1, this);
		}
		
	}

    private void Start()
    {
		//interactionObjectAnim = interactionObject.GetComponent<Animator>();
		
		EventManager.Instance.AddListener(EVENT_TYPE.Stage1_Lever1, OnEvent);

    }

    private void Update()
    {
		OperateLever();
    }

    public void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null)
	{
		//Detect event type
		switch (Event_Type)
		{
			case EVENT_TYPE.Stage1_Lever1:
				Notification();
				break;
		}
	}

	//-------------------------------------------------------
	//Function called when health changes
	void Notification()
	{
		Debug.Log("레버 이벤트 발생");
		//interactionObjectAnim.SetBool("doorPara", true);

	}
	*/
}
