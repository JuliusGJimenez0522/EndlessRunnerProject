﻿using UnityEngine;
using System.Collections;

public class BouncingEnemy : MonoBehaviour 
{
	public float speed;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.left * Time.deltaTime * speed);
	}
}
