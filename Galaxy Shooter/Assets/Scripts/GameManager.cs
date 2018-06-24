/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool gameOver = true;
	public GameObject player;
	private UIManager _uiManager;

	public void Start()
	{
		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	private void Update()
	{
		if(gameOver)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Instantiate(player, Vector3.zero, Quaternion.identity);
				gameOver = false;
				_uiManager.HideTitleScreen();
			}
		}
	}
}
