using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
	public int lives = 20;
	public int money = 100;

	public Text moneyText;
	public Text lifeText;
	public void LoseLife(int l = 1) {
		lives -= 1;
		if(lives <= 0) {
			GameOver();
		}
	}
	public void GameOver() {
		Debug.Log("Game Over");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update() {
		moneyText.text = "Money : " + money;
		lifeText.text = "Lives : " + lives;
	}
}
