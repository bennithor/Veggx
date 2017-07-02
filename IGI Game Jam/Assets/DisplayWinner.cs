using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayWinner : MonoBehaviour {
    public string winner;
    Vector4 winnerColor;
	// Use this for initialization
	void Start () {
        winner = GameObject.Find("StaticObject").GetComponent<InfoTransfer>().winner;
        winnerColor = GameObject.Find("StaticObject").GetComponent<InfoTransfer>().winnerColor;
        gameObject.GetComponent<TextMesh>().text = "Congratulation " + winner + "!\nYou have won!" + "\nPress any key to restart!";
        gameObject.GetComponent<TextMesh>().color = winnerColor;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(0);
        }  
	}
}
