using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    int maxNumberOfPlayers = 4;
    int currentNumberOfPlayers = 0;
    public Transform player;
    public bool[] currentPlayers = new bool[4];
    Color[] mats = new Color[4];
    public bool hasGameStarted;

    public AudioClip spawn;
    AudioSource spawnSound;
    float deadTimeSetter = 1.2f;
    float deadTimer;
    public bool roundJustEnded;


    // Use this for initialization
    void Start () {
        for (int i=0; i < 4; i++)
        {
            currentPlayers[i] = true;
        }
        mats[0] = new Vector4(0.6f, 0.2f, 0.314f, 1f);
        mats[1] = new Vector4(0.667f, 0.431f, 0.224f, 1);
        mats[2] = new Vector4(0.137f, 0.384f, 0.404f, 1);
        mats[3] = new Vector4(0.369f, 0.592f, 0.196f, 1);
        hasGameStarted = false;

        spawnSound = GetComponent<AudioSource>();
        roundJustEnded = false;
        deadTimer = deadTimeSetter;
        

    }
	
	// Update is called once per frame
	void Update () {

        if(roundJustEnded)
        {
            deadTimer -= Time.deltaTime;
        }

        if(deadTimer <= 0.0f )
        {
            roundJustEnded = false;
            deadTimer = deadTimeSetter;
        }

        for (int i = 1; i <= 4; i++)
        {
            if(Input.GetAxisRaw("Fire" + i) != 0 && currentPlayers[i-1] && !roundJustEnded)
            {
                Transform spawnedPlayer = Instantiate(player);
                Vector3 spawnedPlayerLoc = spawnedPlayer.position;
                spawnedPlayer.GetComponent<SpriteRenderer>().color = mats[i - 1];
                spawnedPlayerLoc.x += Random.Range(-4.0f, 4.0f);
                spawnedPlayerLoc.y += Random.Range(-4.0f, 4.0f);
                spawnedPlayer.position = spawnedPlayerLoc;
                spawnedPlayer.GetComponent<PlayerMovement>().playerNr = i;
                currentPlayers[i - 1] = false;
                hasGameStarted = true;
                spawnSound.PlayOneShot(spawn);

            }
        }


    }
}
