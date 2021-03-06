﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePause: MonoBehaviour {
    public GameObject pauseButton;
    public GameObject pausePanel;

	public static bool isPaused = false;
    Displaytextbox textboxScript;
    PlayerMovement movementScript;
    //BlinkingButton blinkingScript;
    // Use this for initialization
    void Awake()
    {
        textboxScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Displaytextbox>();
        movementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
      //  blinkingScript = GameObject.Find("DownButton").GetComponent<BlinkingButton>();

        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PausePressed() {
		isPaused = true;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        textboxScript.enabled= false;
        //blinkingScript.enabled = false;
        movementScript.StopMoving();
        movementScript.MouseLeftButton();
        PlayerData.MoveFlag = false;
		GameController.instance.ToggleTimer ();
    }

    public void ResumePressed() {

		GameController.instance.ToggleTimer ();
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        textboxScript.enabled = true;
        //blinkingScript.enabled = true;
		isPaused = false;
    }

    public void ExitPressed() {

        //blinkingScript.enabled = true;
        textboxScript.enabled = true;
        Destroy(GameController.instance);
        Destroy(PlayerController.instance);
        Destroy(EndingController.instance);
		Destroy (TraceController.instance);
        LevelHandler.Instance.LoadSpecific("TitleScene");
		isPaused = false;
    }

}
