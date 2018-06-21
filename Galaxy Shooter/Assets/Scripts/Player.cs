/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 3.5f;

	private void Start ()
	{
		transform.position = Vector3.zero;
	}

	private void Update ()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
		transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

		//binding the player in the vertical direction
		if(transform.position.y > 0)
		{
			transform.position = new Vector3(transform.position.x, 0, 0);
		}
		else if(transform.position.y < -4.2f)
		{
			transform.position = new Vector3(transform.position.x, -4.2f, 0);
		}

		if(transform.position.x > 9.5f)
		{
			transform.position = new Vector3(-9.5f, transform.position.y, 0); //wrapping the player horizontally
		}
		else if(transform.position.x < -9.5f)
		{
			transform.position = new Vector3(9.5f, transform.position.y, 0);
		}
	}
}
