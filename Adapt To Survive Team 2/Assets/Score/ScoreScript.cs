using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour {
    private Text text;
    private static float _score = 0;
    private static float highscore;
    private static bool highscoreBeaten = false;
    public static int Score
    {
        get { return (int)_score; }
    }
    public static int Highscore
    {
        get { return ((int)_score > (int)highscore) ? (int)_score : (int)highscore; }
    }
    public static bool HighscoreBeaten
    {
        get { return highscoreBeaten; }
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
            Debug.Log("High Score Beaten!");
            //new highscore popup
        }
	}

    public void Save()
    {
        if (highscoreBeaten)
            PlayerPrefs.SetInt(Options.HighScore, (int)_score);
    }

    public void Reset()
    {
        //should we have a reset?
        //if we do, probably from the menu, so not now
    }
}
