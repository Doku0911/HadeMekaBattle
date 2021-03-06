﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyListManager : MonoBehaviour {

    /// <summary>
    /// 敵一覧を格納するリスト
    /// </summary>
    List<GameObject> enemyList = new List<GameObject>();

    /// <summary>
    /// 敵一覧リストに追加する
    /// </summary>
    /// <param name="_newObject">追加する敵</param>
    public void Add(GameObject _newObject)
    {
        enemyList.Add(_newObject);
    }

    /// <summary>
    /// 指定したオブジェクトを削除する
    /// </summary>
    /// <param name="_gameObject">削除するゲームオブジェクト</param>
    void ClearList()
    {
        enemyList.Clear();
    }

    public void RefreshList()
    {
        ClearList();

        var playerList = GameObject.FindGameObjectsWithTag("Player");

        foreach(var player in playerList)
        {
            if(!player.GetComponent<NetworkView>().isMine)
            {
                Add(player);
            }
        }
    }

    /// <summary>
    /// 敵一覧から１つだけ敵を得る
    /// </summary>
    /// <param name="_id">リストの番号</param>
    /// <returns>与えられた番号にある敵のGameObject</returns>
    public GameObject GetEnemy(int _id)
    {
        if(_id < 0 || _id >= enemyList.Count)
        {
            Debug.Log("_id is Out of EnemyList's Length!");
            return null;
        }

        return enemyList[_id];
    }

    /// <summary>
    /// 敵一覧のリストを得る
    /// </summary>
    /// <returns>敵一覧のList(GameObject)</returns>
    public List<GameObject> GetEnemyList()
    {
        return enemyList;
    }


}
