using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour {
    private Text text;
    private float _score = 0;
    private float highscore;
    private bool highscoreBeaten = false;
    public double Score
    {
        get { return _score; }
    }
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        if (PlayerPrefs.HasKey(Options.HighScore)) // set scores from stored values
            highscore = PlayerPrefs.GetInt(Options.HighScore);
        else
            highscore = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        _score += Time.deltaTime;
        text.text = ((int)(_score)).ToString();
        if ((int)(_score) > highscore && !highscoreBeaten)
        {
            highscoreBeaten = true;
            //new highscore popup
        }
	}
}
