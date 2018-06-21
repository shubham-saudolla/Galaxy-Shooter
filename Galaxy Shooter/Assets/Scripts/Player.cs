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
	}
}
