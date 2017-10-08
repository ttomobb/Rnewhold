using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text homerunScore;
    public GameObject ball;
    public GameObject cursor;
    public float homerunDistance = 100.0f;
    private int score = 0;
    private bool homerunJudge;

	// Use this for initialization
	void Start () {
        homerunScore.text = "Home Run : 0"; //初期スコア
        homerunJudge = false;

	}
	
	// Update is called once per frame
	void Update () {
        //ボールがある場合
        if ((this.ball = GameObject.Find("ball")) != null)
        {
            //ボールが地面と当たった場所からホームラン判定
            //

            //ホームラン距離よりボールとカーソルの距離差が大きい場合、ホームラン判定して、スコア加算
            if ((ball.transform.position - cursor.transform.position).magnitude > homerunDistance)
            {
                homerunJudge = true;
                score += 10;    //スコア加算
                homerunScore.text = "Score : " + score.ToString();
            }
        }
	}
}
