using UnityEngine;

/// <summary>
/// 共通関数
/// </summary>
public class Common : MonoBehaviour {

    public static float getRandom()
    {
        return Random.Range(-100.0f, 100.0f);

    }

}
