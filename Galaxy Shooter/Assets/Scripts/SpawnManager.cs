/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField]
	private GameObject enemyShipPrefab;
	[SerializeField]
	private GameObject[] powerUps;
	private GameManager _gameManager;

	void Start ()
	{
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		StartSpawnRoutines();
	}

	public void StartSpawnRoutines()
	{
		StartCoroutine(EnemySpawnRoutine());
		StartCoroutine(PowerupSpawnRoutine());
	}
	
	//coroutine to spawn an enemy every five seconds
	public IEnumerator EnemySpawnRoutine()
	{
		while(_gameManager.gameOver == false)
		{
			Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
			yield return new WaitForSeconds(5.0f);
		}
	}

	public IEnumerator PowerupSpawnRoutine()
	{
		while(_gameManager.gameOver == false)
		{
			int randomPowerup = Random.Range(0, 3);
			Instantiate(powerUps[randomPowerup], new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
			yield return new WaitForSeconds(5.0f);
		}
	}
}
