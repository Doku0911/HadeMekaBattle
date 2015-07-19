using UnityEngine;
using System.Collections;

public class LockOnSystem : MonoBehaviour {


    [SerializeField]
    Transform target = null;

    [SerializeField, Tooltip("１フレームあたりに回転する最大角度")]
    float rotateEulerMaxY = 20.0f;

    float addEuler = 90;

    float eulerAngleY = 0.0f;

	// Update is called once per frame
	void Update () 
    {
        if (target == null) return;

        eulerAngleY = transform.eulerAngles.y;

        Vartical();

        Horizontal();
        
	}

    /// <summary>
    /// 見上げられる最大値
    /// </summary>
    [SerializeField,Tooltip("見上げられる角度の最大")]
    float upperEulerMax = 9.0f;



    void Vartical()
    {
        /// 自分より下にいる敵は狙わない
        if (target.position.y < transform.position.y) return;


    }

    void Horizontal()
    {
        var addEulerAngle = Mathf.Atan2(target.position.x - transform.position.x, target.position.z - transform.position.z) * 180 / Mathf.PI;

        var deltaAngle = Mathf.DeltaAngle(eulerAngleY, addEulerAngle - addEuler);


        if (Mathf.Abs(deltaAngle) > 3.0f)
        {
            if (deltaAngle >= 0)
            {
                transform.Rotate(new Vector3(0f, rotateEulerMaxY * Mathf.PI / 180, 0f));
            }
            else
            {
                transform.Rotate(new Vector3(0f, -rotateEulerMaxY * Mathf.PI / 180, 0f));
            }
        }

	

    }
}
