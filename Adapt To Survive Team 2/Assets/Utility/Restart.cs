using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Restart : MonoBehaviour {
    public AudioMixerSnapshot mix;
	// Use this for initialization
	public void RestartLevel () {
        GetComponent<Pause>().unPause();
        mix.TransitionTo(0.01f);
        Application.LoadLevel(Application.loadedLevel);
	}

    public void GoToMainMenu()
    {
        Pause.staticUnPause();
        mix.TransitionTo(0.01f);
        Application.LoadLevel(Scenes.Menu);
    }
}
