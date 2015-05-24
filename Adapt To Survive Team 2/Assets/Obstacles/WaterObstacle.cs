using UnityEngine;
using System.Collections;

public class WaterObstacle : Obstacle {
    private ParticleSystem particle;
    private bool played = false;
	// Update is called once per frame
	protected override void OnDestroy () {
        
        GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
        particle = player.transform.Find("SplashEffect").GetComponent<ParticleSystem>();
        particle.startColor = new Color(1, 1, 1, 0.4f);
        particle.Play();
        if (!played)
        {
            GetComponent<AudioSource>().Play();
            played = true;
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }


}
