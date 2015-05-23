using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	public GameObject player;
	public GameObject background;
	public GameObject gameOverDisplay;

	// P	ublic because it is being called in Obstacle.cs
	// Is this wise?
	public void Die () {
		player.SetActive (false);
		background.GetComponent<BackgroundScript> ().speed = 0;
		gameOverDisplay.SetActive (true);
	}
}
