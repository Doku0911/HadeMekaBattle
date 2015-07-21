using UnityEngine;
using System.Collections;

public class CameraRotater : MonoBehaviour {

    [SerializeField]
    Transform targetTransform = null;

    PlayerRotater playerRotater = null;

	// Use this for initialization
	void Start () {
        playerRotater = targetTransform.GetComponent<PlayerRotater>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.forward = (targetTransform.forward + playerRotater.EyeVector);

	}
}
