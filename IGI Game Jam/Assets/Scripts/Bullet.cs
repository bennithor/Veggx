﻿using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Bullet : MonoBehaviour { 

	public float bulletSpeed = 10.0f;
    public AudioClip gun;

	// Use this for initialization 
	void Start () {
        AudioSource gunFire = GetComponent<AudioSource>();
        gunFire.PlayOneShot(gun, 1);
    } 

	public void Init(float playerBulletSpeed) { 
		bulletSpeed = playerBulletSpeed;
	} 

	// Update is called once per frame 
	void FixedUpdate () {
		transform.Translate(-Vector3.down * bulletSpeed * Time.deltaTime); 
	} 


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<PlayerMovement>() == null)
        {
            Destroy(gameObject);
        }
        else if (!other.GetComponent<PlayerMovement>().playerNr.ToString().Equals(gameObject.tag))
        {

            other.gameObject.GetComponent<PlayerMovement>().SizeReductionAndDeath();
            GameObject.Find("Player" + gameObject.tag).GetComponent<PlayerMovement>().AddSize();
            Destroy(gameObject);

        }
        
    }
} 