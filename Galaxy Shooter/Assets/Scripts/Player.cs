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
	private GameObject _TripleShot;
	[SerializeField]
	private GameObject _explosionPrefab;
	[SerializeField]
	private GameObject _shieldGameObject;

	private UIManager _uiManager;
	private GameManager _gameManager;
	private SpawnManager _spawnManager;

	[SerializeField]
	private float _fireRate = 0.25f;

	private float _canFire = 0.0f;

	public bool canTripleShot;
	public bool speedBoostActive;
	public bool shieldsActive = false;
	private AudioSource _audioSource;

	public int lives = 3;

	private void Start ()
	{
		transform.position = Vector3.zero;

		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		_spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
		
		if(_uiManager != null)
		{
			_uiManager.UpdateLives(lives);
		}

		if(_spawnManager != null)
		{
			_spawnManager.StartSpawnRoutines();
		}

		_audioSource = GetComponent<AudioSource>();
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

		if(speedBoostActive)
		{
			transform.Translate(Vector3.right * _speed * 2.0f * horizontalInput * Time.deltaTime);
			transform.Translate(Vector3.up * _speed * 2.0f * verticalInput * Time.deltaTime);
		}
		else
		{
			transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
			transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
		}

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
				_audioSource.Play();
				
				if(canTripleShot == true)
				{
					Instantiate(_TripleShot, transform.position, Quaternion.identity);
				}
				else
				{
					Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
				}

				_canFire = Time.time + _fireRate;
			}
	}

	public void Damage()
	{
		if(shieldsActive == true)
		{
			shieldsActive = false;
			_shieldGameObject.SetActive(false);
			return;
		}

		lives--;
		// Debug.Log("Damaging player");
		_uiManager.UpdateLives(lives);

		if(lives < 1)
		{
			Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
			_gameManager.gameOver = true;
			_uiManager.ShowTitleScreen();
		}
	}

	public void TripleShotPowerupOn()
	{
		canTripleShot = true;
		StartCoroutine(TripleShotPowerDown());
	}

	public IEnumerator TripleShotPowerDown()
	{
		yield return new WaitForSeconds(5.0f);
		canTripleShot = false;
	}

	public void SpeedBoostPowerupOn()
	{
		speedBoostActive = true;
		StartCoroutine(SpeedBoostDown());
	}

	public IEnumerator SpeedBoostDown()
	{
		yield return new WaitForSeconds(5.0f);
		speedBoostActive = false;
	}

	public void EnableShields()
	{
		shieldsActive = true;
		_shieldGameObject.SetActive(true);
	}
}
