using UnityEngine;
using System.Collections;

public class PauseOnInput : MonoBehaviour {
    public static bool gameOver = false;
    private GameObject OptionsPanel;
    private UIScoreDisplay Highscore;
    void Start()
    {
        OptionsPanel = transform.Find("OptionsPanel").gameObject;
        Highscore = OptionsPanel.transform.Find("High Score").GetComponent<UIScoreDisplay>();
    }

    public static void SetGameOver(bool game)
    {
        gameOver = game;
    }

	void Update () {
        if (gameOver)
            return;
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
