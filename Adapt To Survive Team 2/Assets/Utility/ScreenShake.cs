using UnityEngine;
using System.Collections;


public class ScreenShake : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    public static IEnumerator RandomShake(float duration, float magnitude)
    {
        while (duration > 0)
        {
            duration = duration - Time.deltaTime;
            Camera.main.transform.localPosition = Random.insideUnitSphere * magnitude;
            yield return 0;
        }
        Camera.main.transform.localPosition = Vector3.zero; //reset to default
    }

    public static IEnumerator SmoothShake(float duration, float magnitude, float frequency)
    {
        while (duration > 0)
        {
            duration = duration - Time.deltaTime;
            Camera.main.transform.localPosition = magnitude * new Vector3(Mathf.PerlinNoise(0, frequency * duration), Mathf.PerlinNoise(frequency * duration, 0), Mathf.PerlinNoise(-frequency * duration, -frequency * duration));
            yield return 0;
        }
        Camera.main.transform.localPosition = Vector3.zero; //reset to default
    }
}
