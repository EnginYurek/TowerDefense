using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour {

    public static bool gameisOver = false;

    public GameObject gameOverUI;

	// Use this for initialization
	void Start () {
        gameisOver = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (gameisOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            endGame();
        }

        if (PlayerStats.lives <= 0)
        {
            endGame();
        }

        
	}

    void endGame()
    {
        gameisOver = true;
        Debug.Log("Game Over! ");

        gameOverUI.SetActive(true);
    }
}
