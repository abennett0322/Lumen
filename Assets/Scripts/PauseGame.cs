using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public Canvas pauseMenu;
	public Canvas gameHUD;
	bool paused = false;
	bool restart = false;

	public Button continueButton;
	public Button restartButton;

	void Start () {
		gameHUD.enabled = true;
		pauseMenu.enabled = false;
		Time.timeScale = 1;

		continueButton.onClick.AddListener (Resume);
		restartButton.onClick.AddListener (Restart);
	}

	void Update () {
		
		// Press "r" to pause the game
		if(Input.GetButtonDown("Pause")) {
			Pause ();
		}
	}

	void Pause() {
		paused = !paused;

		if (paused){
			gameHUD.enabled = false;
			pauseMenu.enabled = true;
			Time.timeScale = 0;

		} else {
			gameHUD.enabled = true;
			pauseMenu.enabled = false;
			Time.timeScale = 1;
		}
	}

	void Resume() {
		paused = false;
		Debug.Log ("Resuming");

		gameHUD.enabled = true;
		pauseMenu.enabled = false;
		Time.timeScale = 1;
	}

	void Restart() {
		restart = true;

		if (restart) {
			Debug.Log ("Restarting");
			restart = false;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}
}
