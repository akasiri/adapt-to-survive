using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ConfirmDialog : MonoBehaviour {
    Text text;
    bool clicked = false;
	// Use this for initialization
	void Start () {
	    text = transform.Find("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
    public void Clicked()
    {
        if (!clicked)
        {
            clicked = true;
            text.text = "Are you sure?";
        }
        else
        {
            ScoreScript.Reset();
            clicked = false;
            text.text = "Reset High Score";
        }
    }

    public void Exit()
    {
        clicked = false;
        text.text = "Reset High Score";
    }
}
