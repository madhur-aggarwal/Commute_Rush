using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private GameManager gm;

    public float jumpForce = 300;
    public int maxJump = 2;

    private int currentJump = 0;

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
		if (Input.GetKey(KeyCode.Space))
        {
            if (currentJump <= maxJump)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                currentJump++;
            }
            
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            currentJump = 0;
        }
        else if (collision.gameObject.tag == "DeathZone")
        {
            gm.GameOver();
        }
             
    }

}
