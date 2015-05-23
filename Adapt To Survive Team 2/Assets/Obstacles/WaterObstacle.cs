using UnityEngine;
using System.Collections;

public class WaterObstacle : Obstacle {
    private ParticleSystem particle;
	// Update is called once per frame
	protected override void OnDestroy () {
        GetComponent<AudioSource>().Play();
        GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
        particle = player.transform.Find("SplashEffect").GetComponent<ParticleSystem>();
        particle.startColor = new Color(1, 1, 1, 0.4f);
        particle.Play();
	}

    void OnTriggerExit2D(Collider2D other)
    {
        particle.Stop();
        Destroy(this.gameObject, 0.5f);
    }


}
