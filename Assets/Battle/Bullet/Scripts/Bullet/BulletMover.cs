﻿using UnityEngine;
using System.Collections;

// 弾の挙動を行うクラス
// 同じオブジェクトに "BulletParameter.cs" を適用していないと動かない
public class BulletMover : MonoBehaviour {
	BulletParameter bulletParameter = null;

	// Use this for initialization
	void Start () {
		bulletParameter = this.gameObject.GetComponent<BulletParameter>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// bulletParameter が null なら処理をしない
		if(bulletParameter == null) return;

		// 向いている方向に進む
		this.transform.position += this.transform.TransformDirection(Vector3.forward) * bulletParameter.GetSpeed * Time.deltaTime ;
	}
}
