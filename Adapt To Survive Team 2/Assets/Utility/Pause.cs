using UnityEngine;
using System.Collections;

//should not be put on gameObjects


public class Pause : MonoBehaviour {

    private static float? currentTimeScale;
    private static bool paused = false;
    private static bool frozen = false;
	public void pause(bool toPause = true)
    {
        Debug.Log("Pause");
        if (toPause && !paused)
        {
            if (!frozen)
                currentTimeScale = Time.timeScale;
            Time.timeScale = 0;
            paused = true;
        }
        else if (!toPause && paused)
        {
            Time.timeScale = currentTimeScale ?? 1.0f;
            paused = false;
        }

        // maybe warnings if nothing will happen?
    }

    //inverse of Pause, basically.
    public void unPause(bool toUnPause = true)
    {
        if (!toUnPause && !paused)
        {
            if (!frozen)
                currentTimeScale = Time.timeScale;
            Time.timeScale = 0;
            paused = true;
        }
        else if (toUnPause && paused)
        {
            Time.timeScale = currentTimeScale ?? 1.0f;
            paused = false;
        }
    }

    //freeze time for a small amount in order to emphasize an impact or effect
    public static IEnumerator Freeze(float durationRealSeconds, float timeScale = 0f)
    {
        Debug.Log("Freeze");
        if (frozen)
            yield break;
        frozen = true;

        if(!paused)
            currentTimeScale = Time.timeScale;
        Time.timeScale = timeScale;
        float pauseEndTime = Time.realtimeSinceStartup + durationRealSeconds;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        frozen = false;
        Time.timeScale = currentTimeScale ?? 1.0f;
    }
}
