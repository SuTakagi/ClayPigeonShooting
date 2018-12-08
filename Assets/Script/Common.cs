using UnityEngine;
using System;

/// <summary>
/// 共通関数
/// </summary>
public class Common : MonoBehaviour {

    #region プロパティ
    // 発射台Aの初期位置
    public static Vector3 initLauncherA;

    // 発射台Bの初期位置
    public static Vector3 initLauncherB;

    // 発射台Cの初期位置
    public static Vector3 initLauncherC;

    // 発射台Dの初期位置
    public static Vector3 initLauncherD;

    // 発射台Eの初期位置
    public static Vector3 initLauncherE;

    // 発射台Fの初期位置
    public static Vector3 initLauncherF;

    // 発射台Gの初期位置
    public static Vector3 initLauncherG;

    // enum
    public enum Launcher
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G
    }
    #endregion

    #region 関数
    public static int getRnadomSwitch()
    {
        return UnityEngine.Random.Range(0, 3);
    }

    public static Launcher getNumRandom()
    {
        int numVal = UnityEngine.Random.Range(0, 7);

        return (Launcher)Enum.ToObject(typeof(Launcher), numVal);
    }
    #endregion

}
