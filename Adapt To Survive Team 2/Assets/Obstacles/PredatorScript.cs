using UnityEngine;
using System.Collections;

public class PredatorScript : Obstacle {

	// Use this for initialization
    protected override void OnDestroy()
    {
        GetComponent<PredatorDeath>().Explode();
        GetComponent<AudioSource>().Play();
        StartCoroutine(ScreenShake.RandomShake(0.5f, 0.15f));
        StartCoroutine(Pause.Freeze(0.1f));
    }
}
