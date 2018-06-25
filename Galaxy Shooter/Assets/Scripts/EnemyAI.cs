/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	[SerializeField]
	private GameObject _enemyExplosionPrefab;
	private UIManager _uiManager;
	
	private float _speed = 5.0f;
	[SerializeField]
	private AudioClip _clip;

	void Start ()
	{
		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
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

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Laser")
		{
			if(other.transform.parent != null)
			{
				Destroy(other.transform.parent.gameObject); //have to delete the gameObject of the parent
			}
			else
			{
				Destroy(other.gameObject);
			}

			_uiManager.AddScore();

			Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
			Destroy(this.gameObject);
		}
		else if(other.tag == "Player")
		{
			Player player = other.GetComponent<Player>(); //getting the script component

			if(player != null)
			{
				player.Damage();
			}

			Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
			Destroy(this.gameObject);
		}
	}
}
