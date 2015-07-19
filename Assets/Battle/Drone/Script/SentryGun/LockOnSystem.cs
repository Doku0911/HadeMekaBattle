using UnityEngine;
using System.Collections;

public class LockOnSystem : MonoBehaviour {


    [SerializeField]
    Transform target = null;

    [SerializeField, Tooltip("１フレームあたりに回転する最大角度")]
    float rotateEulerMaxY = 20.0f;

    /// <summary>
    /// 調節用の変数
    /// 銃が正面を向いていないので90度傾けて考えます。
    /// </summary>
    float addEuler = 90;

	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SetTargetWithTag("Player");
        }

        if (target == null) return;


        Vartical();

        Horizontal();
        
	}

    /// <summary>
    /// 見上げられる最大値
    /// </summary>
    [SerializeField,Tooltip("見上げられる角度の最大")]
    float upperEulerMax = 9.0f;


    /// <summary>
    /// 垂直方向のエイム
    /// </summary>
    void Vartical()
    {
        /// 自分より下にいる敵は狙わない
        if (target.position.y < transform.position.y) return;

        var horizontalDistance = Mathf.Sqrt((target.position.x - transform.position.x) * (target.position.x - transform.position.x) + (target.position.z - transform.position.z) * (target.position.z - transform.position.z));

        var addEulerAngleZ = Mathf.Atan2(horizontalDistance, target.position.y - transform.position.y) * 180 / Mathf.PI;

        /// addEulerAngleZをマイナスにし、さらに90度傾ける
        /// ↓の短縮
        /// addEulerAngleZ *= -1;
        /// addEulerAngleZ += addEuler;
        addEulerAngleZ = addEuler - addEulerAngleZ;
        
        if (addEulerAngleZ > upperEulerMax)
        {
            addEulerAngleZ = upperEulerMax;
        }

        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, addEulerAngleZ);

    }

    /// <summary>
    /// 水平方向のエイム
    /// </summary>
    void Horizontal()
    {
        var addEulerAngle = Mathf.Atan2(target.position.x - transform.position.x, target.position.z - transform.position.z) * 180 / Mathf.PI;

        var deltaAngle = Mathf.DeltaAngle(transform.eulerAngles.y, addEulerAngle - addEuler);

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

    /// <summary>
    /// ターゲットを設定する。
    /// </summary>
    /// <param name="_target">ターゲットのTransform</param>
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    
    /// <summary>
    /// ターゲットを設定する。
    /// </summary>
    /// <param name="_tag">ターゲットのタグ</param>
    public void SetTargetWithTag(string _tag)
    {
        target = GameObject.FindGameObjectWithTag(_tag).GetComponent<Transform>();
    }



}
