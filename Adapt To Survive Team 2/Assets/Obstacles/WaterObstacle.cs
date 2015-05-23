using UnityEngine;
using System.Collections;

public class WaterObstacle : Obstacle {
	
	// Update is called once per frame
	protected override void OnDestroy () {
        GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
        ParticleSystem particle = player.transform.Find("SplashEffect").GetComponent<ParticleSystem>();
        particle.startColor = new Color(1, 1, 1, 0.4f);
        particle.Play();
        particle = player.transform.Find("SplashEffectMirrored").GetComponent<ParticleSystem>();
        particle.startColor = new Color(1, 1, 1, 0.4f);
        particle.Play();
	}
}
