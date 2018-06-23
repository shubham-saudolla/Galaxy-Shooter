﻿/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
	[SerializeField]
	private float _speed = 3.0f;
	
	void Update () 
	{
		transform.Translate(Vector3.down * _speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			Player player = other.GetComponent<Player>();

			if(player != null)
			{
				player.TripleShotPowerupOn(); //when you destroy an object with the coroutine, the coroutine gets destroyed
				//thus we have used another function in player to call the coroutine and then destroyed the powerup
			}
			
			Destroy(this.gameObject);
		}
	}
}