using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public string levelToLoad= "MainLevel";

	public void play()
    {
        SceneManager.LoadScene(levelToLoad);
        Debug.Log("Play !!");
    }

    public void quit()
    {
        Debug.Log("Exiting !!");
        Application.Quit();
    }
}
