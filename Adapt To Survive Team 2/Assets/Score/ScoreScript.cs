using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour {
    private Text text;
    private float _score = 0;
    public double Score
    {
        get { return _score; }
    }
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        _score += Time.deltaTime;
        text.text = _score.ToString();
	}
}
