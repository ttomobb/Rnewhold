using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {
    public float deleteTime = 3.0f;
    float delta; 

	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        if ((transform.position.z < 0.0) || (this.delta > this.deleteTime))
		{
			Destroy(gameObject);
		}
	}
}
