using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private GameManager gm;

    public float jumpForce = 300;


	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();
        if (!gm)
        {
            Debug.Log("Failed to load game manager");
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            
        }else if (Input.GetKey(KeyCode.RightArrow))
        {

        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        
             
    }

}
