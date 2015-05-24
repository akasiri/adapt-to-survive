using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
public class ScoreScript : MonoBehaviour {
    public AudioMixerSnapshot mix;
    public AudioMixerSnapshot defaultmix;

    private Text text;
    private static float _score = 0;
    private static float highscore;
    private static bool highscoreBeaten = false;
    private ParticleSystem particle;
    public static int Score
    {
        get { return (int)_score; }
    }
    public static int Highscore
    {
        get { 
            return ((int)_score > (int)highscore) ? (int)_score : (int)highscore; }
    }
    public static bool HighscoreBeaten
    {
        get { return highscoreBeaten; }
    }

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        particle = transform.Find("DingSwirlGlow").GetComponent<ParticleSystem>(); //ignore the error this throws in the menu screen
        if (PlayerPrefs.HasKey(Options.HighScore)) // set scores from stored values
            highscore = PlayerPrefs.GetInt(Options.HighScore);
        else
            highscore = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (text == null)
            return;
        _score += Time.deltaTime;
        text.text = ((int)(_score)).ToString();
        if ((int)(_score) > highscore && !highscoreBeaten)
        {
            highscoreBeaten = true;
            Debug.Log("High Score Beaten!");
            text.color = Color.green;
            particle.Play();
            StartCoroutine(ScreenShake.RandomShake(0.25f, 0.02f));
            StartCoroutine(Pause.Freeze(.1f, 0.5f));
            mix.TransitionTo(0.25f);
            Invoke("resetmix", 0.25f);
            //new highscore popup
        }
	}

    private void resetmix()
    {
        defaultmix.TransitionTo(0.25f);
    }

    public static void Save()
    {
        if (highscoreBeaten)
            PlayerPrefs.SetInt(Options.HighScore, (int)_score);
        _score = 0;
        highscoreBeaten = false;
    }

    public static void Reset()
    {
        PlayerPrefs.SetInt(Options.HighScore, 10);
        _score = 0;
        highscore = 10;

    }

	public static void AddPoints(int points){
		_score += points;
	}
}
