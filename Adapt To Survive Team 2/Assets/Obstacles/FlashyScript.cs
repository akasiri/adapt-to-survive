using UnityEngine;
using System.Collections;

public class FlashyScript : MonoBehaviour {

    public bool shouldIFlash = true;
    public float flashySpawnRate = 3.0f;

    private bool doTheFlashingThing = false;
    private float r = 0.0f;
    private float g = 0.0f;
    private float b = 0.0f;

	// Use this for initialization
	void Start () {
        if ((float) flashySpawnRate >= Random.Range(1, 100))
        {
            doTheFlashingThing = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldIFlash)
        {
            if (doTheFlashingThing)
            {
                GetComponent<SpriteRenderer>().material.color = new Color(r, g, b, 1.0f);

                r = (r + 0.01f) % 1.0f;
                g = (g + 0.02f) % 1.0f;
                b = (b + 0.03f) % 1.0f;
            }
        }
	}
}
