using UnityEngine;
using System.Collections;

public class PauseOnInput : MonoBehaviour {
    private GameObject OptionsPanel;
    private UIScoreDisplay Highscore;
    private static bool gameOver = false;
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
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            if (gameOver)
            {
                transform.parent.Find("GameOverDisplay/Restart").GetComponent<Restart>().RestartLevel();
            }
            else
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
}
