using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private float speed = 10.0f;
    public GameObject ball;
	

	public void Throw () {
		//初速度を持たせる
		GetComponent<Rigidbody>().AddForce(0, 0, -speed, ForceMode.Impulse);
    }

    public void RandomThrow () {
        
		//ランダムに初速度を与える
	    private int randomX = Random.Range(-3, 3);
	    private int randomY = Random.Range(-3, 3);
	    //public float levelX = 1.0f;
	    //public float levelY = 1.0f;

        GetComponent<Rigidbody>().AddForce(randomX, randomY, -speed, ForceMode.Impulse);
    }

	// Use this for initialization
	public void Start () {
		//Throw();

	}
	
	// Update is called once per frame
	void Update () {
        
	}


    //衝突判定をしてストライクかボールかを判断
    public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "StrikeZone") {
            Debug.Log("ストライク");
        } else {
            Debug.Log("ボール");
        }
    }
}
