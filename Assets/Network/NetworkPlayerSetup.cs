﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayerSetup : MonoBehaviour {

    GameObject sceneCamera = null;
    NetworkView myNetworkView = null;
    GameObject enemyManager = null;

    // Use this for initialization
	void Start () {
        myNetworkView = GetComponent<NetworkView>();
        sceneCamera =  GameObject.Find("Scene Camera");
        enemyManager = GameObject.Find("EnemyManager");

        OpponentDestroy();

        if(sceneCamera != null)
            sceneCamera.SetActive(false);

        if (myNetworkView.isMine)
        {
            transform.FindChild("Main Camera").parent = null;
        }
	}

    /// <summary>
    /// 対戦相手でいらないComponentやGameObjectを削除する。
    /// </summary>
    void OpponentDestroy()
    {
        if (!myNetworkView.isMine)
        {
            Destroy(GetComponent<PlayerMover>());
            Destroy(GetComponent<PlayerJumper>());
          //  Destroy(GetComponent<PlayerShooter>());
            Destroy(transform.FindChild("Main Camera").gameObject);
            Destroy(GetComponent<PlayerRespawner>());
            
            enemyManager.GetComponent<EnemyListManager>().Add(gameObject);
        }
    }

    // Update is called once per frame
	void Update () {
	
	}
}
