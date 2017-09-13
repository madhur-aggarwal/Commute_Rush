using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreLabel;
    public Text gameOverLabel;
    public Button retryButton;

    private string scoreText = "Score : ";

	// Use this for initialization
	void Start () {
        scoreLabel.text = scoreText + 0;
        gameOverLabel.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore(int score)
    {
        scoreLabel.text = scoreText + score;
    }

    public void ShowGameOver()
    {
        gameOverLabel.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }
}
