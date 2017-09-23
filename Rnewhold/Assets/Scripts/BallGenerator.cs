using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour {

    public GameObject ballPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	public void PitchButtonDown()
	{
		GameObject ball = Instantiate(ballPrefab) as GameObject;
		ball.GetComponent<BallController>().Throw();
	}

	public void RandomPitchButtonDown()
	{
		GameObject ball = Instantiate(ballPrefab) as GameObject;
		ball.GetComponent<BallController>().RandomThrow();
	}
}
