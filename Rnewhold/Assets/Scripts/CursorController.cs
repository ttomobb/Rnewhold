using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public GameObject ball;
    public GameObject cursor;
    private Vector3 firstPlace;
    private Vector3 relative_distance;
    private float dist_cursor_ball;

    // Use this for initialization
    void Start()
    {
        this.cursor = GameObject.Find("cursor");
        //this.ball = GameObject.Find("ball");
        //カーソルの初期座標を代入
        firstPlace = cursor.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //ボールとカーソルの距離(z座標)を算出
        cursor.GetComponent<Collider>().isTrigger = true;
        dist_cursor_ball = ball.transform.position.z - cursor.transform.position.z;

        //なぜか座標がおかしい、ボールの位置を正しく認識できていない
        //これが解決したら、近づいた時だけisTriggerをOnにしたら良い
        Debug.Log(ball.transform.position.z);

        //タッチに合わせてカーソルを動かす
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //最初にタッチした位置からの相対距離を算出する

                //Debug.Log("スクリーン座標" + Input.mousePosition);
                Vector3 screen_point_first = Input.mousePosition;
                screen_point_first.z = 2.0f;    //適当
                //Debug.Log("ワールド座標" + Camera.main.ScreenToWorldPoint(screen_point));
                //スクリーン座標をワールド座標に変換して、最初のz座標の値を代入
                Vector3 world_point_first = Camera.main.ScreenToWorldPoint(screen_point_first);
                relative_distance = new Vector3(world_point_first.x, world_point_first.y, firstPlace.z) - firstPlace;
             }

            Vector3 screen_point = Input.mousePosition;
            screen_point.z = 2.0f;  //適当
            //スクリーン座標をワールド座標に変換して、z座標の値を代入
            Vector3 world_point = Camera.main.ScreenToWorldPoint(screen_point);
            cursor.transform.position = new Vector3(world_point.x, world_point.y, firstPlace.z) - relative_distance;
        }

        //手を離した時にカーソルを初期値に戻す, バッティングモーションの起動を行う
        if (Input.GetMouseButtonUp(0)) {
            //ボールとカーソルの距離が近い場合は手を離してもカーソルが元の位置に戻らないようにする
            //ボールが近づいた時
            Debug.Log("ボタンup");
            if (dist_cursor_ball < 13.0f)
            {
                cursor.GetComponent<Collider>().isTrigger = false;
                Debug.Log("isTrigger Off") ;
            }
            else
            {
                cursor.transform.position = firstPlace;
            }
        }


	}
}
