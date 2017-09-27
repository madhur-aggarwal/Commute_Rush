using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private GameManager gm;

    public float jumpForce = 300;
    private int pos = 0;

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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pos > -2)
            {
                transform.Translate(-0.65f, 0, 0);
                pos = pos - 1;
            }
            
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (pos < 2)
            {
                transform.Translate(0.65f, 0, 0);
                pos = pos + 1;
            }
            
        }


        //float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        //transform.Translate(Time.deltaTime * horizontalAxis * 5, 0, 0);
        //Vertical movement is just for debugging
        transform.Translate(0, Time.deltaTime * verticalAxis * 5, 0);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        string otherTag = collision.gameObject.tag;
        if (otherTag == "Enemy")
        {
            gm.AddStamina(-collision.gameObject.GetComponent<EnemyControl>().GetDamage());
            Destroy(collision.gameObject);
        }   
             
    }

}
