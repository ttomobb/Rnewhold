using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    //箱作り
    public GameObject ball;
    public GameObject cursor;
    public GameObject player;
    public GameObject ballPrefab;
    Animator animator;
    private Vector3 firstPlace;
    private Vector3 relative_distance;
    private float dist_cursor_ball;
    public float hitPosition = 3.0f;


    // Use this for initialization
    void Start()
    {
        //オブジェクトらの格納
        this.cursor = GameObject.Find("cursor");
        this.player = GameObject.Find("Player");
        animator = this.player.GetComponent<Animator>();
        //カーソルの初期座標を代入
        firstPlace = cursor.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
		if ((this.ballPrefab.GetComponent<BallController>().Throw()) || (this.ballPrefab.GetComponent<BallController>().RandomThrow()))
		{
            
		}


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

                //Triggerをonにする
				if (cursor.GetComponent<SphereCollider>().isTrigger != true)
				{
					cursor.GetComponent<SphereCollider>().isTrigger = true;
					Debug.Log("isTrigger On");
				}
			}

			Vector3 screen_point = Input.mousePosition;
			screen_point.z = 2.0f;  //適当
									//スクリーン座標をワールド座標に変換して、z座標の値を代入
			Vector3 world_point = Camera.main.ScreenToWorldPoint(screen_point);
			cursor.transform.position = new Vector3(world_point.x, world_point.y, firstPlace.z) - relative_distance;
		}



	//手を離した時にカーソルを初期値に戻す, バッティングモーションの起動を行う
		if (Input.GetMouseButtonUp(0))
		{
            //BattingOnアニメーションの開始
            animator.SetTrigger("BattingOn");
			//ボールを探索、NULLでないときに位置情報を得る
			if ((this.ball = GameObject.Find("ball")) != null)
			{
                /*  レイをボールからStrikeZoneに向けて飛ばしたいがうまくいかない
				Ray ray = new Ray(ball.transform.position, ball.transform.rotation * Vector3.forward);
				RaycastHit hit;

				Debug.DrawLine(ball.transform.position, ball.transform.rotation * Vector3.forward, Color.red);


				if (Physics.Raycast(ray, out hit))
				{
					//Rayが当たったオブジェクトのtagがPlayerだったら
					if (hit.collider.tag == "StrikeZone")
						Debug.Log("RayがStrikeZoneに当たった");
				}
				*/

                //ボールとカーソルの距離(z座標)を算出
				dist_cursor_ball = ball.transform.position.z - cursor.transform.position.z;
				//Debug.Log(ball.transform.position.z);

				//ボールとカーソルの距離が近い場合は手を離してもカーソルが元の位置に戻らないようにする
				//ボールが近づいた時
				//Debug.Log("ボタンup");
                if (dist_cursor_ball < hitPosition)
				{
					cursor.GetComponent<Collider>().isTrigger = false;
					Debug.Log("isTrigger Off");
                } else {
                    cursor.transform.position = firstPlace;
                }

			}
			else
			{
				//ボールとカーソルの距離が遠い場合、またはボールがnullの場合は手を離した際に、カーソルを元の位置に戻す
				cursor.transform.position = firstPlace;
				
			}
        } 

	}
}
