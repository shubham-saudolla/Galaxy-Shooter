/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//manager classes usually should not communicate with other scripts
//instead the scripts should communicate with the manager classes
//because the object with the script might get destroyed
//and the manager might try to communicate with this destroyed oject
//thereby throwing a null reference error

public class UIManager : MonoBehaviour 
{
	public Sprite[] lives;
	public Image livesImageDisplay;
	public Text scoreText;
	public GameObject titleScreen;
	public int score;

	private void Start()
	{
		score = 0;
		DisplayScore();
	}

	public void ShowTitleScreen()
	{
		titleScreen.SetActive(true);
	}

	public void HideTitleScreen()
	{
		titleScreen.SetActive(false);
		scoreText.text = "Score: 0";
	}

	public void UpdateLives(int currentLives)
	{
		livesImageDisplay.sprite = lives[currentLives];
	}

	public void AddScore()
	{
		score  = score + 10;
		DisplayScore();
	}

	public void DisplayScore()
	{
		scoreText.text = "Score: " + score.ToString();
	}
}
