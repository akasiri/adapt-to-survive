using UnityEngine;
using System.Collections;

public class WaterObstacle : Obstacle {
    private ParticleSystem particle;
    private GameObject splash;
    private bool played = false;
	// Update is called once per frame
	protected override void OnDestroy () {
        
        GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
        splash = player.transform.Find("SplashEffect").gameObject;
        splash.SetActive(true);
        particle = splash.GetComponent<ParticleSystem>();
        particle.startColor = new Color(1, 1, 1, 0.4f);
        
        if (!played)
        {
            particle.Play();
            GetComponent<AudioSource>().Play();
            played = true;
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        splash.SetActive(false);
        Destroy(this.gameObject);
    }


}
