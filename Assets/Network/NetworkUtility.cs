using UnityEngine;
using System.Collections;

public class NetworkUtility : MonoBehaviour {

    static NetworkManagerSetup networkManager = null;

    void Start()
    {
        networkManager = GetComponent<NetworkManagerSetup>();
    }

    /// <summary>
    /// ゲームオブジェクト生成
    /// </summary>
    public static GameObject GameObjectInstantiate(GameObject obj, Vector3 position, Quaternion rotation, int group)
    {
        if (networkManager.IsNetworking)
        {
            return (GameObject)Network.Instantiate(obj,position,rotation,group);
        }
        else
        {
            return (GameObject)GameObject.Instantiate(obj, position, rotation);
        }
    }

    /// <summary>
    /// ゲームオブジェクト生成
    /// </summary>
    public static GameObject GameObjectInstantiate(GameObject obj, Vector3 position)
    {
        if (networkManager.IsNetworking)
        {
            return (GameObject)Network.Instantiate(obj, position, Quaternion.identity, 0);
        }
        else
        {
            return (GameObject)GameObject.Instantiate(obj, position, Quaternion.identity);
        }
    }

    /// <summary>
    /// ゲームオブジェクト生成
    /// </summary>
    public static GameObject GameObjectInstantiate(GameObject obj)
    {
        if (networkManager.IsNetworking)
        {
            return (GameObject)Network.Instantiate(obj, Vector3.zero, Quaternion.identity, 0);
        }
        else
        {
            return (GameObject)GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity);
        }
    }

    /// <summary>
    /// ゲームオブジェクトを削除
    /// </summary>
    /// <param name="obj"></param>
    public static void GameObjectDestroy(GameObject obj)
    {
        if (networkManager.IsNetworking)
        {
            Network.Destroy(obj);
        }
        else
        {
            GameObject.Destroy(obj);
        }
    }

}
