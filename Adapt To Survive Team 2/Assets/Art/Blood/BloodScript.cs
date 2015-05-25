using UnityEngine;
using System.Collections;

public class BloodScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ScreenShake.RandomShake(0.5f, 0.15f));
        StartCoroutine(Pause.Freeze(0.1f));
	}
}
