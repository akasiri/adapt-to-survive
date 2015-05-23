using UnityEngine;
using System.Collections;

public class WaterObstacle : Obstacle {
    private ParticleSystem particle;
	// Update is called once per frame
	protected override void OnDestroy () {
        Debug.Log("Splash");
        GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
        particle = player.transform.Find("SplashEffect").GetComponent<ParticleSystem>();
        particle.startColor = new Color(1, 1, 1, 0.4f);
        particle.Play();
	}

    void OnTriggerExit2D(Collider2D other)
    {
        particle.Stop();
    }


}
