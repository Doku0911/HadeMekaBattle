using UnityEngine;
using System.Collections;

public class PlayerRotater : MonoBehaviour {

    /// <summary>
    /// プレイヤーが向いている方向
    /// </summary>
    public Vector3 EyeVector { get; private set; }

    /// <summary>
    /// 見上げる最大の値  0.0f~1.0f
    /// </summary>
    [SerializeField,Range(0.0f,1.0f)]
    float MaxUpperAngle = 0.5f;

    /// <summary>
    /// 見下ろす最大の値  0.0f~1.0f
    /// </summary>
    [SerializeField, Range(-1.0f, 0.0f)]
    float MinDownerAngle = -0.5f;

    // Update is called once per frame
	void Update () {
        HorizontalRotate();
        VerticalRotate();
	}

    /// <summary>
    /// 左右の視点移動
    /// </summary>
    void HorizontalRotate ()
    {
        var xValue = Input.GetAxis("Mouse X");

        if (xValue == 0 ) return;

        transform.Rotate(Vector3.up, xValue);
        EyeVector = new Vector3( transform.forward.x, EyeVector.y, transform.forward.z);
    }

    /// <summary>
    /// 上下の視点移動
    /// </summary>
    void VerticalRotate()
    {
        var yValue = Input.GetAxis("Mouse Y");

        if (yValue == 0) return;

//        var turnQuaternion = Quaternion.Euler(new Vector3(0, 0, yValue));

        EyeVector = (Quaternion.AngleAxis(yValue, transform.right) * EyeVector).normalized;

        if (EyeVector.y > MaxUpperAngle) EyeVector = new Vector3(EyeVector.x, MaxUpperAngle, EyeVector.z);
        if (EyeVector.y < MinDownerAngle) EyeVector = new Vector3(EyeVector.x, MinDownerAngle, EyeVector.z);

    }

}
