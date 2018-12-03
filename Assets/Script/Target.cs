using UnityEngine;

public class Target : MonoBehaviour {

    // 標的のX軸速度
    [SerializeField]
    private float _MoveSpeed_X = 0.0f;

    // 標的のY軸速度
    //[SerializeField]
    //private float _MoveSpeed_Y = 0.0f;

    // 標的のZ軸速度
    [SerializeField]
    private float _MoveSpeed_Z = 10.0f;

    // 標的の初期位置
    private Vector3 initPosition;

    // Use this for initialization
    void Start () {
        // 初期値の取得
        initPosition = this.transform.position;
        _MoveSpeed_X = Common.getRandom();
	}
	
	// Update is called once per frame
	void Update () {
        // 標的の移動するXを決定する
        // 一度当てた場合は乱数
        _MoveSpeed_X = LaserPointer.changedX != 0.0f ? LaserPointer.changedX : _MoveSpeed_X;
        // 標的を動かす
        this.transform.position += new Vector3(_MoveSpeed_X * Time.deltaTime, 0, _MoveSpeed_Z * Time.deltaTime);

        // 一定の距離を通り過ぎた場合
        if (50 < this.transform.position.z)
        {
            // 標的の初期化
            this.transform.position = initPosition;
            // 標的の移動するXを決定する
            _MoveSpeed_X = Common.getRandom();
        }
	}
}
