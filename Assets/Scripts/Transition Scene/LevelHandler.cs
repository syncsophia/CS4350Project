﻿using UnityEngine;
using System.Collections;
using System;

public class LevelHandler: MonoBehaviour{
	private static LevelHandler instance;
	public GUITexture overlay;
	public float fadeTime;
	
	public static LevelHandler Instance{
		get
		{
			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<LevelHandler>();
			}
			return instance;
		}
	}
	
	void Awake(){
		overlay.pixelInset = new Rect(0,0, Screen.width, Screen.height);
		StartCoroutine(FadeToClear());
	}
	
	public void LoadSpecific(string name){
		StartCoroutine(FadeToBlack(() => Application.LoadLevel(name)));	
	}
	
	private IEnumerator FadeToClear(){
		overlay.gameObject.SetActive(true);
		overlay.color = Color.black;
		float rate = 1.0f/fadeTime;
		
		float progress = 0.0f;
		
		while(progress < 1.0f)
		{
			overlay.color = Color.Lerp(Color.black, Color.clear, progress);
			
			progress += rate * Time.deltaTime;   //constant fading time
			
			yield return null;
		}
		
		overlay.color = Color.clear;
		overlay.gameObject.SetActive(false);
		
	}
	
	private IEnumerator FadeToBlack(Action levelMethod){
		overlay.gameObject.SetActive(true);
		overlay.color = Color.clear;
		float rate = 1.0f/fadeTime;
		
		float progress = 0.0f;
		
		while(progress < 1.0f)
		{
			overlay.color = Color.Lerp(Color.clear, Color.black, progress);
			
			progress += rate * Time.deltaTime;   //constant fading time
			
			yield return null;
		}
		
		overlay.color = Color.black;
		Debug.Log (overlay.color);
	    levelMethod();
	}
	
}