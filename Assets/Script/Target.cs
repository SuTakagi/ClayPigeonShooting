using UnityEngine;

public class Target : MonoBehaviour
{

    // 標的のX軸速度
    [SerializeField]
    private float _MoveSpeed = 100.0f;

    private int direction;

    CharacterController controller;

    // Use this for initialization
    void Start()
    {
        // 初期値の取得
        Common.initLauncherA = new Vector3(-7.53f, 0.89f, 12.24f);
        Common.initLauncherB = new Vector3(6.06f, 0.89f, 7.35f);
        Common.initLauncherC = new Vector3(-4.19f, 0.64f, 0.07f);
        Common.initLauncherD = new Vector3(-0.64f, 0.64f, 0.07f);
        Common.initLauncherE = new Vector3(3.65f, 0.64f, 0.07f);
        Common.initLauncherF = new Vector3(-5.53f, 1.05f, -10.1f);
        Common.initLauncherG = new Vector3(4.78f, 1.05f, -10.1f);
        
        // 位置設定
        setInitPosition();

        // 速度の取得
        direction = Common.getRnadomSwitch();

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 標的の移動するXを決定する
        // 一度当てた場合は乱数
        // 標的を動かす
        switch (direction)
        {
            case 0:
                // 右方向
                this.transform.position += (transform.right * _MoveSpeed * Time.deltaTime + transform.up * _MoveSpeed * Time.deltaTime +
                                                transform.forward * _MoveSpeed * Time.deltaTime);
                break;
            case 1:
                // 正面
                this.transform.position += (transform.up * _MoveSpeed * Time.deltaTime + transform.forward * _MoveSpeed * Time.deltaTime);
                break;
            case 2:
                // 左方向
                this.transform.position -= (transform.up * _MoveSpeed * Time.deltaTime + transform.forward * _MoveSpeed * Time.deltaTime -
                                                transform.right * _MoveSpeed * Time.deltaTime);
                break;
            default:
                this.transform.position -= (transform.up * _MoveSpeed * Time.deltaTime + transform.forward * _MoveSpeed * Time.deltaTime);
                break;
        }

        // 一定の距離を通り過ぎた場合
        if (this.transform.position.z < -15.55f)
        {
            setInitPosition();

            // 標的の移動するXを決定する
            direction = Common.getRnadomSwitch();
        }
    }

    private void setInitPosition()
    {
        // 標的の初期化
        Common.Launcher numLauncher = Common.getNumRandom();
        switch (numLauncher)
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
    }
}
