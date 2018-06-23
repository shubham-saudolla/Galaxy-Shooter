/*
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
				player.canTripleShot = true;
			}
			
			Destroy(this.gameObject);
		}
	}
}
