using UnityEngine;
using System.Collections;

public class WaterObstacle : Obstacle {
    private ParticleSystem particle;
    private GameObject particleHolder;
    private bool played = false;
	// Update is called once per frame
	protected override void OnDestroy () {
        
        GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
        particleHolder = player.transform.Find("SplashEffect").gameObject;
        StartCoroutine(ScreenShake.SmoothShake(1f, 0.1f, 3));
        particleHolder.SetActive(true);
        particle = particleHolder.GetComponent<ParticleSystem>();
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
        particleHolder.SetActive(false);
        played = true;
        Destroy(this.gameObject);
    }


}
