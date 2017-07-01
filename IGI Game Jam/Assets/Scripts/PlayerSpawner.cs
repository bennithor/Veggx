using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    int maxNumberOfPlayers = 4;
    int currentNumberOfPlayers = 0;
    public Transform player;
    bool[] currentPlayers = new bool[4];


	// Use this for initialization
	void Start () {
        for (int i=0; i < 4; i++)
        {
            print(i);
            currentPlayers[i] = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 1; i <= 4; i++)
        {
            if(Input.GetAxisRaw("Fire" + i) != 0 && currentPlayers[i-1])
            {
                Transform spawnedPlayer = Instantiate(player);
                spawnedPlayer.GetComponent<PlayerMovement>().playerNr = i;
                currentPlayers[i - 1] = false;

            }
        }


    }
}
