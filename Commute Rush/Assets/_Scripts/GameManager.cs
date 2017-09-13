﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager :MonoBehaviour {

    private UIManager ui;

    private int score = 0;

	// Use this for initialization
	void Start () {
        ui = FindObjectOfType<UIManager>();
        if (!ui)
        {
            Debug.Log("Failed to load UI Manager");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int increment)
    {
        score += increment;
        ui.UpdateScore(score);
    }

    public void GameOver()
    {
        ui.ShowGameOver();

    }

    public void Restart()
    {
        score = 0;
        ui.UpdateScore(score);
        SceneManager.LoadScene("level");
    }
}
