using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
public class ScoreScript : MonoBehaviour {
    public AudioMixerSnapshot mix;
    public AudioMixerSnapshot defaultmix;

    private static float countDelay = 0.25f;

    private AudioSource aud;
    private Text text;
    private Text extra;
    private static int extraPoints = 0;
    private static float _score = 0;
    private static float highscore;
    private static bool highscoreBeaten = false;
    private ParticleSystem particle;
    private static ScoreScript thi;
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
        aud = GetComponent<AudioSource>();
        extra = transform.Find("BonusScore").GetComponent<Text>();
        text = GetComponent<Text>();
        particle = transform.Find("DingSwirlGlow").GetComponent<ParticleSystem>(); //ignore the error this throws in the menu screen
        if (PlayerPrefs.HasKey(Options.HighScore)) // set scores from stored values
            highscore = PlayerPrefs.GetInt(Options.HighScore);
        else
            highscore = 10;
        thi = this;
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
		extraPoints += points;
        thi.StartCoroutine(ExtraPoints());
	}

    private static IEnumerator ExtraPoints()
    {
        thi.extra.text = "(+" + extraPoints.ToString() + ")";
        yield return new WaitForSeconds(countDelay * 2);

        while (extraPoints > 0)
        {
            thi.aud.Play();
            if (extraPoints >= 2)
            {
                extraPoints -= 2;
                _score += 2;
                thi.extra.text = "(+" + extraPoints.ToString() + ")";
            }
            else //extra points == 1
            {
                extraPoints -= 1;
                _score += 1;
                thi.extra.text = "";
            }
            Pause.Freeze(0.03f);
            yield return new WaitForSeconds(countDelay);

        }
    }
}
