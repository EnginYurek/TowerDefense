using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour {

    private bool gameEnded = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameEnded)
            return;

        if (PlayerStats.lives <= 0)
        {
            endGame();
        }

        
	}

    void endGame()
    {
        gameEnded = true;
        Debug.Log("Game Over! ");
    
    }
}
