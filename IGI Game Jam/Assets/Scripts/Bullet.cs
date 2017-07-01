﻿using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Bullet : MonoBehaviour { 

	public float bulletSpeed = 10.0f; 
	public float lifetime = 2; 

	// Use this for initialization 
	void Start () { 

	} 

	public void Init(float playerBulletSpeed) { 
		bulletSpeed = playerBulletSpeed; 
		Destroy (gameObject, lifetime); 
	} 

	// Update is called once per frame 
	void Update () { 
		transform.Translate(-Vector3.down * bulletSpeed * Time.deltaTime); 
	} 
} 