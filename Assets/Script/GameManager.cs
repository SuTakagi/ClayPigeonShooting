using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static float restTime = 60;
    static int score;
    static bool startFlg = false;

    public GameObject textStart;
    public GameObject textFinish;
    public GameObject textScore;
    public GameObject textTime;

    // Use this for initialization
    void Start () {

        print(textStart.GetComponent<TextMesh>().text);

        //Debug.Log("start");
	}
	
	// Update is called once per frame
	void Update () {

        // 時間を引いていく

        if ( startFlg ) {
            restTime -= Time.deltaTime;
        }

        if (restTime < 0  )
        {
            restTime = 0;
            textFinish.GetComponent<TextMesh>().text = "Finish!!";

        }

        textTime.GetComponent<TextMesh>().text = restTime.ToString();
        //textTime.GetComponent<TextMesh>().text = "hoge";

        print(textTime.GetComponent<TextMesh>().text);

        //print( restTime ); 
        textScore.GetComponent<TextMesh>().text = score.ToString();

        // 

        if ( OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Space))
        {
            if (startFlg )
            {
                startFlg = false;
            } else
            {
                startFlg = true;
                score = 0;
                restTime = 60;
            }
            
        }

    }

    public  void AddScore ( int addScore )
    {
        if (restTime > 0 && startFlg)
        {
            score += addScore; //ポイントを追加する
        }

    }

}
