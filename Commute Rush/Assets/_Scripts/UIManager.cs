using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreLabel;
    public Slider staminaSlider;
    public Text gameOverLabel;
    public Button retryButton;

    private string scoreText = "Score : ";

	// Use this for initialization
	void Start () {
        scoreLabel.text = scoreText + 0;
        staminaSlider.value = 1;
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

    public void SetStaminaSlider(int stamina)
    {
        float sliderPercent = (float)stamina / 100;
        staminaSlider.value = sliderPercent;
    }

    public void ShowGameOver()
    {
        gameOverLabel.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }

    
}
