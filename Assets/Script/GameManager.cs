using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static float restTime = 60;
    static int score;
    
    

    // Use this for initialization
    void Start () {

        Debug.Log("start");
	}
	
	// Update is called once per frame
	void Update () {

        // 時間を引いていく

        restTime -= Time.deltaTime;

        if (restTime < 0)
        {
            restTime = 0;
        }

        

        print( restTime ); 


        // 

    }

    public void AddScore ( int addScore )
    {
        score += addScore; //ポイントを追加する
        print(score);

    }

}
