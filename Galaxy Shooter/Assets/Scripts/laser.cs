/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
	[SerializeField]
	private float _speed = 10.0f;

	void Start ()
	{
		
	}
	
	void Update () 
	{
		transform.Translate(Vector3.up * _speed * Time.deltaTime);

		if(transform.position.y > 6)
		{
			if(transform.parent != null)
			{
				Destroy(transform.parent.gameObject); //gotta delete the gameObject of the parent of the transform!
			}

			Destroy(this.gameObject);
		}
	}
}
