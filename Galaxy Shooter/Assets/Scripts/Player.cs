/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private float _speed = 3.5f;

	[SerializeField]
	private GameObject _laserPrefab;

	[SerializeField]
	private float _fireRate = 0.25f;
	private float _canFire = 0.0f;
	public bool canTripleShot;

	private void Start ()
	{
		transform.position = Vector3.zero;
	}

	private void Update ()
	{
		Movement();

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			Shoot();
		}
	}

	private void Movement()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
		transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);

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

	private void Shoot()
	{
		if(Time.time > _canFire)
			{
				if(canTripleShot == true)
				{
					//left
					Instantiate(_laserPrefab, transform.position + new Vector3(-0.55f, 0.06f, 0), Quaternion.identity);
					//center
					Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
					//right
					Instantiate(_laserPrefab, transform.position + new Vector3(0.55f, 0.06f, 0), Quaternion.identity);
				}
				else
				{
					Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
				}

				_canFire = Time.time + _fireRate;
			}
	}
}
