using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private float speed = 10.0f;
    public GameObject ball;

	// Use this for initialization
	void Start () {
        //初速度を持たせる
        this.GetComponent<Rigidbody>().AddForce(0, 0, -speed, ForceMode.Impulse);
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
