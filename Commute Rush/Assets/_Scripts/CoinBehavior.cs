using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public int value = 1;
    private GameManager gm;

    // Use this for initialization
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (!gm)
        {
            Debug.Log("Failed to load game manager");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gm.AddScore(value);
        Destroy(this.gameObject);
    }
}
