using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager :MonoBehaviour {

    private UIManager ui;

    private int score = 0;
    private int stamina = 100;
    private bool isGameOver = false;

	// Use this for initialization
	void Start () {
        ui = FindObjectOfType<UIManager>();
        if (!ui)
        {
            Debug.Log("Failed to load UI Manager in GameManager");
        }
        StartCoroutine(GetTired(0.1f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int increment)
    {
        score += increment;
        ui.UpdateScore(score);
    }

    public void AddStamina(int increment)
    {
        stamina += increment;
        ui.SetStaminaSlider(stamina);
        if (stamina <= 0)
        {
            GameOver();
        }
    }

    IEnumerator GetTired(float interval)
    {
        while (!isGameOver)
        {
            AddStamina(-1);
            yield return new WaitForSeconds(interval);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        ui.ShowGameOver();

    }

    public void Restart()
    {
        score = 0;
        ui.UpdateScore(score);
        SceneManager.LoadScene("level");
    }
}
