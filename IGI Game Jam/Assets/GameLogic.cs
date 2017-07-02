using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public Font unipix;

    public float timeSetter = 10;
    public float timer;
    GameObject p1;
    GameObject p2;
    GameObject p3;
    GameObject p4;
    Dictionary<String, int> scoreDict = new Dictionary<string, int>();
    GameObject spawner;
    int[] roundsWon = new int[4];

    List<GameObject> currentPlayers = new List<GameObject>();

    GUIStyle p1Col = new GUIStyle();
    GUIStyle p2Col = new GUIStyle();
    GUIStyle p3Col = new GUIStyle();
    GUIStyle p4Col = new GUIStyle();

    Vector4 gray;


    GameObject timerText;

    Vector4[] pColors = new Vector4[4];

    // Use this for initialization
    void Start () {
        spawner = GameObject.Find("ScriptObject");
        for(int i=0; i<4; i++)
        {
            roundsWon[i] = 0;
        }
        p1Col.normal.textColor = new Vector4(0.6f, 0.2f, 0.314f, 1f);
        p2Col.normal.textColor = new Vector4(0.667f, 0.431f, 0.224f, 1);
        p3Col.normal.textColor = new Vector4(0.137f, 0.384f, 0.404f, 1);
        p4Col.normal.textColor = new Vector4(0.369f, 0.592f, 0.196f, 1);

        p1Col.font = unipix;
        p2Col.font = unipix;
        p3Col.font = unipix;
        p4Col.font = unipix;

        p1Col.fontSize = 32;
        p2Col.fontSize = 32;
        p3Col.fontSize = 32;
        p4Col.fontSize = 32;

        pColors[0] = p1Col.normal.textColor;
        pColors[1] = p2Col.normal.textColor;
        pColors[2] = p3Col.normal.textColor;
        pColors[3] = p4Col.normal.textColor;

        timerText = GameObject.Find("TimerText");
        timer = timeSetter;
        gray = new Vector4(39.0f/255.0f, 39.0f / 255.0f, 39.0f / 255.0f, 255.0f / 255.0f);
        timerText.GetComponent<TextMesh>().text = timer.ToString("n0");

    }
	
	// Update is called once per frame
	void Update () {

        if(spawner.GetComponent<PlayerSpawner>().hasGameStarted)
        {
            timer -= Time.deltaTime;
            timerText.GetComponent<TextMesh>().color = gray;
            timerText.GetComponent<TextMesh>().text = timer.ToString("n0");


        }
        

        if (timer <= 0.0f)
        {
            int maxSize = 0;
            string winner = string.Empty;
            try
            {
                p1 = GameObject.Find("Player1");
                scoreDict.Add("Player 1", p1.GetComponent<PlayerMovement>().GetSize());
                currentPlayers.Add(p1);
                Destroy(p1);
            }
            catch(Exception e)
            {
                print(e);
                
            }

            try
            {
                p2 = GameObject.Find("Player2");
                scoreDict.Add("Player 2", p2.GetComponent<PlayerMovement>().GetSize());
                currentPlayers.Add(p2);
                Destroy(p2);
            }
            catch (Exception e)
            {
                print(e);
            }

            try
            {
                p3 = GameObject.Find("Player3");
                scoreDict.Add("Player 3", p3.GetComponent<PlayerMovement>().GetSize());
                currentPlayers.Add(p3);
                Destroy(p3);
            }
            catch (Exception e)
            {
                print(e);
            }

            try
            {
                p4 = GameObject.Find("Player4");
                scoreDict.Add("Player 4", p4.GetComponent<PlayerMovement>().GetSize());
                currentPlayers.Add(p4);
                Destroy(p4);
            }
            catch (Exception e)
            {
                print(e);
            }

            foreach(KeyValuePair<String,int> pair in scoreDict)
            {
                if(pair.Value > maxSize)
                {
                    maxSize = pair.Value;
                    winner = pair.Key;
                }
                else if(pair.Value == maxSize)
                {
                    winner = "Tie!";
                    timerText.GetComponent<TextMesh>().text = "Tie!";
                    timerText.GetComponent<TextMesh>().color = gray;
                }
            }

            timer = timeSetter;
            scoreDict.Clear();
            spawner.GetComponent<PlayerSpawner>().hasGameStarted = false;
            for(int i=0; i < 4; i++)
            {
                if(winner.Equals("Player " + (i+1)))
                {
                    roundsWon[i] += 1;
                    timerText.GetComponent<TextMesh>().text = "Winner";
                    timerText.GetComponent<TextMesh>().color = pColors[i];


                }

                spawner.GetComponent<PlayerSpawner>().currentPlayers[i] = true;

                if(roundsWon[i] == 3)
                {
                    GameObject.Find("StaticObject").GetComponent<InfoTransfer>().winner = ("Player " + (i+1));
                    GameObject.Find("StaticObject").GetComponent<InfoTransfer>().winnerColor = pColors[i];
                    SceneManager.LoadScene(1);
                }
            }

            GetComponent<PlayerSpawner>().roundJustEnded = true;


        }


		if(Input.GetKeyDown("escape")) {
            SceneManager.LoadScene(0);
        }
	}


    void OnGUI()
    {

 
            GUI.Label(new Rect(10, 10, 120, 30), "Rounds won: " + roundsWon[0] + "/3", p1Col);
   
            GUI.Label(new Rect(10, 40, 120, 30), "Rounds won: " + roundsWon[1] + "/3", p2Col);

            GUI.Label(new Rect(10, 70, 120, 30), "Rounds won: " + roundsWon[2] + "/3", p3Col);
            
            GUI.Label(new Rect(10, 100, 120, 30),"Rounds won: " + roundsWon[3] + "/3", p4Col);
        
    }
}
