using UnityEngine;

public class LaserPointer : MonoBehaviour {
    [SerializeField]
    private Transform _RightHandAnchor;

    [SerializeField]
    private Transform _LeftHandAnchor;

    [SerializeField]
    private Transform _CenterEyeAnchor;

    [SerializeField]
    private float _MaxDistance = 100.0f;

    [SerializeField]
    private LineRenderer _LaserPointerRenderer;

    // 標的のID
    private const string targetID = "Cube";

    // X軸の移動向き
    public static float changedX;

    // 標的
    public GameObject target;

    // 標的の初期位置
    private Vector3 initPosition;

    // 当たり判定
    private bool isResPon = false;

    private Transform Pointer
    {
        get
        {
            // 現在アクティブなコントローラーを取得
            var controller = OVRInput.GetActiveController();
            if (controller == OVRInput.Controller.RTrackedRemote)
            {
                return _RightHandAnchor;
            }
            else if (controller == OVRInput.Controller.LTrackedRemote)
            {
                return _LeftHandAnchor;
            }
            // どちらも取れなければ目の間からビームが出る
            return _CenterEyeAnchor;
        }
    }

    private void Start()
    {
        // 標的の取得
        target = GameObject.Find(targetID);
        // 標的の位置の取得
        initPosition = target.transform.position;
        // X軸移動の向きを初期化
        changedX = 0.0f;
    }

    void Update()
    {
        //　当たった場合は標的を初期位置に戻す
        if(isResPon)
        {
            // 当たり判定を初期化
            isResPon = false;
            // 再表示
            target.SetActive(true);
            // 初期位置に戻す
            target.transform.position = initPosition;
        }

        var pointer = Pointer;
        if (pointer == null || _LaserPointerRenderer == null)
        {
            return;
        }
        // コントローラー位置からRayを飛ばす
        Ray pointerRay = new Ray(pointer.position, pointer.forward);

        // レーザーの起点
        _LaserPointerRenderer.SetPosition(0, pointerRay.origin);

        RaycastHit hitInfo;
        if (Physics.Raycast(pointerRay, out hitInfo, _MaxDistance))
        {
            // Rayがヒットしたら爆発
            target.SetActive(false);
            // 当たった判定
            isResPon = true;
            // 標的の向きを変える
            changedX = Common.getRandom();
        }
        else
        {
            // Rayがヒットしなかったら向いている方向にMaxDistance伸ばす
            _LaserPointerRenderer.SetPosition(1, pointerRay.origin + pointerRay.direction * _MaxDistance);
        }
    }
}