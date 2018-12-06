using UnityEngine;

public class Target : MonoBehaviour
{

    // 標的のX軸速度
    [SerializeField]
    private float _MoveSpeed_X = 10.0f;

    // 標的のY軸速度
    //[SerializeField]
    //private float _MoveSpeed_Y = 0.0f;

    // 標的のZ軸速度
    [SerializeField]
    private float _MoveSpeed_Z = 10.0f;

    // Use this for initialization
    void Start()
    {
        // 初期値の取得
        Common.initLauncherA = this.transform.position;
        Common.initLauncherB = new Vector3(2.0f, 0.0f, 10.0f);
        Common.initLauncherC = new Vector3(-2.0f, 0.0f, 10.0f);
        Common.initLauncherD = new Vector3(3.5f, 0.0f, 15.0f);
        Common.initLauncherE = new Vector3(-3.5f, 0.0f, 15.0f);
        Common.initLauncherF = new Vector3(4.0f, 2.0f, 10.0f);
        Common.initLauncherG = new Vector3(-4.0f, 2.0f, 10.0f);

        // 速度の取得
        _MoveSpeed_X = Common.getRandom();
    }

    // Update is called once per frame
    void Update()
    {
        // 標的の移動するXを決定する
        // 一度当てた場合は乱数
        _MoveSpeed_X = LaserPointer.changedX != 0.0f ? LaserPointer.changedX : _MoveSpeed_X;
        // 標的を動かす
        this.transform.position += new Vector3(_MoveSpeed_X * Time.deltaTime, 0, _MoveSpeed_Z * Time.deltaTime);

        // 一定の距離を通り過ぎた場合
        if (50 < this.transform.position.z)
        {
            // 標的の初期化
            Common.Launcher numLauncher = Common.getNumRandom();
            switch(numLauncher)
            {
                case Common.Launcher.A:
                    this.transform.position = Common.initLauncherA;
                    break;
                case Common.Launcher.B:
                    this.transform.position = Common.initLauncherB;
                    break;
                case Common.Launcher.C:
                    this.transform.position = Common.initLauncherC;
                    break;
                case Common.Launcher.D:
                    this.transform.position = Common.initLauncherD;
                    break;
                case Common.Launcher.E:
                    this.transform.position = Common.initLauncherE;
                    break;
                case Common.Launcher.F:
                    this.transform.position = Common.initLauncherF;
                    break;
                case Common.Launcher.G:
                    this.transform.position = Common.initLauncherG;
                    break;
            }
            
            // 標的の移動するXを決定する
            _MoveSpeed_X = Common.getRandom();
        }
    }
}
