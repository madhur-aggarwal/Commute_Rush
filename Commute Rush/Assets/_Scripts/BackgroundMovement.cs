using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

    public float speed = 10.0f;
    public float resetX = -17.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Time.deltaTime * speed, 0, 0);
        if (transform.position.x < resetX)
        {
            transform.position = new Vector3(17, 0, 0);
        }
    }
}
