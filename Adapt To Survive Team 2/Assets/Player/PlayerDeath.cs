using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class PlayerDeath : MonoBehaviour {
    public AudioMixerSnapshot mix;
	public GameObject player;
	public GameObject background;
	public GameObject gameOverDisplay;

	// P	ublic because it is being called in Obstacle.cs
	// Is this wise?
    public void Start()
    {
    }

	public void Die () {
        mix.TransitionTo(0.01f);
        GetComponent<Pause>().pause();
		gameOverDisplay.SetActive (true);
	}
}
