using UnityEngine;
using System.Collections;

public class WaterObstacle : Obstacle {
	
	// Update is called once per frame
	protected override void OnDestroy (Collider2D coll) {
        ParticleSystem particle = coll.transform.Find("SplashEffect").GetComponent<ParticleSystem>();
        particle.startColor = new Color(1, 1, 1, 0.4f);
        particle.Play();
	}
}
