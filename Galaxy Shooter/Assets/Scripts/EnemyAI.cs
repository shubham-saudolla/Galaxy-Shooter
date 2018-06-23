/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	private float _speed = 5.0f;
	void Start ()
	{
		
	}
	
	void Update () 
	{
		transform.Translate(Vector3.down * _speed * Time.deltaTime);

		if(transform.position.y < -7.0f)
		{
			float randomX = Random.Range(-7f, 7f);
			transform.position = new Vector3(randomX, 7, 0);
		}
	}
}
