﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInFadeOut : MonoBehaviour {

	public Sprite[] textboxImages = new Sprite[2];
	public bool isActivated = false;
	public bool isFadingOn = false;
	public float alpha;

	private Color defaultColor;
	private float fadeSpeed = 0.7f;
	private float defaultAlpha = 0.5f;


	private FeedTextFromObject feedText;

	public GameObject button;
	public bool eventStatus = false;
		
	// Use this for initialization
	void Start () {
		feedText = transform.GetComponentInChildren<FeedTextFromObject> ();

		defaultColor = new Color( (148.0f/255.0f) , (159.0f/255.0f), (213.0f/255.0f), defaultAlpha);
		gameObject.GetComponent<Image>().color = new Color( (148.0f/255.0f) , (159.0f/255.0f), (213.0f/255.0f), 0.0f);
		alpha = 0.0f;
		isActivated = false;
		button.SetActive (false);
	}

	public void TouchDetected()
	{
		if(!isFadingOn)
			GameObject.FindGameObjectWithTag("Player").GetComponent<Displaytextbox> ().toggleRespond ();
	}

	public void SetEventStatus(bool _status)
	{
		eventStatus = _status;
	}

	public void TurnOnTextbox(bool _fadingOption)
	{
		isActivated = true;
		button.SetActive (true);
		isFadingOn = _fadingOption;
		gameObject.GetComponent<Image>().color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, defaultAlpha);

		if (!EndingController.instance.isChapter2Activated && eventStatus) {
			transform.GetComponent<Image> ().sprite = textboxImages [1];
			gameObject.GetComponent<Image> ().color = new Color (defaultColor.r, defaultColor.g, defaultColor.b, 0.8f);
		} else
			transform.GetComponent<Image> ().sprite = textboxImages [0];
	}

	public bool getStatus()
	{
		return isActivated;
	}

	public float getAlpha()
	{
		return alpha;
	}
	
	// Update is called once per frame
	void Update () {

		if (isActivated) {
			if(!isFadingOn) // fading is OFF
			{
				PlayerData.MoveFlag = false;
                PlayerSound.AllowIdleAutoSound = false;
                feedText.setAlpha(1.0f);
			}
			else if (isFadingOn && gameObject.GetComponent<Image> ().color.a > 0.0f) {
				button.SetActive(false);
				alpha = gameObject.GetComponent<Image> ().color.a;
				alpha -= (fadeSpeed * Time.deltaTime);
				gameObject.GetComponent<Image> ().color = new Color (defaultColor.r, defaultColor.g, defaultColor.b, alpha);
				feedText.setAlpha(alpha);
			}
		}
	}

	void LateUpdate()
	{
		if (gameObject.GetComponent<Image> ().color.a <= 0.0f) {
			isActivated = false;
			isFadingOn = false;
			feedText.ResetTextFeed();
			if(!GamePause.isPaused)
				PlayerData.MoveFlag = true;
            PlayerSound.AllowIdleAutoSound = true;
		}
	}
}
