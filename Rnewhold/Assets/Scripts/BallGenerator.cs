using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour {

    public GameObject ballPrefab;
    private GameObject ball;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	public void PitchButtonDown()
	{
        ball = Instantiate(ballPrefab) as GameObject;
		ball.GetComponent<BallController>().Throw();
        ball.name = "ball";
	}

	public void RandomPitchButtonDown()
	{
		ball = Instantiate(ballPrefab) as GameObject;
		ball.GetComponent<BallController>().RandomThrow();
        ball.name = "ball";
	}
	

}
