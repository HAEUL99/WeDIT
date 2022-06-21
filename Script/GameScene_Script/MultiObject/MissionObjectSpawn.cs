using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class MissionObjectSpawn : Photon.Bolt.GlobalEventListener
{
	[SerializeField] GameObject spawnPrefab;
	Vector3 spawnPos;
	BoltEntity entity;
	/*
	public override void SceneLoadLocalDone(string scene, IProtocolToken token)
	{
		if (BoltNetwork.IsServer)
		{
			BoltEntity entity = BoltNetwork.Instantiate(spawnPrefab);
			// 생성도 서버가 하고 서버가 조종하도록 컨트롤을 달아줌
			entity.TakeControl();
		}
	}
	*/
	/*
	public void Awake()
	{
		spawnPos = GameObject.Find("Spawnlever").transform.position;
		spawn();
	}

	*/
	//

	public override void SceneLoadLocalDone(string scene, IProtocolToken token)
	{
		/*
		if (BoltNetwork.IsServer)
		{
			Vector3 spawnPos = GameObject.Find("Spawnlever").transform.position;
			entity = BoltNetwork.Instantiate(spawnPrefab, spawnPos, Quaternion.Euler(0, 0, 0));
		}
		*/
	}


	public override void SceneLoadRemoteDone(BoltConnection connection, IProtocolToken token)
    {
		/*
		if (BoltNetwork.IsServer)
		{
			
			// 생성은 서버가 했지만 연결된 클라이언트가 제어하도록 컨트롤을 달아줌, 서버에서 연산에 유리
			// 클라이언트 1, 서버 1여야한다 클라이언트 두명이면, connection충돌
			entity.AssignControl(connection);
		}
		*/
		
    }

    // 리모트 씬이 불러와짐
	/*
    private void spawn()
	{
		//BoltEntity entity = BoltNetwork.Instantiate(spawnPrefab, spawnPos, Quaternion.Euler(0, 0, 0));
		if (BoltNetwork.IsServer)
		{
			//Vector3 spawnPos = GameObject.Find("Spawnlever").transform.position;
			entity = BoltNetwork.Instantiate(spawnPrefab, spawnPos, Quaternion.Euler(0, 0, 0));
			// 생성은 서버가 했지만 연결된 클라이언트가 제어하도록 컨트롤을 달아줌, 서버에서 연산에 유리
			//entity.TakeControl();
			/*
			entity.AssignControl(connection);

			// 엔티티 판단
			bool hasControl = entity.HasControl;
			bool isOwner = entity.IsOwner;
			bool isControllerOrOwner = entity.IsControllerOrOwner;
			NetworkId networkId = entity.NetworkId;
			print(networkId.PackedValue);
			
		}
	}*/


}
