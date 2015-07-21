using UnityEngine;
using System.Collections;

public class SentryGunShooter : MonoBehaviour {

    BulletShooter bulletshooter = null;

    LockOnSystem lockonSystem = null;

    void Start()
    {
        bulletshooter = GetComponent<BulletShooter>();

        /// 弾を消費しないように設定する
        bulletshooter.HasLimit = false;
        lockonSystem = GetComponent<LockOnSystem>();
    }

    void Update()
    {
        Shot();
    }

    void Shot()
    {
        if (!lockonSystem.IsInside()) return;

        var bullets = bulletshooter.CreateBullet();

        foreach(var bullet in bullets)
        {
            bullet.transform.forward = transform.right;
        }        
    }

}
