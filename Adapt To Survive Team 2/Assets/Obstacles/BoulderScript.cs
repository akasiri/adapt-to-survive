using UnityEngine;
using System.Collections;

public class BoulderScript : Obstacle {
	// Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1.5f*speed, 0);
        setObjectWeakness();
    }

    protected override void OnDestroy()
    {
        GetComponent<AudioSource>().Play();
        transform.Find("BoulderCrush").GetComponent<ParticleSystem>().Play();
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(ScreenShake.RandomShake(0.5f, 0.25f));
        StartCoroutine(Pause.Freeze(0.1f));
    }
}
