﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	public Canvas pauseMenu;
	public Canvas gameHUD;
	bool paused = false;

	Button continueButton;

	void Start () {
		gameHUD.enabled = true;
		pauseMenu.enabled = false;
		Time.timeScale = 1;

		continueButton = pauseMenu.GetComponentInChildren<Button> ();
	}

	void Update () {
		
		// Press "r" to pause the game
		if(Input.GetButtonDown("Pause")) {
			Pause ();
		}

		continueButton.onClick.AddListener (Resume);
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

		gameHUD.enabled = true;
		pauseMenu.enabled = false;
		Time.timeScale = 1;
	}
}
