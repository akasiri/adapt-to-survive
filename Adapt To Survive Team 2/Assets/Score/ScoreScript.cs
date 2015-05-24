using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
public class ScoreScript : MonoBehaviour {
    public GameObject[] comboIcons; //organized by animal number

    public AudioMixerSnapshot mix;
    public AudioMixerSnapshot defaultmix;

    private static float countDelay = 0.25f;

    private AudioSource comboAud;
    private AudioSource aud;
    private Text text;
    private Text extra;
    private GameObject comboGroup;
    private static int extraPoints = 0;
    private static float _score = 0;
    private static float highscore;
    private static bool highscoreBeaten = false;
    private static bool comboCompleteFlag = false;

    private static bool extraPointsFlag = false;

    private ParticleSystem particle;
    private static ScoreScript thi;

    private static string combo = "";
    private static int comboCount = 0;

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
        comboAud = transform.Find("BonusScore").GetComponent<AudioSource>();
        text = GetComponent<Text>();
        comboGroup = transform.parent.transform.Find("ComboGroup").gameObject;
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
        combo = "";
        comboCount = 0;
    }

    public static void Reset()
    {
        PlayerPrefs.SetInt(Options.HighScore, 10);
        _score = 0;
        highscore = 10;

    }

	public static void AddPoints(int points, string type){
		extraPoints += points;
        thi.StartCoroutine(ExtraPoints());
        if (comboCompleteFlag)
            return;
        if (type == combo && comboCount != 0)
        {
            comboCount++;
            if (comboCount == 3)
            {
                thi.StartCoroutine(ComboComplete());
            }
        }
        else if (comboCount == 0) //new combo!
        {
            combo = type;
            comboCount++;
        }
        else //dead combo
        {
            //give points
            Debug.Log("dead combo");
            combo = "";
            comboCount = 0;
        }
        UpdateComboUI();
	}

    public static void UpdateComboUI()
    {
        // clear previous graphics
        foreach (Transform child in thi.comboGroup.transform)
            Destroy(child.gameObject);
        for (int i = 0; i < comboCount; i++)
        {
            GameObject nextGraphic = Instantiate(thi.comboIcons[Tags.obstacleToInt[combo] - 1]) as GameObject;
            nextGraphic.transform.parent = thi.comboGroup.transform;
            nextGraphic.transform.localPosition = new Vector3(30 * i - 30, 0, 0);
        }
    }

    private static IEnumerator ComboComplete()
    {
        comboCompleteFlag = true;
        for (int i = 0; i < 3; i++) //blink 3 times
        {
            Debug.Log("Blinkoff");
            foreach (Transform child in thi.comboGroup.transform)
            {
                child.gameObject.GetComponent<Image>().enabled = false;
            }
            yield return new WaitForSeconds(countDelay);
            Debug.Log("Blinkon");
            thi.comboAud.Play();
            foreach (Transform child in thi.comboGroup.transform)
            {
                child.gameObject.GetComponent<Image>().enabled = true;
            }
            yield return new WaitForSeconds(countDelay);
        }
        Debug.Log("Combo Complete!");
        comboCompleteFlag = false;
        AddPoints(15, ""); //resets combo, also adds points
        
    }

    private static IEnumerator ExtraPoints()
    {
        thi.extra.text = "(+" + extraPoints.ToString() + ")";
        yield return new WaitForSeconds(countDelay * 2);
        if (!extraPointsFlag)
        {
            extraPointsFlag = true;
            

            while (extraPoints > 0)
            {
                thi.aud.Play();
                if (extraPoints >= 3)
                {
                    extraPoints -= 2;
                    _score += 2;
                    thi.extra.text = "(+" + extraPoints.ToString() + ")";
                }
                else //extra points == 1 or 2
                {
                    _score += extraPoints;
                    extraPoints = 0;
                    
                    thi.extra.text = "";
                }
                Pause.Freeze(0.05f);
                yield return new WaitForSeconds(countDelay);

            }
            extraPointsFlag = false;
        }
    }
}
