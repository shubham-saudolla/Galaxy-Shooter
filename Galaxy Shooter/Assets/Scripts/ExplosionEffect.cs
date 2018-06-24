/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
	void Start()
	{
		Destroy(this.gameObject, 4f); //destroy object after 4 seconds
	}
}
