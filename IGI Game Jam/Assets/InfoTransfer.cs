using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTransfer : MonoBehaviour {
    public string winner;
    public Vector4 winnerColor;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
