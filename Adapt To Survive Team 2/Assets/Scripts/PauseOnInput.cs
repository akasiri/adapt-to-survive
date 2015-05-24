using UnityEngine;
using System.Collections;

public class PauseOnInput : MonoBehaviour {
    private GameObject OptionsPanel;
    private UIScoreDisplay Highscore;
    void Start()
    {
        OptionsPanel = transform.Find("OptionsPanel").gameObject;
        Highscore = OptionsPanel.transform.Find("High Score").GetComponent<UIScoreDisplay>();
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Pause.isPaused())
            {
                Pause.staticUnPause();
                OptionsPanel.SetActive(false);
            }
            else
            {
                Pause.staticPause();
                OptionsPanel.SetActive(true);
                Highscore.DoUpdate();
            }
        }
	}
}
