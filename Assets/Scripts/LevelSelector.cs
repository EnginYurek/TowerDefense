
using UnityEngine;

public class LevelSelector : MonoBehaviour {

    public SceneFader fader;

    public void select(string levelName)
    {
        fader.fadeTo(levelName);
    }
}
