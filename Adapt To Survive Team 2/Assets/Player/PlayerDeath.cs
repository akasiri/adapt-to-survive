using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class PlayerDeath : MonoBehaviour {
    public AudioMixerSnapshot mix;
	public GameObject player;
	public GameObject background;
	public GameObject gameOverDisplay;
    public GameObject optionsButton;
	// Public because it is being called in Obstacle.cs
	// Is this wise?
    public void Start()
    {
    }

	public void Die (GameObject tip = null) {
        mix.TransitionTo(0.01f);
        GetComponent<Pause>().pause();
		gameOverDisplay.SetActive (true);
        optionsButton.SetActive(false);
        PauseOnInput.SetGameOver(true);
        ScoreScript.Save();
        GameObject.FindGameObjectWithTag(Tags.Light).GetComponent<Light>().intensity = 1.0f;
        if (tip == null)
        {
            //warn dev that they forgot the tip
        }
        GameObject createdTip = Instantiate(tip) as GameObject;
        createdTip.transform.SetParent(gameOverDisplay.transform, false);

	}
}
