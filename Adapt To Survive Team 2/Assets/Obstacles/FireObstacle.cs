﻿using UnityEngine;
using System.Collections;

public class FireObstacle : Obstacle
{
    public Color fireColor;
    public Color defaultColor;



    protected override void OnTriggerDestroy()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(setFire(0.5f));
        StartCoroutine(ScreenShake.RandomShake(0.25f, 0.1f));
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(Tags.Player))
            StartCoroutine(noFire(0.5f));
    }

    private IEnumerator setFire(float duration)
    {
        Light light = GameObject.FindGameObjectWithTag(Tags.Light).GetComponent<Light>();
        float time = 0;
        while(time < duration)
        {
            light.color = Color.Lerp(defaultColor, fireColor, time / duration);
            time += Time.deltaTime;
            yield return 0;
        }
        light.color = fireColor;

    }

    private IEnumerator noFire(float duration)
    {
        Light light = GameObject.FindGameObjectWithTag(Tags.Light).GetComponent<Light>();
        float time = 0;
        while (time < duration)
        {
            light.color = Color.Lerp(fireColor, defaultColor, time / duration);
            time += Time.deltaTime;
            yield return 0;
        }
        light.color = defaultColor;

    }
}
