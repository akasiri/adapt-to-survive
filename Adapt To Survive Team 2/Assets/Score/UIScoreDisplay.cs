using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScoreDisplay : MonoBehaviour {
    private Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	public void DoUpdate () {
        if (text == null)
            text = GetComponent<Text>(); //the menu starts inactive
        Debug.Log(text);
        text.text = "High Score : " + ScoreScript.Highscore.ToString();
        if (ScoreScript.HighscoreBeaten)
            text.color = Color.green;
	}
}
