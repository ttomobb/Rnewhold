using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private float speed = 5.0f;
    public GameObject ball;


    public bool Throw()
    {
        //初速度を持たせる
        GetComponent<Rigidbody>().AddForce(0, 0, -speed, ForceMode.Impulse);
        //カーソルのトリガーをOnに
        return true;
    }

    public bool RandomThrow()
    {
        //ランダムに初速度を与える SetRandomPitchでVictor3型を返す
        GetComponent<Rigidbody>().AddForce(SetRandomPitch().x, SetRandomPitch().y, -speed, ForceMode.Impulse);
        //カーソルのトリガーをOnに
        return true;
    }

    public bool PitchDeadball()
    {
        //デッドボールを投げる
        GetComponent<Rigidbody>().AddForce(-1, 1, -speed, ForceMode.Impulse);
		//カーソルのトリガーをOnに
		return true;
    }

    //衝突判定をしてストライクかボールかを判断
    //カーソルに当たった時
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StrikeZone") {
            
            Debug.Log("ストライク");
        }
    }
    //ストライクゾーンに入った時
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "cursor")
        {
            //カーソルがボールに当たった時にボールの重力On
            GetComponent<Rigidbody>().useGravity = true;
            Debug.Log("当たり");
            //GetComponent<Rigidbody>().AddForce(0, 100f,0);

        } else if (other.gameObject.tag == "player")
        {
            Debug.Log("デッドボール");
        }
        else 
        {
            //Debug.Log("ボール");
        }
    }

    //ランダム
    Vector3 SetRandomPitch()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(-5.0f, 5.0f);

        //この値はビルドしながら調整する
        float levelX = 0.15f;
        float levelY = 0.15f;

        Vector3 throwDirection = new Vector3(levelX * x, levelY * y, -speed);
        return throwDirection;
    }

    void Update () {
        
    }

}
